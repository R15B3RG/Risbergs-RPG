using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using Risbergs_RPG.Player;

namespace Risbergs_RPG.Player
{
    public class NewCharacter
    {
        string Name { get; set; }

        string Gender { get; set; }

        public class FighterClass
        {
            private int _hitPoints;

            private int _magicPoints;
            public string Fighter
            {
                get => Fighter;

                set
                {
                    _hitPoints = 50;
                    _magicPoints = 10;
                }
            }

            public string Mage
            {
                get => Mage;

                set
                {
                    _hitPoints = 30;
                    _magicPoints = 50;
                }
            }
        }

        public static List<NewCharacter> newPlayerCharacter { get; set; } = new List<NewCharacter>();

        public static List<Option>? options;

        public void Male()
        {

            NewCharacter newCharacter = new NewCharacter();

            Gender = "Male";

            string nameQuestion = "What is your name?";

            foreach (var letters in nameQuestion)
            {
                Console.Write(letters);
                Thread.Sleep(100);
            }
            Console.WriteLine();

            string WriteName = Console.ReadLine();

            Name = WriteName;

            string greeting = $"Hello {Name}! What is your class of choice?";

            foreach (var letters in greeting)
            {
                Console.Write(letters);
                Thread.Sleep(100);
            }
            Console.WriteLine();

            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Fighter", () =>
                {
                    new FighterClass(newCharacter).Fighter

                    newPlayerCharacter.Add(newCharacter);

                    Choice();
                }),
                new Option("Mage", () =>
                {
                    Class = new Class().Mage;

                    newPlayerCharacter.Add(newCharacter);

                    Choice();
                })
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


            // Default action of all the options. You can create more methods
            static void WriteTemporaryMessage(string message)
            {
                Console.Clear();
                Console.WriteLine(message);
                Thread.Sleep(3000);
                WriteMenu(options, options.First());
            }



            static void WriteMenu(List<Option>? options, Option selectedOption)
            {

                Console.WriteLine();

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

        public void Female()
        {
            NewCharacter newCharacter = new NewCharacter();

            Gender = "Female";

            string WriteName = Console.ReadLine();

            Name = WriteName;

            string greeting = $"Hello {Name}! What is your class of choice?";

            foreach (var letters in greeting)
            {
                Console.Write(letters);
                Thread.Sleep(100);
            }

            Console.WriteLine();

            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Fighter", () =>
                {
                    Class = new Class().Fighter;

                    newPlayerCharacter.Add(newCharacter);
                }),
                new Option("Mage", () =>
                {
                    Class = new Class().Mage;

                    newPlayerCharacter.Add(newCharacter);
                })
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


            // Default action of all the options. You can create more methods
            static void WriteTemporaryMessage(string message)
            {
                Console.Clear();
                Console.WriteLine(message);
                Thread.Sleep(3000);
                WriteMenu(options, options.First());
            }



            static void WriteMenu(List<Option>? options, Option selectedOption)
            {

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

        public void Choice()
        {

            options = new List<Option>
            {
                new Option("Yes", () =>
                {
                    Class = new Class().Fighter;
                }),
                new Option("No", () =>
                {
                    Class = new Class().Mage;
                })
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


            // Default action of all the options. You can create more methods
            static void WriteTemporaryMessage(string message)
            {
                Console.Clear();
                Console.WriteLine(message);
                Thread.Sleep(3000);
                WriteMenu(options, options.First());
            }



            static void WriteMenu(List<Option>? options, Option selectedOption)
            {

                foreach (var character in newPlayerCharacter)
                {
                    Console.WriteLine(character);
                }

               

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


}




