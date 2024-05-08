using System.Threading.Channels;
using ConsoleApp;
using Microsoft.VisualBasic.FileIO;
using Risbergs_RPG.Player;


namespace Risbergs_RPG;

public class Intro
{

    public void DisplayIntro()
    {
	    Console.Clear();
	    string intro = "Welcome brave adventurer! Before you lies your quest, please create your character:";

	    foreach (var letters in intro)
	    {
		    Console.Write(letters);
		    Thread.Sleep(100);
	    }

	    Console.WriteLine();

		Character();

    }


    public static List<Option>? options;
	static void Character()
	{
		// Create options that you want your menu to have
		options = new List<Option>
			{
				new Option("Male", () =>
                {
                    new NewCharacter().Male();
                }),
				new Option("Female", () =>
                {
					new NewCharacter().Female();
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

	}
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
        Console.Clear();

        Console.WriteLine("Select your gender:\n");

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
