using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class InterpreterPattern
    {
        public static void Test()
        {
            List<Language> languages = new List<Language>();
            languages.Add(new Tamil());
            languages.Add(new Hindi());

            foreach (var language in languages)
            {
                language.Interpret("Good Morning");
            }
        }
    }

    //Interpreter Pattern - Change one representation to another representation
    //For Example: Language parser, Regular Expression

    abstract class Language
    {
        public abstract void Interpret(string english);
    }

    class Tamil : Language
    {
        public override void Interpret(string english)
        {
            if (english == "Good Morning")
            {
                Console.WriteLine("Vanakkam");
            }
        }
    }

    class Hindi : Language
    {
        public override void Interpret(string english)
        {
            if (english == "Good Morning")
            {
                Console.WriteLine("Namasthe");
            }
        }
    }
}
