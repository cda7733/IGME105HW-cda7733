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
 * 10/10/2025 - added roll for movement & first property
 */

namespace IGME105_HW_cda7733
{
    internal class Utility
    {
        // variables & properties
        
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
        internal static void RollForMovement(Player playerX)
        {
            Console.WriteLine($"it is {playerX.PlayerName}'s turn.");
            int diceRoll = GameSetup.RNG.Next(2,13);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0} rolled a {1}! they are now on space number {2}.\n", playerX.PlayerName, diceRoll, 1 + diceRoll);
            Console.ResetColor();
        }
        internal static void RollForFirstProperty()
        {
            int diceRoll = GameSetup.RNG.Next(0,5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"you get the {diceRoll + 1}st/nd/rd/th property");
            Console.ResetColor();
        }
        internal static void CyclePlayerIndex(string option, Player playerX, int currentMaxPlayers)
        {
            // 0 is previous, 1 is next
            if (option == "increase")
            {
                if (playerX.PlayerIndex < currentMaxPlayers)
                {
                    playerX.PlayerIndex++;
                }
                else
                {
                    playerX.PlayerIndex = 0;
                }
            }
            else if (option == "decrease")
            {
                if (playerX.PlayerIndex < currentMaxPlayers)
                {
                    playerX.PlayerIndex++;
                }
                else
                {
                    playerX.PlayerIndex = 0;
                }
            }
        }
        internal static void ColorPicker (int colorIndex)
        {

            switch (colorIndex)
            {

                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    break;
            }
        }
        internal static void IndividualVandalism()
        {
            // battle method between players
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("a 1v1 vandalism battle is occuring!\n");
            Console.ResetColor();
        }
        internal static void GroupVandalism()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("a free-for-all vandalism event has been triggered!\n");
            Console.ResetColor();
        }
        internal static void PropertyLanding(Player playerX)
        {
            ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine($"{playerX.PlayerName} landed on a property space!\n");
            Console.ResetColor();
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
    }
}