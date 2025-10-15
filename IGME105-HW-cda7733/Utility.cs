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
 * 10/15/2025 - added a switch case block to trigger space events
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
            playerX.PlayerLocation[playerX.PlayerIndex] = playerX.PlayerLocation[playerX.PlayerIndex] + diceRoll;
            Console.WriteLine("{0} rolled a {1}! they are now on {2}.\n", playerX.PlayerName, diceRoll, Spaces.DisplayPropertyName(diceRoll));
            switch (playerX.PlayerLocation[playerX.PlayerIndex])
            {
                case 0: Spaces.GoSpace(); break;
                case 1: Spaces.PropertySpace(); break;
                case 2: Console.WriteLine("you've landed on a community chest space!"); break;
                case 3: Spaces.PropertySpace(); break;
                case 4: Spaces.TaxSpace(GameSetup.RNG); break;
                case 5: 
                case 6: Spaces.PropertySpace(); break;
                case 7: Console.WriteLine("you've landed on a chance space!"); break;
                case 8: 
                case 9: Spaces.PropertySpace(); break;
                case 10: Spaces.VandalismSpace(); break;
                case 11: Spaces.PropertySpace(); break;
                case 12: Spaces.UtilitySpace(GameSetup.RNG); break;
                case 13:
                case 14:
                case 15: 
                case 16: Spaces.PropertySpace(); break;
                case 17: Console.WriteLine("you've landed on a community chest space!"); break;
                case 18: 
                case 19: Spaces.PropertySpace(); break;
                case 20: Console.WriteLine("you've landed on a free repair space!"); break;
                case 21: Spaces.PropertySpace(); break;
                case 22: Console.WriteLine("you've landed on a chance space!"); break;
                case 23:
                case 24:
                case 25: 
                case 26:
                case 27: Spaces.PropertySpace(); break;
                case 28: Spaces.UtilitySpace(GameSetup.RNG); break;
                case 29: Spaces.PropertySpace(); break;
                case 30: Spaces.VandalismSpace(); break;
                case 31: 
                case 32: Spaces.PropertySpace(); break;
                case 33: Console.WriteLine("you've landed on a community chest space!"); break;
                case 34:
                case 35: Spaces.PropertySpace(); break;
                case 36: Console.WriteLine("you've landed on a chance space!"); break;
                case 37: Spaces.PropertySpace(); break;
                case 38: Spaces.TaxSpace(GameSetup.RNG); break;
                case 39: Spaces.PropertySpace(); break;
                default: break;
            }
        }
        internal static void RollForFirstProperty()
        {
            int diceRoll = GameSetup.RNG.Next(0,5);
            Console.WriteLine($"you get the {diceRoll + 1}st/nd/rd/th property");
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