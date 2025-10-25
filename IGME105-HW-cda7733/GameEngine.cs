using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal static class GameEngine
    {
        internal static void PlayerAction(Player playerX)
        {
            if (playerX.Active == true)
            {
                bool done = false;
                bool rolled = false;
                bool attacked = false;
                while (!done && Utility.GameOver == false)
                {
                    Utility.CheckWin();
                    Utility.ColorPicker(playerX.PlayerColorIndex);
                    Console.WriteLine($"it is {playerX.PlayerName}'s turn.");
                    if (playerX.Active == false)
                    {
                        Console.WriteLine("their LAST one before they go to heaven");
                    }
                    Console.ResetColor();
                    Console.WriteLine($"what would they like to do?\n");

                    if (rolled == false)
                    {
                        // just landed
                        Console.WriteLine("0. roll\n1. held cards\n2. owned properties\n3. check space\n4. open menu\n5. trade");
                    }
                    else if (rolled == true)
                    {
                        // rolled, but hasn't attacked
                        Console.WriteLine("0. end turn\n1. held cards\n2. owned properties\n3. check space\n4. open menu\n5. trade");
                    }
                    string input = Console.ReadLine().Trim().ToLower();
                    Console.Clear();

                    if (input == "0")
                    {
                        // if they haven't rolled, they can roll
                        if (rolled == false)
                        {
                            RollForMovement(playerX);
                            rolled = true;
                        }
                        else
                        {
                            done = true;
                        }
                    }
                    switch (input)
                    {
                        case "0": break;
                        case "1": Utility.DisplayHeldCards(playerX); break;
                        case "2": Utility.DisplayOwnedProperties(playerX); break;
                        case "3":
                            Console.WriteLine($"{playerX.PlayerName} is currently on a {Utility.TranslateSpaceType(playerX.OnSpaceType)} space.\n");
                            attacked = CheckUnownedProperty(playerX, attacked); break;
                        case "4": Menu(playerX); break;
                        case "5": Console.WriteLine("this is where the trade menu will be!\n"); break;
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
                Console.WriteLine("\n0. resume\n1. view player info\n2. rulebook\n3. cheats\n4. quit");
                string input = Console.ReadLine().Trim().ToLower();
                Console.Clear();
                switch (input)
                {
                    case "0": done = true; break;
                    case "1": playerX.DisplayPlayerInfo(); break;
                    case "2": GameSetup.DisplayRules(); break;
                    case "3": Utility.DisplayError("access denied."); break;
                    case "4": Utility.GameOver = true; break;
                    default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                }
            }
        }

        /* internal static void Cheats(Player playerX)
        {
            bool done = false;
            Console.WriteLine("enter the password.\n(hint: the password is password)");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "password")
            {
                while (!done && Utility.GameOver == false)
                {
                    Console.Clear();
                    Console.WriteLine("0. kill a player");
                    string selection = Console.ReadLine().Trim().ToLower();
                    switch (selection)
                    {
                        case "0": Utility.KillPlayer(); break;
                            default
                    }
                }
            }
            else
            {
                Console.Clear();
                Utility.DisplayError("access denied.");
            }
        }
        */
        internal static void RollForMovement(Player playerX)
        {
            int diceRoll = Utility.RNG.Next(2, 13);
            playerX.PlayerLocation = playerX.PlayerLocation + diceRoll;
            Utility.CyclePlayerLocation(playerX);
            Console.WriteLine("{0} rolled a {1}! they are now on {2}, space number {3}\n", playerX.PlayerName, diceRoll, Spaces.SpaceNameArray[playerX.PlayerLocation], playerX.PlayerLocation);
            Utility.SpaceAction(playerX);
            playerX.TurnCount++;
        }
        internal static bool CheckUnownedProperty(Player playerX, bool attacked)
        {
            if (playerX.OnSpaceType == "UP")
            {
                bool done = false;
                while (!done)
                {
                    Console.WriteLine(Spaces.SpaceNameArray[playerX.PlayerLocation]);
                    Console.WriteLine($"property value: {PropertyCard.CurrentPropertyValue[playerX.PlayerLocation]}/{PropertyCard.MaxPropertyValue[playerX.PlayerLocation]}");
                    Console.WriteLine("damage multiplier: " + PropertyCard.DamageMultiplier[playerX.PlayerLocation] + "\n");
                    if (attacked == false)
                    {
                        Console.WriteLine($"will {playerX.PlayerName} damage this property? (y/n): ");
                        string input = Console.ReadLine().Trim().ToLower();
                        if (input.StartsWith("y"))
                        {
                            Console.Clear();
                            int damage = 0;
                            for (int i = 0; i < playerX.Dice; i++)
                            {
                                damage = Utility.RNG.Next(2,13);
                            }
                            Console.WriteLine($"they did {Utility.RNG.Next(2, 13)} damage!\n");
                            PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] -= damage;
                            if (PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] <= 0)
                            {
                                PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] = 0;
                                Console.WriteLine($"you acquired {Spaces.SpaceNameArray[playerX.PlayerLocation]}!");
                                PropertyCard.AcquirePropertyCard(playerX);
                                Utility.DisplayCardComparison(playerX);
                            } 
                            done = true; attacked = true;  
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
                    else
                    {
                        done = true;
                    }
                }
            }
            return attacked;
        }
        internal static void Sabotage()
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
            playerX.HeldCardCount++;
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
            playerX.HeldCardCount++;
            return cardIndex;
        }
    }
}
