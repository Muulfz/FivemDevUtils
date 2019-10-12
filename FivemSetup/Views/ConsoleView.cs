using System;
using System.Collections.Generic;
using FivemSetup.Controllers;

namespace FivemSetup.Views
{
    public class ConsoleView
    {
        private List<string> menuOptions { get; set; }

        private ConsoleController Controller;
        
        public void Register(ConsoleController consoleController)
        {
            this.Controller = consoleController;
            menuOptions = consoleController.GetOptions();
        }
        
        public void Show()
        {
            Console.WriteLine("Escolha a opção desejada!");
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1} .{menuOptions[i]}");
            }

            string menuOption = null;
            try
            {
                var selection = int.Parse(Console.ReadLine());
                 menuOption= menuOptions[selection-1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Input Invalido!");
                Show();
            }
            
            Controller.ActionSelection(menuOption);
        }
        
        
    }
}