using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal class GameEngine
    {
        internal void PlayerAction(Player playerX)
        {
            bool done = false;
            bool rolled = false;
            bool attacked = false;
            while (!done && Utility.GameOver == false)
            {
                Console.WriteLine($"what would {playerX.PlayerName} like to do?");

                if (rolled == false)
                {
                    Console.WriteLine("0. roll\n1. view cards\n2. check space\n3. open menu\n4. trade");
                }
                else
                {
                    // removes the option to roll again
                    Console.WriteLine("0. end turn\n1. view cards\n2. check space\n3. open menu\n4. trade");
                }
                string input = Console.ReadLine().Trim().ToLower();
                Console.Clear();

                if (rolled == false || attacked == false)
                {
                    switch (input)
                    {
                        case "0": RollForMovement(playerX); rolled = true; break;
                        case "1": Utility.DisplayHeldCards(playerX); break;
                        case "2": Console.WriteLine($"{playerX.PlayerName} is currently on a {Utility.TranslateSpaceType(playerX.OnSpaceType)} space."); 
                            CheckUnownedProperty(playerX); break;
                        case "3": Menu(playerX); break;
                        case "4": Console.WriteLine("this is where the trade menu will be!\n"); break;
                        default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                    }
                }
                else if (rolled == false && attacked == false)
                {
                    // removes the option to roll again
                    switch (input)
                    {
                        case "0": done = true; break;
                        case "1": Utility.DisplayHeldCards(playerX); break;
                        case "2": Console.WriteLine($"{playerX.PlayerName} is currently on a {Utility.TranslateSpaceType(playerX.OnSpaceType)} space.\n");
                            CheckUnownedProperty(playerX); break;
                        case "3": Menu(playerX); break;
                        case "4": Console.WriteLine("this is where the trade menu will be!\n"); break;
                        default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                    }
                }
                
            }
        }
        internal static void Menu(Player playerX)
        {
            bool done = false;
            while (!done && Utility.GameOver == false)
            {
                Console.WriteLine("\n0. resume\n1. view player info\n2. rulebook\n3. quit");
                string input = Console.ReadLine().Trim().ToLower();
                Console.Clear();
                switch (input)
                {
                    case "0": done = true; break;
                    case "1": playerX.DisplayPlayerInfo(); break;
                    case "2": GameSetup.DisplayRules(); break;
                    case "3": Utility.GameOver = true; break;
                    default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                }
            }
        }
        internal void RollForMovement(Player playerX)
        {
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine($"it is {playerX.PlayerName}'s turn.\n");
            Console.ResetColor();
            int diceRoll = Utility.RNG.Next(2, 13);
            playerX.PlayerLocation = playerX.PlayerLocation + diceRoll;
            Utility.CyclePlayerLocation(playerX);
            Console.WriteLine("{0} rolled a {1}! they are now on {2}, space number {3}\n", playerX.PlayerName, diceRoll, Spaces.SpaceArrayToName(playerX), playerX.PlayerLocation);
            Utility.SpaceAction(playerX);
            playerX.TurnCount++;
        }
        internal static void CheckUnownedProperty(Player playerX)
        {
            if (playerX.OnSpaceType == "UP")
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine("pretend im displaying specific property info.\ncurrent health. dice multiplier.");
                    Console.WriteLine($"will {playerX.PlayerName} damage this property? this will end your turn (y/n): ");
                    string input = Console.ReadLine().Trim().ToLower();
                    if (input.StartsWith("y"))
                    {

                        Console.WriteLine(Utility.RNG.Next(2,13));
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
        }
        internal void Sabotage()
        {
            // battle method between players
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("a 1v1 sabotage event is occuring!\n");
            Console.ResetColor();
        }
        internal static int PullChanceCard(Player playerX)
        {
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine("they drew a chance card!");
            Console.ResetColor();
            int cardIndex = Utility.RNG.Next(1, Utility.CardQuantity);
            string currentCardTitle;
            if (String.IsNullOrEmpty(playerX.DrawnCards))
            {
                playerX.DrawnCards = playerX.DrawnCards + "chance" + cardIndex;
            }
            else
            {
                playerX.DrawnCards = playerX.DrawnCards + ",chance" + cardIndex;
            }
            currentCardTitle = "chance" + cardIndex;
            Console.WriteLine($"it says: {Utility.TranslateCard(currentCardTitle)}\n");
            return cardIndex;
        }
        internal static int PullCommunityChestCard(Player playerX)
        {
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine("they drew a community chest card!");
            Console.ResetColor();
            int cardIndex = Utility.RNG.Next(1, Utility.CardQuantity);
            string currentCardTitle;
            if (String.IsNullOrEmpty(playerX.DrawnCards))
            {
                playerX.DrawnCards = playerX.DrawnCards + "chest" + cardIndex;
            }
            else
            {
                playerX.DrawnCards = playerX.DrawnCards + ",chest" + cardIndex;
            }
            currentCardTitle = "chest" + cardIndex;
            Console.WriteLine($"it says: {Utility.TranslateCard(currentCardTitle)}\n");
            return cardIndex;
        }
    }
}
