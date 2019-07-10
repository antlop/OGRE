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
using System.Timers.Timer;

namespace OGREAPI
{
    public class Startup
    {
        int count = 0;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoadUpDatabases();

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
		if( Directory.Exists(path) && File.Exists(path + "\\Users.txt") ) {
		using( StreamReader reader = new StreamReader(path + "\\Users.txt") ) {
			lock(UserDatabase.Instance.UsersDB) 
			{
				while(!reader.EndOfStream) {
					string[] line = reader.ReadLine().Split(';');
					User user = new User();
					user.Name = line[0];
					user.Password = line[1];
					user.Version = Convert.ToInt32(line[2]);
					switch(line[3]) {
						case "Member":
							user.Rank = .Member;
						break;
						case "GuildLeader":
							user.Rank = .GuildLeader;
						break;
						case "GuildMaster":
							user.Rank = .GuildMaster;
						break;
					}
					UserDatabase.Instance.UsersDB.Add(line[0], user);
				}
			}
		}
        }

	private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)

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

            path += "\\Users.txt";
            if( !File.Exists(path))
            {
                File.Create(path);
                AddDirectorySecurity(path);
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                lock (UserDatabase.Instance.UsersDB)
                {
                    foreach (User user in UserDatabase.Instance.UsersDB.Values)
                    {
                        writer.WriteLine(user.ToString() + "\n");
                    }
                }
            }
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
