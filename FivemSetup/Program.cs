using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FivemSetup.ENV;
using FivemSetup.Utils;
using Newtonsoft.Json;

namespace FivemSetup
{
    class Program
    {
        public static Configuration Configuration;

        static void Main(string[] args)
        {
            var readAllText = File.ReadAllText(Environment.CurrentDirectory + @"\Config.json");

            Configuration = JsonConvert.DeserializeObject<Configuration>(readAllText);

            var boostrap = new Boostrap();
            boostrap.Start();

            Console.ReadKey();
        }
    }
}