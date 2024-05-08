
using ConsoleApp;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;
using Risbergs_RPG.Player;

namespace Risbergs_RPG
{
    class Program
    {

        static Intro intro = new Intro();

        private static NewCharacter _newCharacter = new NewCharacter();

        public static List<Option> options;
        static void Main(string[] args)
        {
            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("New Game", () => {
                    intro.DisplayIntro(); 
                }),
                new Option("Exit", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
        // Default action of all the options. You can create more methods
        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            WriteMenu(options, options.First());
        }



        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            Console.WriteLine("Welcome TO:\n");

            Console.WriteLine("__, _  _, __, __, __,  _,  _,   __, __,  _,");
            Console.WriteLine("|_) | (_  |_) |_  |_) / _ (_    |_) |_) / _");
            Console.WriteLine("| \\ | , ) |_) |__ | \\ \\ / , )   | \\ |   \\ /");
            Console.WriteLine("~ ~ ~  ~  ~   ~~~ ~ ~  ~   ~    ~ ~ ~    ~\n");

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("--> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }

}