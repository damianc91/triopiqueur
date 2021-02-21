using Microsoft.Extensions.Logging;
using Microsoft.Shell;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        private const string Unique = "My_Unique_Application_String_swhgthsrthx";
        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance(Unique))
            {
                var application = new App();
                application.InitializeComponent();
                application.Run();
                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();

               
            }
        }

        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            throw new NotImplementedException();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(path: "log.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();


            if (!File.Exists("config.xml"))
            {
                //File.Create("config.xml");
                System.IO.File.WriteAllText("config.xml", "<root><currentTeam><number>1</number><money></money><division></division></currentTeam><teams></teams></root>");
            }
            else
            {
                XmlDocument documentXml = new XmlDocument();
                string configPath = "config.xml";
                documentXml.Load(configPath);

                XmlNode projectNode = documentXml.SelectSingleNode("//root/teams");
                projectNode.RemoveAll();

                XmlNode nodeCurrentTeam = documentXml.SelectSingleNode("//root/currentTeam/number");
                nodeCurrentTeam.InnerText = "1";
                documentXml.Save(configPath);
            }
        }
    }
}
