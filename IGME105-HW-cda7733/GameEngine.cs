using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 * program name: IGME105 monopoly game
 * created by: charisma allen
 * purpose: make monopoly more fun by making it a card battler
 * 
 * 10/30/2025 - changed the if statements in PullChance(..), PullChest(..), and PlayerAction(..) to a ternary
 * 11/05/2025 - fixed methods to handle cards and properties as lists rather than arrays
 */

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
                // just landed vs rolled but hasn't attacked
                string choices = (rolled == false) ? "0. roll\n1. held cards\n2. owned properties\n3. check space\n4. open menu\n5. trade" :
                    "0. end turn\n1. held cards\n2. owned properties\n3. check space\n4. open menu\n5. trade";
                Console.WriteLine(choices);
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
                        playerX.OnSpaceType = Spaces.SpaceType[playerX.PlayerLocation]; 
                        Console.WriteLine($"{playerX.PlayerName} is currently on {Spaces.SpaceNameArray[playerX.PlayerLocation]}, a {Utility.TranslateSpaceType(playerX,Utility.SpaceTypes)} space.\n");
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
                    Console.WriteLine("0. assassinate this player");
                    Console.WriteLine();
                    string selection = Console.ReadLine().Trim().ToLower();
                    switch (selection)
                    {
                        case "0": Console.Clear(); KillPlayer(playerX); done = true; break;
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
                        if (input.StartsWith("y"))
                        {
                            Console.Clear();
                            int damage = 0;
                            for (int i = 0; i < playerX.Dice; i++)
                            {
                                damage += Utility.RNG.Next(1,7);
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
                            Console.Clear();
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
            string currentCardTitle = "chance" + cardIndex;
            playerX.DrawnCards.Add(currentCardTitle);
            Console.WriteLine($"it says: {Utility.TranslateCard(currentCardTitle)}\n");
            return cardIndex;
        }
        internal static int PullCommunityChestCard(Player playerX)
        {
            // gives player a chance card, displays the text on it, and adds it to their inventory/bag/card stack
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine("they drew a community chest card!");
            Console.ResetColor();
            int cardIndex = Utility.RNG.Next(1, Utility.CardQuantity);
            string currentCardTitle = "chest" + cardIndex;
            playerX.DrawnCards.Add(currentCardTitle);
            Console.WriteLine($"it says: {Utility.TranslateCard(currentCardTitle)}\n");
            return cardIndex;
        }
        internal static void GameplayLoop(List<Player> players)
        {
            foreach (Player player in players)
            {
                CheckWin(players);
                PlayerAction(player);
                if (Utility.GameOver) return;
            }
            players.RemoveAll(player => !player.Active);
        }
        internal static void CheckWin(List<Player> players)
        {
            // checks if there is only one player, then the game ends. displays winner info between 2 players
            if (players.Count == 1)
            {
                Utility.ColorPicker(players[0].PlayerColorIndex);
                Console.WriteLine($"congratualations to player 1 for winning the game!");
                Console.ResetColor();
                Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", players[0].PlayerName, players[0].TurnCount, players[0].DrawnCards.Count, players[0].OwnedProperties.Count);
                Console.WriteLine("\nthank you for playing!\n\n");
                Utility.GameOver = true;
            }
            else if (players.Count <= 0)
            {
                Utility.DisplayError("game crashed because everyone died");
            }
        }
        internal static void KillPlayer(Player playerX)
        {
            // deactivates a player, returns their properties to the board, decreases current # of players
            Utility.CurrentNumberOfPlayers--;
            // Console.Clear();
            Utility.ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine(playerX.PlayerName + " has bankrupted! they are no longer in the game!\n");
            Console.ResetColor();
            if (Utility.CurrentNumberOfPlayers >= 2)
            {
                Console.WriteLine($"good luck to the remaining {Utility.CurrentNumberOfPlayers} players!\n");
                /*
                string[] propertyArray = playerX.OwnedProperties.Split(',');
                for (int i = 0; i < propertyArray.Length; i++)
                {
                    // this needs to be a for loop instead of foreach bc i need to track index
                    if (!string.IsNullOrWhiteSpace(propertyArray[i]))
                    {
                        index = int.Parse(propertyArray[i].TrimStart('0'));
                        PropertyCard.Owned[index] = false;
                        PropertyCard.ChangeToUnowned(playerX, i);
                        playerX.OwnedPropertyCount--;
                        Console.WriteLine(Spaces.SpaceNameArray[index] + " has been added back to the board");
                    }
                }*/
                int index;
                foreach (string property in playerX.OwnedProperties)
                {
                    index = int.Parse(property.TrimStart('0'));
                    PropertyCard.Owned[index] = false;
                    PropertyCard.ChangeToUnowned(playerX, index);
                    Console.WriteLine(Spaces.SpaceNameArray[index] + " has been added back to the board");
                }

                Console.WriteLine();
                
                playerX.OwnedProperties.Clear();
                playerX.DrawnCards.Clear();
            }
            playerX.Active = false;
        }
    }
}