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
            // display rules, get game info, create players..?
            PromptRules();
            PromptMaxPlayers();

            /* for (int i = 1; i < Utility.CurrentNumberOfPlayers; i++)
            {

            } */

        }
        internal static void CreatePlayers(Player player1, Player player2)
        {
            player1.Active = true;
            player1.PlayerIndex = 0;
            player1.PromptName();
            player1.PromptToken();
            player1.PromptColor();
            PropertyCard.AcquirePropertyCard(1, player1);
            

            player2.Active = true;
            player2.PlayerIndex = 1;
            player2.PromptName();
            player2.PromptToken();
            player2.PromptColor();
            PropertyCard.AcquirePropertyCard(2, player2);
        }
        internal static void CreatePlayers(Player player1, Player player2, Player player3)
        {
            player1.Active = true;
            player1.PlayerIndex = 0;
            player1.PromptName();
            player1.PromptToken();
            player1.PromptColor();
            PropertyCard.AcquirePropertyCard(1, player1);

            player2.Active = true;
            player2.PlayerIndex = 1;
            player2.PromptName();
            player2.PromptToken();
            player2.PromptColor();
            PropertyCard.AcquirePropertyCard(2, player2);

            player3.Active = true;
            player3.PlayerIndex = 2;
            player3.PromptName();
            player3.PromptToken();
            player3.PromptColor();
            PropertyCard.AcquirePropertyCard(3, player3);
        }
        internal static void CreatePlayers(Player player1, Player player2, Player player3, Player player4)
        {
            player1.Active = true;
            player1.PlayerIndex = 0;
            player1.PromptName();
            player1.PromptToken();
            player1.PromptColor();
            PropertyCard.AcquirePropertyCard(1, player1);

            player2.Active = true;
            player2.PlayerIndex = 1;
            player2.PromptName();
            player2.PromptToken();
            player2.PromptColor();
            PropertyCard.AcquirePropertyCard(2, player2);

            player3.Active = true;
            player3.PlayerIndex = 2;
            player3.PromptName();
            player3.PromptToken();
            player3.PromptColor();
            PropertyCard.AcquirePropertyCard(3, player3);

            player4.Active = true;
            player4.PlayerIndex = 3;
            player4.PromptName();
            player4.PromptToken();
            player4.PromptColor();
            PropertyCard.AcquirePropertyCard(4, player4);
        }
        internal static void DisplayRules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nGENERAL INFO:"); Console.ResetColor();
            Console.WriteLine("{0} has {1} spaces and supports {2}-{3} players. turn order follows the order of creation.", gameName, maxSpaces, minPlayers, maxPlayers);
            Console.WriteLine("players may have the same name, token or console color, though this is ill advised."); // barriers not yet coded in
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nCHANGES / DIFFERENCES"); Console.ResetColor();
            Console.WriteLine($"board movement is the same as base monopoly, rolling two 6-sided die, and moving that many spaces, not counting the one you're on.");
            Console.WriteLine("in this version of the game, there is no money, or even \'health\' for cards.\ninstead, this game uses property value and vandalism damage!");
            Console.WriteLine("humans and ai players can be created to play with (this current iteration does not have AI players yet)");
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\nBATTLE"); Console.ResetColor();
            Console.WriteLine("players can attack others in a 1v1, or trigger events for battle between everyone.");
            Console.WriteLine("battle/vandalism is done with property cards, which are collected from unowned property spaces.");
            Console.WriteLine("property cards have stats: color, property value, damage multiplier, house upgrade value, and hotel upgrade value.");
            Console.WriteLine("damage to other players property is calculated as (diceroll x damage multiplier).");
            Console.WriteLine("if ANY (owned/unowned) property card's value is reduced to 0, the player who defeated it gets the card.");
            Console.WriteLine("players can gain/lose property value from chance cards, community chest cards, tax spaces, and utility spaces.");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\nDEMO INFO (you can just read this)"); Console.ResetColor();
            Console.WriteLine("property value of all cards is set to 5 for easier testing.\nplayer health is also maxed at 5 as a result.\n");
        }
        internal static void PromptMaxPlayers()
        {
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
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"welcome to {gameName}!\n");
                Console.Write("it is recommended for you to read the rules. would you like to? (y/n): ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input.StartsWith("y"))
                {
                    GameSetup.DisplayRules();
                    done = true;
                }
                else if (input.StartsWith("n"))
                {
                    done = true;
                }
                else
                {
                    Utility.DisplayError("invalid answer, try again!\n");
                }
            }
        }
        internal static void DetermineCreationAmount(Player player1, Player player2, Player player3, Player player4)
        {
            switch (Utility.CurrentNumberOfPlayers)
            {
                case 2: CreatePlayers(player1, player2); break;
                case 3: CreatePlayers(player1, player2, player3); break;
                case 4: CreatePlayers(player1, player2, player3, player4); break;
                default: break;
            }
        }
    }
}
