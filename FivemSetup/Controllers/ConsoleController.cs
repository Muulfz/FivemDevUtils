using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FivemSetup.ENV;
using FivemSetup.Services;
using FivemSetup.Utils;
using FivemSetup.Views;

namespace FivemSetup.Controllers
{
    public class ConsoleController
    {
        private List<string> menuOptions;
        public ArtifactsService _artifactsService { get; set; }
        private ConsoleView ConsoleView;

        public void Register(ArtifactsService artifactsService, ConsoleView consoleView)
        {
            this._artifactsService = artifactsService;
            this.ConsoleView = consoleView;
            menuOptions = new List<string>
            {
                "Setup",
                "Update"
            };
        }

        public async void ActionSelection(string option)
        {
            await Setup();
        }
        

        private async Task Setup()
        {
            Console.WriteLine(Program.Configuration.serverCorePath);
            var download = await _artifactsService.Download(_artifactsService.artifacts.First().Value,
                Program.Configuration.serverCorePath);
            Console.WriteLine("UnZip - Citizen");
            FileExtractor.Zip(download, Program.Configuration.serverCorePath);
            Console.WriteLine("Finish !");
        }

        public List<string> GetOptions()
        {
            return menuOptions;
        }
    }
}