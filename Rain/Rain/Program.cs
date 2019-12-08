using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<string> studentList = new List<string>
            {
                "Javier Gonzalez",
                "Yexalan Johnson",
                "Cesar Lopez",
                "Truc Driver",
                "Mike Hawk",
                "Andrew French",
                "Trinity Matrix",
                "Ashonty Roberts",
                "Noah Anderson",
                "Andrew Gomez",
                "Joe Mama"
            };

            File.WriteAllText(@"ExampleStudents.json", JsonConvert.SerializeObject(studentList));

            //Directory.CreateDirectory("Classes\\Spanish 1");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LandingPage(""));
        }
    }
}
