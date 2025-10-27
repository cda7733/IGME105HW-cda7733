using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 * program name: IGME105 monopoly game
 * created by: charisma allen
 * purpose: make monopoly more fun by making it a card battler
 * 
 * 10/15/2025 - very slightly tweaked rules + header
 */

namespace IGME105_HW_cda7733
{
    internal static class GameSetup
    {
        const int minPlayers = 2;
        internal static int MinPlayers
        {
            get { return minPlayers; }
        }

        const int maxPlayers = 4;
        internal static int MaxPlayers
        {
            get { return maxPlayers; }
        }
        static int currentMaxPlayers;
        internal static int CurrentMaxPlayers
        {
            get { return currentMaxPlayers; }
            set { currentMaxPlayers = value; }
            
        }
        const int maxSpaces = 40;
        internal static int MaxSpaces
        {
            get { return maxSpaces; }
        }

        const string gameName = "battle monopoly: capitalist punishment";
        internal static string GameName
        {
            get { return gameName; }
        }
        internal static void Startup()
        {
            // display rules, get game info
            PromptRules();
            PromptMaxPlayers();

        }
        internal static void DisplayAvailableColors()
        {
            // displays colors availablee for player text
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. red");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. orange");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. yellow");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3. cyan");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("4. blue");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("5. purple");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("6. pink");
            Console.ResetColor();
        }
        internal static void DisplayRules()
        {
            // displays rules with colored headers
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nGENERAL INFO:"); Console.ResetColor();
            Console.WriteLine("{0} has {1} spaces and supports {2}-{3} players. turn order follows the order of creation.", gameName, maxSpaces, minPlayers, maxPlayers);
            Console.WriteLine("players may have the same name, token or console color, though this is ill advised."); // barriers not yet coded in
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCHANGES / DIFFERENCES"); Console.ResetColor();
            Console.WriteLine($"board movement is the same as base monopoly, rolling two 6-sided die, and moving that many spaces, not counting the one you're on.");
            Console.WriteLine("in this version of the game, there is no money, or even \'health\' for cards.\ninstead, this game uses property value and vandalism damage!");
            Console.WriteLine("humans and ai players can be created to play with");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nBATTLE"); Console.ResetColor();
            Console.WriteLine("players can attack others in a 1v1, or trigger events for battle between everyone.");
            Console.WriteLine("battle/vandalism is done with property cards, which are collected from unowned property spaces.");
            Console.WriteLine("property cards have stats: color, property value, damage multiplier, house upgrade value, and hotel upgrade value.");
            Console.WriteLine("damage to other players property is calculated as (diceroll x damage multiplier).");
            Console.WriteLine("if ANY (owned/unowned) property card's value is reduced to 0, the player who defeated it gets the card.");
            Console.WriteLine("players can gain/lose property value from chance cards, community chest cards, tax spaces, and utility spaces.");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nDEMO INFO (you can just read this)"); Console.ResetColor();
            Console.WriteLine("this current iteration does not have AI players yet, nor battle between players or a trade menu");
            Console.WriteLine("WIN CONDITION: everyone else dies. player health is nerfed to facilitate this.\nplayers can only take damage from tax spaces.");
            Console.WriteLine("to make testing easier, there is a cheat menu which allows you to eliminate players");

        }
        internal static void PromptMaxPlayers()
        {
            // ask how many will be playing and set it to current players
            bool done = false;
            while (!done)
            {
                Console.Write("\nhow many people will be playing today? ");
                string input = Console.ReadLine().Trim();
                try
                {
                    int players = int.Parse(input);
                    if (players < 2 || players > 4)
                    {
                        Utility.DisplayError($"the number of players chosen is out of range({minPlayers}-{maxPlayers}), try again.\n");
                    }
                    else
                    {
                        CurrentMaxPlayers = players;
                        Utility.CurrentNumberOfPlayers = players;
                        done = true;
                    }
                }
                catch (Exception)
                {
                    Utility.DisplayError("input was not a valid number, try again.\n");
                }
            }
        }
        internal static void PromptRules()
        {
            // ask if rules should be displayed
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"welcome to {gameName}!\n");
                Console.Write("would you like to view the rules? (y/n): ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input.StartsWith("y"))
                {
                    DisplayRules();
                    done = true;
                }
                else if (input.StartsWith("n"))
                {
                    done = true;
                }
                else
                {
                    Utility.DisplayError("invalid input! please enter a 'y' or an 'n'");
                }
            }
        }
        internal static bool VerifyGivenInfo(Player playerX)
        {
            Console.Clear();
            string input;
            bool done = false;
            bool correct = false;
            Console.WriteLine("is this information correct?");
            playerX.DisplaySimplePlayerInfo();
            Console.WriteLine("\n(y/n): ");
            while (!done)
            {
                input = Console.ReadLine().Trim().ToLower();
                if (input.StartsWith("y"))
                {
                    correct = true;
                    done = true;
                }
                else if (input.StartsWith("n"))
                {
                    playerX.PlayerName = "";
                    correct = false;
                    done = true;
                }
                else
                {
                    Utility.DisplayError("invalid input! please enter a 'y' or an 'n'");
                }
            }
            return correct;
        }
        internal static void CreatePlayers(List<Player> players)
        {
            for (int i = 0; i < CurrentMaxPlayers; i++)
            {
                players.Add(new Player());
                players[i].Active = true;
                bool complete = false;
                while (!complete)
                {
                    players[i].PlayerIndex = i;
                    players[i].PromptName();
                    players[i].PromptToken();
                    players[i].PromptColor();
                    complete = VerifyGivenInfo(players[i]);
                    PropertyCard.AcquirePropertyCard(i + 1, players[i]);
                    Console.Clear();
                }
            }
        }
    }
}
