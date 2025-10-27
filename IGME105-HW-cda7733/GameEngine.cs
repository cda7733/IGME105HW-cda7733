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
            // options for player turn
            bool done = false;
            bool rolled = false;
            bool attacked = false;
            while (!done && Utility.GameOver == false)
            {
                if (!playerX.Active) break;
                Utility.ColorPicker(playerX.PlayerColorIndex);
                Console.WriteLine($"it is {playerX.PlayerName}'s turn.");

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
                        Console.WriteLine($"{playerX.PlayerName} is currently on {Spaces.SpaceNameArray[playerX.PlayerLocation]}, a {Utility.TranslateSpaceType(playerX)} space.\n");
                        attacked = CheckUnownedProperty(playerX, attacked); break;
                    case "4": Menu(playerX); break;
                    case "5": Console.WriteLine("this is where the trade menu will be!\n"); break;
                    default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                }
            }
        }
        internal static void Menu(Player playerX)
        {
            // displays options for menu
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
                    case "3": Cheats(playerX); break;
                    case "4": Utility.GameOver = true; break;
                    default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                }
            }
        }

        internal static void Cheats(Player playerX)
        {
            bool done = false;
            Console.WriteLine("enter the password.\n(hint: the password is password)");
            string input = Console.ReadLine().Trim().ToLower();
            Console.Clear();
            if (input == "password")
            {
                while (!done && Utility.GameOver == false)
                {
                    Console.WriteLine("0. kill a player");
                    Console.WriteLine();
                    string selection = Console.ReadLine().Trim().ToLower();
                    switch (selection)
                    {
                        case "0": KillPlayer(playerX); done = true; break;
                        default: break;
                    }
                }
            }
            else
            {
                Utility.DisplayError("access denied.");
            }
        }
        internal static void RollForMovement(Player playerX)
        {
            // rolls "two dice" (2-12) and moves the player to the appropriate location
            int diceRoll = Utility.RNG.Next(2, 13);
            playerX.PlayerLocation = playerX.PlayerLocation + diceRoll;
            Utility.CyclePlayerLocation(playerX);
            playerX.OnSpaceType = Spaces.SpaceType[playerX.PlayerLocation];
            Console.WriteLine("{0} rolled a {1}! they are now on {2}, space number {3}\n", playerX.PlayerName, diceRoll, Spaces.SpaceNameArray[playerX.PlayerLocation], playerX.PlayerLocation);
            playerX.TurnCount++;
            Utility.SpaceAction(playerX);
        }
        internal static bool CheckUnownedProperty(Player playerX, bool attacked)
        {
            // checks if player is on an unowned property, and allows them to attack it if they haven't already
            if (playerX.OnSpaceType == "UP")
            {
                Console.WriteLine(Spaces.SpaceNameArray[playerX.PlayerLocation]);
                Console.WriteLine($"property value: {PropertyCard.CurrentPropertyValue[playerX.PlayerLocation]}/{PropertyCard.MaxPropertyValue[playerX.PlayerLocation]}");
                Console.WriteLine("damage multiplier: " + PropertyCard.DamageMultiplier[playerX.PlayerLocation] + "\n");
                bool done = false;
                while (!done)
                {
                    if (attacked == false)
                    {
                        Console.WriteLine($"will {playerX.PlayerName} damage this property? (y/n): ");
                        string input = Console.ReadLine().Trim().ToLower();
                        Console.Clear();
                        if (input.StartsWith("y"))
                        {
                            
                            int damage = 0;
                            for (int i = 0; i < playerX.Dice; i++)
                            {
                                damage += Utility.RNG.Next(2,13);
                            }
                            Console.WriteLine($"{playerX.PlayerName} did {damage} damage!\n");
                            PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] -= damage;
                            if (PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] <= 0)
                            {
                                PropertyCard.CurrentPropertyValue[playerX.PlayerLocation] = 0;
                                Console.WriteLine($"they acquired {Spaces.SpaceNameArray[playerX.PlayerLocation]}!");
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
                            Utility.DisplayError("invalid input! please enter a 'y' or an 'n'");
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
            // battle between two players
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("a 1v1 sabotage event is occuring!\n");
            Console.ResetColor();
        }
        internal static int PullChanceCard(Player playerX)
        {
            // gives player a chance card, displays the text on it, and adds it to their inventory/bag/card stack
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
            // gives player a chance card, displays the text on it, and adds it to their inventory/bag/card stack
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
        internal static void GameplayLoop(List<Player> players)
        {
            foreach (Player player in players)
            {
                PlayerAction(player);
                CheckWin(players);
                if (Utility.GameOver) return;
            }
        }
        internal static void CheckWin(List<Player> players)
        {
            // checks if there is only one player, then the game ends. displays winner info between 2 players
            if (players.Count <= 1)
            {
                Utility.ColorPicker(players[0].PlayerColorIndex);
                Console.WriteLine($"congratualations to player 1 for winning the game!");
                Console.ResetColor();
                Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", players[0].PlayerName, players[0].TurnCount, players[0].HeldCardCount, players[0].OwnedPropertyCount);
                Console.WriteLine("\nthank you for playing!\n\n");
                Utility.GameOver = true;
            }
        }
        internal static void KillPlayer(Player playerX)
        {
            // deactivates a player, returns their properties to the board, decreases current # of players
            int index;
            Utility.CurrentNumberOfPlayers--;
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine(playerX.PlayerName + " has bankrupted! they are no longer in the game!\n");
            Console.ResetColor();
            if (Utility.CurrentNumberOfPlayers >= 2)
            {
                Console.WriteLine($"good luck to the remaining {Utility.CurrentNumberOfPlayers} players!\n");
                string[] propertyArray = playerX.OwnedProperties.Split(',');
                for (int i = 0; i < propertyArray.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(propertyArray[i]))
                    {
                        index = int.Parse(propertyArray[i].TrimStart('0'));
                        PropertyCard.Owned[index] = false;
                        PropertyCard.ChangeToUnowned(playerX, i);
                        playerX.OwnedPropertyCount--;
                        Console.WriteLine(Spaces.SpaceNameArray[index] + " has been added back to the board");
                    }
                }
                Console.WriteLine();
                playerX.OwnedProperties = "";
                playerX.HeldCardCount = 0;
                playerX.DrawnCards = "";
            }
            playerX.Active = false;
        }
    }
}