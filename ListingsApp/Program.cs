using ListingsApp.Ui;
using System;

namespace ListingsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UiInterface ui = new CliImpl();
            ui.start(args: args);
        }
    }
}
