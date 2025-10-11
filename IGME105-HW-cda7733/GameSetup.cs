using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal class GameSetup
    {
        static Random rng = new Random();
        internal static Random RNG
        {
            get { return rng; }
            set { rng = value; }
        }
        const int minPlayers = 2;
        internal int MinPlayers
        {
            get { return minPlayers; }
        }

        const int maxPlayers = 4;
        internal int MaxPlayers
        {
            get { return maxPlayers; }
        }
        const int maxSpaces = 40;
        internal int MaxSpaces
        {
            get { return maxSpaces; }
        }

        const string gameName = "battle monopoly: capitalist punishment";
        internal string GameName
        {
            get { return gameName; }
        }
        internal static void Startup()
        {
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"welcome to {gameName}!\n");
                Console.Write("would you like to view the rules? (y/n): ");
                string input1 = Console.ReadLine().Trim().ToLower();
                if (input1.StartsWith("y"))
                {
                    GameSetup.DisplayRules();
                }
                else if (input1.StartsWith("n"))
                {

                }
                else
                {
                    Console.WriteLine("invalid answer, try again!\n");
                    continue;
                }
                Console.Write("\nhow many people will be playing today? ");
                string input2 = Console.ReadLine().Trim();
                try
                {
                    Convert.ToInt32(input2);
                    if (Convert.ToInt32(input2) < 2 || Convert.ToInt32(input2) > 4)
                    {
                        Console.WriteLine($"the number of players chosen is out of range({minPlayers}-{maxPlayers}), try again.\n");
                    }
                    else
                    {
                        done = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("input was not a valid number, try again.\n");
                }
            }
            Console.Clear();
        }

        internal static void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n{0} has {1} spaces and supports {2}-{3} players.", gameName, maxSpaces, minPlayers, maxPlayers);
            Console.WriteLine("player order is the same order as registration.");
            Console.WriteLine("players may have the same name, but never the same token or console color."); // barriers not yet coded in
            Console.WriteLine($"movement in {gameName} is the same as base monopoly, rolling two 6-sided die, and moving that many spaces.");
            Console.WriteLine("in this version of the game, there is no money, or even \'health\' for cards.\ninstead, this game uses property value and vandalism damage!");
            Console.WriteLine("players can attack others in a 1v1, or trigger events for battle between everyone.");
            Console.WriteLine("battle/vandalism is done with property cards, which are collected from unowned property spaces.");
            Console.WriteLine("property cards have stats: color, property value, damage multiplier, house upgrade value, and hotel upgrade value.");
            Console.WriteLine("damage to other players property is calculated as a diceroll x damage multiplier.");
            Console.WriteLine("if an UNOWNED card's property value is reduced to 0, the player who defeated it gets the card.");
            Console.WriteLine("once an OWNED card's property value is reduced to 0, that card becomes out of play for the whole game.");
            Console.WriteLine("you can gain/lose property value from chance cards, community chest cards, tax spaces, and utility spaces.");
            Console.ResetColor();
        }
    }
}
