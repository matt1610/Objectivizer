using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

[assembly: OwinStartup(typeof(Objectivizer.Startup))]

namespace Objectivizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureStaticFiles(app);
        }

        private void ConfigureStaticFiles(IAppBuilder app)
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string wwwroot = Path.Combine(root, "wwwroot/ObjectivizerUi/dist");

            var fileServerOptions = new FileServerOptions()
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = false,
                RequestPath = new PathString(string.Empty),
                FileSystem = new PhysicalFileSystem(wwwroot)
            };

            fileServerOptions.StaticFileOptions.ServeUnknownFileTypes = true;
            app.UseFileServer(fileServerOptions);
        }


    }
}
