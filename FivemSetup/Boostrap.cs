using System;
using System.Collections.Generic;
using System.Linq;
using FivemSetup.Controllers;
using FivemSetup.ENV;
using FivemSetup.Services;
using FivemSetup.Views;

namespace FivemSetup
{
    public class Boostrap
    {
        private const string FIVEM_ARTIFACTS_URL =
            @"https://runtime.fivem.net/artifacts/fivem/build_server_windows/master/";

        public ArtifactsService ArtifactsService { get; set; }

        public async void start()
        {
            ArtifactsService = new ArtifactsService(FIVEM_ARTIFACTS_URL);
            var consoleController = new ConsoleController();
            var consoleView = new ConsoleView();
            consoleController.Register(ArtifactsService, consoleView);
            consoleView.Register(consoleController);

            consoleView.Show();
        }
    }
}