using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * program name: IGME105 monopoly game
 * created by: charisma allen
 * purpose: make monopoly more fun by making it a card battler
 * 
 * 09/18/2025 - created a new repo and project because my other one was busted
 * 09/19/2025 - created, copied comments from architecture, then changed to code for HW3
 * 09/26/2025 - gave variables properties, all methods do somethingg
 */

namespace IGME105_HW_cda7733
{
    internal class Utility
    {
        // variables & properties
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

        const string gameName = "battle monopoly: vandalism edition";
        internal string GameName
        {
            get {  return gameName; }
        }
        int currentNumberOfPlayers;
        internal int CurrentNumberOfPlayers
        {
            get { return currentNumberOfPlayers; }
            set { currentNumberOfPlayers = value; }
        }
        int currentPlayerIndex = 0;
        internal int CurrentPlayerIndex
        {
            get { return currentPlayerIndex; }
            set { currentPlayerIndex = value; }
        }

        // methods
        internal static void Welcome()
        {
            Console.WriteLine($"welcome to {gameName}!\n");
        }
        internal static int RNG(int minRoll, int maxRoll)
        {
            // usually generate random number 2-12.
            // taking parameters incase the number of cards changes, or i want to use RNG for another event
            int rolledValue = maxRoll;
            return rolledValue;
        }
        internal static void RollForMovement(Player playerX)
        {
            Console.WriteLine($"it is {playerX.PlayerName}'s turn.");
            int roll = RNG(2,12);
            Console.WriteLine("{0} rolled a {1}! they are now on space number {2}.\n", playerX.PlayerName, roll, 6);
        }

        internal static void IndividualVandalism()
        {
            // battle method between players
            Console.WriteLine("a 1v1 vandalism battle is occuring!\n");
        }

        internal static void GroupVandalism()
        {
            Console.WriteLine("a free-for-all vandalism event has been triggered!\n");
        }
        
        internal static void PropertyLanding(string playerName)
        {
            Console.WriteLine($"{playerName} landed on a property space!\n");
            /*
             * if ownershipStatus = 0, int cost = PropertyCost[i] 
                // cost regards not money, but how much damage a space can take before being acquired by a player
                    players do not have to attack the property
                    if they want the property, then Buy() method occurs
                        they do damage to the property and try to bring it to 0
                if ownershipStatus > 0, initiate Sabotage() between currentPlayer and player x
                    check if currentPlayer + 1 == ownershipStatus, so that they don’t sabotage/start combat with themselves
                        + 1 because indexing starts at 0
                            i think, maybe 
             */
        }
        internal static void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
        internal static void GameSetup()
        {
            bool done = false;
            while (done == false)
            {
                Console.Write("would you like to view the rules? (y/n): ");
                string input1 = Console.ReadLine().Trim().ToLower();
                if (input1.StartsWith("y"))
                {
                    DisplayRules();
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
        }
    }
}
