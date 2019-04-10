using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class CommandPattern
    {
        public static void Test()
        {
            ICommand consolePrintCmd = new ConsolePrintCommand();
            consolePrintCmd.Execute(new Document() { Text = "test" });

            ICommand paperPrintCmd = new PaperPrintCommand();
            paperPrintCmd.Execute(new Document() { Text = "test" });
        }
    }

    //Command Pattern: Create a command for an operation and can be called multiple places.
    //For ex: Create Print command, that can be called for a button click or a menu click

    interface ICommand
    {
        string Name { get; set; }
        //it can have image and shotcut properties too
        void Execute(Document document);
    }

    class Document
    {
        public string Text { get; set; }
    }

    class ConsolePrintCommand : ICommand
    {
        public string Name { get; set; }
        public ConsolePrintCommand()
        {
            Name = "Console Print";
        }
        public void Execute(Document document)
        {
            Console.WriteLine(Name + " command " + document.Text);
        }
    }


    class PaperPrintCommand : ICommand
    {
        public string Name { get; set; }
        public PaperPrintCommand()
        {
            Name = "Paper Print";
        }
        public void Execute(Document document)
        {
            Console.WriteLine(Name + " command " + document.Text);
        }
    }

}
