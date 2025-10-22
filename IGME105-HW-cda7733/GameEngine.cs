using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal class GameEngine
    {
        internal void PlayerAction(Player playerX)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("what would you like to do?");
                Console.WriteLine("0. roll\n1. view cards\n2. open menu\n3. trade");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0": RollForMovement(playerX); done = true; break;
                    case "1": Console.WriteLine(""); done = true; break;
                    case "2": Console.WriteLine(input); done = true; break;
                    case "3": Console.WriteLine("this is where the trade menu will be!"); done = true; break;
                    default: Console.WriteLine("invalid input. please enter one of the listed numbers."); break;
                }
            }
            
        }
        internal void RollForMovement(Player playerX)
        {
            Console.WriteLine($"it is {playerX.PlayerName}'s turn.");
            int diceRoll = GameSetup.RNG.Next(2, 13);
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
        internal void IndividualVandalism()
        {
            // battle method between players
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("a 1v1 vandalism battle is occuring!\n");
            Console.ResetColor();
        }
        internal void PropertyLanding(Player playerX)
        {
            Utility.ColorPicker(playerX.PlayerColorIndex);
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
