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
        
        static async Task Main(string[] args)
        {
                
            var readAllText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Config.json");

           Configuration = JsonConvert.DeserializeObject<Configuration>(readAllText);
            
            var boostrap = new Boostrap();
            boostrap.start();
            
            Console.ReadKey();
        }
        
    }
}