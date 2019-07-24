using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Security.AccessControl;
using OGREAPI.Controllers;
using System.Timers;
using Newtonsoft.Json;

namespace OGREAPI
{
    public class Startup
    {
        int count = 0;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoadUpDatabases();
            WriteDatabasesToFile();

		    Timer t = new Timer(60000); // 1 sec = 1000, 60 sec = 60000

		    t.AutoReset = true;

		    t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);

		    t.Start();

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        void LoadUpDatabases()
        {
		    string path = "C:\\OGRE\\API";
            /*************************************************************************/
            // USERS
		    if( Directory.Exists(path) && File.Exists(path + "\\Users.txt") ) {
                using (StreamReader reader = new StreamReader(path + "\\Users.txt")) {
                    lock (UserDatabase.Instance.UsersDB)
                    {
                        while (!reader.EndOfStream) {
                            string[] line = reader.ReadLine().Split(';');
                            if( line.Length < 3 )
                            {
                                break;
                            }
                            User user = new User(line[0], line[1], Convert.ToInt32(line[2]));
                            switch (line[3]) {
                                case "Member":
                                    user.Rank = MemberRanks.MEMBER;
                                    break;
                                case "GuildLeader":
                                    user.Rank = MemberRanks.GUILD_LEADER;
                                    break;
                                case "GuildMaster":
                                    user.Rank = MemberRanks.GUILD_MASTER;
                                    break;
                            }
                            UserDatabase.Instance.UsersDB.Add(line[0], user);
                        }
                    }
                }
		    }

            /*************************************************************************/
            // BANK
            if (Directory.Exists(path) && File.Exists(path + "\\Bank.txt"))
            {
                using (StreamReader reader = new StreamReader(path + "\\Bank.txt"))
                {
                    lock (BankDatabase.Instance)
                    {
                        string json = reader.ReadLine();
                        var bank = JsonConvert.DeserializeObject<Bank>(json);

                        //BankDatabase.Instance.m_Bank = bank;
                    }
                }
            }

            /*************************************************************************/
            // EVENT
            if (Directory.Exists(path) && File.Exists(path + "\\Event.txt"))
            {
                using (StreamReader reader = new StreamReader(path + "\\Event.txt"))
                {
                    lock (EventDatabase.Instance.m_Event)
                    {
                        string json = reader.ReadLine();
                        if (json != null && json.Length > 0)
                        {
                            var e = JsonConvert.DeserializeObject<Event>(json);

                            EventDatabase.Instance.m_Event = e;
                        }
                    }
                }
            }
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
	    {
            WriteDatabasesToFile();
	    }

        void WriteDatabasesToFile()
        {
            string path = "C:";
            AddDirectorySecurity(path);
            path += "\\OGRE\\API";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                AddDirectorySecurity(path);
            }

            /********************************************************************/
            // USERS
            string usersPath = path + "\\Users.txt";
            if( !File.Exists(usersPath))
            {
                File.Create(usersPath);
                AddDirectorySecurity(usersPath);
            }

            using (StreamWriter writer = new StreamWriter(usersPath))
            {
                lock (UserDatabase.Instance.UsersDB)
                {
                    foreach (User user in UserDatabase.Instance.UsersDB.Values)
                    {
                        writer.WriteLine(user.ToString());
                    }
                }
            }
            /********************************************************************/


            /********************************************************************/
            // Bank
            string bankPath = path + "\\Bank.txt";
            if (!File.Exists(bankPath))
            {
                File.Create(bankPath);
                AddDirectorySecurity(bankPath);
            }

            using (StreamWriter writer = new StreamWriter(bankPath))
            {
                lock (BankDatabase.Instance)
                {
                    string sz = JsonConvert.SerializeObject(BankDatabase.Instance.m_Bank);
                    writer.WriteLine(sz);
                }
            }
            /********************************************************************/


            /********************************************************************/
            // Event
            string eventPath = path + "\\Event.txt";
            if (!File.Exists(eventPath))
            {
                File.Create(eventPath);
                AddDirectorySecurity(eventPath);
            }

            using (StreamWriter writer = new StreamWriter(eventPath))
            {
                lock (EventDatabase.Instance.m_Event)
                {
                    string sz = JsonConvert.SerializeObject(EventDatabase.Instance.m_Event);
                    writer.WriteLine(sz);
                }
            }
            /********************************************************************/
        }

        public static void AddDirectorySecurity(string FileName)
        {
            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(FileName);

            // Get a DirectorySecurity object that represents the
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings.
            dSecurity.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }
    }
}
