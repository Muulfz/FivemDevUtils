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

        public async Task ActionSelection(string option)
        {
            await Setup();
        }
        

        private async Task Setup()
        {
            var download = await _artifactsService.Download(_artifactsService.artifacts.First().Value,
                Program.Configuration.serverCorePath);
            FileExtractor.Zip(download, Program.Configuration.serverCorePath);
        }

        public List<string> GetOptions()
        {
            return menuOptions;
        }
    }
}