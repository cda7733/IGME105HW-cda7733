using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
    internal static class Utility
    {
        // variables & properties
        static Random rng = new Random();
        internal static Random RNG
        {
            get { return rng; }
            set { rng = value; }
        }
        static bool gameOver = false;
        internal static bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        static int currentNumberOfPlayers;
        internal static int CurrentNumberOfPlayers
        {
            get { return currentNumberOfPlayers; }
            set { currentNumberOfPlayers = value; }
        }
        static int currentPlayerIndex = 0;
        internal static int CurrentPlayerIndex
        {
            get { return currentPlayerIndex; }
            set { currentPlayerIndex = value; }
        }
        static int cardQuantity = 12;
        internal static int CardQuantity
        {
            get { return cardQuantity; }
            set {  cardQuantity = value; }
        }

        internal static void SpaceAction(Player playerX)
        {
            // triggers space methods depending on location
            switch (playerX.PlayerLocation)
            {
                case 0: break;
                case 1: Spaces.PropertySpace(playerX); break;
                case 2: GameEngine.PullCommunityChestCard(playerX); break;
                case 3: Spaces.PropertySpace(playerX); break;
                case 4: Spaces.TaxSpace(playerX, RNG); break;
                case 5: Spaces.PropertySpace(playerX); break;
                case 6: Spaces.PropertySpace(playerX); break;
                case 7: GameEngine.PullChanceCard(playerX); break;
                case 8: Spaces.PropertySpace(playerX); break;
                case 9: Spaces.PropertySpace(playerX); break;
                case 10: Spaces.VandalismSpace(playerX); break;
                case 11: Spaces.PropertySpace(playerX); break;
                case 12: Spaces.UtilitySpace(playerX, RNG); break;
                case 13: Spaces.PropertySpace(playerX); break;
                case 14: Spaces.PropertySpace(playerX); break;
                case 15: Spaces.PropertySpace(playerX); break;
                case 16: Spaces.PropertySpace(playerX); break;
                case 17: GameEngine.PullCommunityChestCard(playerX); break;
                case 18: Spaces.PropertySpace(playerX); break;
                case 19: Spaces.PropertySpace(playerX); break;
                case 20: Console.WriteLine("free repair space!\n"); break;
                case 21: Spaces.PropertySpace(playerX); break;
                case 22: GameEngine.PullChanceCard(playerX); break;
                case 23: Spaces.PropertySpace(playerX); break;
                case 24: Spaces.PropertySpace(playerX); break;
                case 25: Spaces.PropertySpace(playerX); break;
                case 26: Spaces.PropertySpace(playerX); break;
                case 27: Spaces.PropertySpace(playerX); break;
                case 28: Spaces.UtilitySpace(playerX, RNG); break;
                case 29: Spaces.PropertySpace(playerX); break;
                case 30: Spaces.VandalismSpace(playerX); break;
                case 31: Spaces.PropertySpace(playerX); break;
                case 32: Spaces.PropertySpace(playerX); break;
                case 33: GameEngine.PullCommunityChestCard(playerX); break;
                case 34: Spaces.PropertySpace(playerX); break;
                case 35: Spaces.PropertySpace(playerX); break;
                case 36: GameEngine.PullChanceCard(playerX); break;
                case 37: Spaces.PropertySpace(playerX); break;
                case 38: Spaces.TaxSpace(playerX, RNG); break;
                case 39: Spaces.PropertySpace(playerX); break;
                default: break;
            }
        }
        internal static void ChangeSpaceType(Player playerX, string spaceType)
        {
            // assigns the space type that the player is currently on
            if (spaceType == "GO" || spaceType == "OP" || spaceType == "UP" || spaceType == "TX" || spaceType == "UT" || spaceType == "VS")
            {
                playerX.OnSpaceType = spaceType;
            }
            else
            {
                DisplayError("!! error: invalid space type assigned.");
            }
        }
        internal static void CyclePlayerLocation(Player playerX)
        {
            // stops players from going out of board range
            if (playerX.PlayerLocation >= 40)
            {
                playerX.PlayerLocation = playerX.PlayerLocation - 40;
                Spaces.GoSpace(playerX);
            }
        }
        internal static void ColorPicker (int colorIndex)
        {
            // changes console text to the player's chosen color
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
                    goto case 2;
            }
        }

        /* internal static void DisplayBoard()
        {
            // display space names, color coded by type / ownership status
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UNOWNED properties are green");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OWNED properties are red");
            Console.ResetColor();
            for (int i = 0; i < GameSetup.MaxSpaces-1; i+=2)
            {
                Console.WriteLine(Spaces.SpaceNameArray[i] + "        " + (Spaces.SpaceNameArray[i+1]));
            }
        } */
        internal static void DisplayError(string message)
        {
            // displays error messages in red
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }
        internal static void DisplayHeldCards(Player playerX)
        {
            // displays the player's amount of held cards, if any, and their names with their text
            if (String.IsNullOrEmpty(playerX.DrawnCards))
            {
                Console.WriteLine(playerX.PlayerName + " currently has no cards!\n");
            }
            else
            {
                string[] drawnCardArray = playerX.DrawnCards.Split(',');
                Console.WriteLine($"{playerX.PlayerName} is holding {drawnCardArray.Length} cards! they say..\n");
                for (int i = 0; i < drawnCardArray.Length; i++)
                {
                    Console.WriteLine(TranslateCard(drawnCardArray[i]));
                }
                Console.WriteLine();
            }
        }
        internal static void DisplayOwnedProperties(Player playerX)
        {
            // displays the player's amount of own properties, if any, along with their names and info
            if (String.IsNullOrEmpty(playerX.OwnedProperties))
            {
                DisplayError("!! error: this player should not exist.");
            }
            else
            {
                string[] propertyArray = playerX.OwnedProperties.Split(',');
                Console.WriteLine($"{playerX.PlayerName} owns {propertyArray.Length} properties!\ntheir names and values are as follows..\n");
                for (int i = 0; i < propertyArray.Length; i++)
                {
                    Console.WriteLine(TranslateProperty(propertyArray[i]));
                    Console.WriteLine($"health: ({PropertyCard.CurrentPropertyValue[i]}/{PropertyCard.MaxPropertyValue[i]})");
                    Console.WriteLine($"damage multiplier: {PropertyCard.DamageMultiplier[i]}\n");
                }
            }
            Console.WriteLine();
        }
        internal static void DisplayCardComparison(Player playerX)
        {
            // displays equipped card info and the newly acquired card's info
            Console.WriteLine($"they currently have {Spaces.SpaceNameArray[playerX.EquippedCardIndex]} equipped");
            Console.WriteLine("current health: " + playerX.CurrentHealth);
            Console.WriteLine("max health: " + playerX.MaxHealth);
            Console.WriteLine("damage multiplier: " + playerX.Dice);
            Console.WriteLine("\nthese are the stats of the new card, " + Spaces.SpaceNameArray[playerX.PlayerLocation]);
            Console.WriteLine("max health: " + PropertyCard.MaxPropertyValue[playerX.PlayerLocation]);
            Console.WriteLine("damage multiplier: " + PropertyCard.DamageMultiplier[playerX.PlayerLocation] + "");
            ColorPicker(playerX.PlayerColorIndex);
            Console.Write($"\nswitch {playerX.PlayerName}'s card? (y/n): ");
            Console.ResetColor();
            string input = Console.ReadLine().Trim().ToLower();

            bool done = false;
            while (!done)
            {
                if (input == "y")
                {
                    Console.Clear();
                    EquipNewCard(playerX);
                    done = true;
                }
                else if (input == "n")
                {
                    done = true;
                }
                else
                {
                    DisplayError("invalid input. please try again.");
                }
            }
            
        }
        internal static void EquipNewCard(Player playerX, int cardIndex)
        {
            // equipping first cards
            // changes player values to card values based on index
            playerX.EquippedCardIndex = cardIndex;
            playerX.MaxHealth = PropertyCard.MaxPropertyValue[cardIndex];
            playerX.CurrentHealth = PropertyCard.CurrentPropertyValue[cardIndex];
            playerX.Dice = PropertyCard.DamageMultiplier[cardIndex];
        }
        internal static void EquipNewCard(Player playerX)
        {
            // equipping cards after the first ones
            // changes player values to card values based on acquired card loaction
            playerX.EquippedCardIndex = playerX.PlayerLocation;
            playerX.MaxHealth = PropertyCard.MaxPropertyValue[playerX.PlayerLocation];
            playerX.CurrentHealth = PropertyCard.MaxPropertyValue[playerX.PlayerLocation];
            playerX.Dice = PropertyCard.DamageMultiplier[playerX.PlayerLocation];
        }
        internal static string TranslateCard(string cardTitle)
        {
            // changes card identifier to text
            string cardText = "blank.";
            if (cardTitle.Substring(0,5) == "chest")
            {
                string index = cardTitle.Substring(5);
                switch (index)
                {
                    // placeholder text until i have the cards actually do stuff
                    case "1": cardText = "this is the first community chest card"; break;
                    case "2": cardText = "this is the second community chest card"; break;
                    case "3": cardText = "this is the third community chest card"; break;
                    case "4": cardText = "this is the fourth community chest card"; break;
                    case "5": cardText = "this is the fifth community chest card"; break;
                    case "6": cardText = "this is the sixth community chest card"; break;
                    case "7": cardText = "this is the seventh community chest card"; break;
                    case "8": cardText = "this is the eighth community chest card"; break;
                    case "9": cardText = "this is the ninth community chest card"; break;
                    case "10": cardText = "this is the tenth community chest card"; break;
                    case "11": cardText = "this is the eleventh community chest card"; break;
                    case "12": cardText = "this is the twelfth community chest card"; break;
                    default: cardText = "!! error: invalid range"; break;
                }
            }
            else if (cardTitle.Substring(0,6) == "chance")
            {
                string index = cardTitle.Substring(6);
                switch (index)
                {
                    // also placeholder text
                    case "1": cardText = "this is the first chance card"; break;
                    case "2": cardText = "this is the second chance card"; break;
                    case "3": cardText = "this is the third chance card"; break;
                    case "4": cardText = "this is the fourth chance card"; break;
                    case "5": cardText = "this is the fifth chance card"; break;
                    case "6": cardText = "this is the sixth chance card"; break;
                    case "7": cardText = "this is the seventh chance card"; break;
                    case "8": cardText = "this is the eighth chance card"; break;
                    case "9": cardText = "this is the ninth chance card"; break;
                    case "10": cardText = "this is the tenth chance card"; break;
                    case "11": cardText = "this is the eleventh chance card"; break;
                    case "12": cardText = "this is the twelfth chance card"; break;
                    default: cardText = "!! error: invalid range"; break;
                }
            }
            else
            {
                cardText = "card could not be transcribed.";
            }
                return cardText;
        }
        internal static string TranslateSpaceType(string spaceType)
        {
            // changes space identifier to text
            string typeName;
            switch (spaceType)
            {
                case "GO": typeName = "go"; break;
                case "OP": typeName = "owned property"; break;
                case "UP": typeName = "unowned property"; break;
                case "TX": typeName = "tax"; break;
                case "UT": typeName = "utility"; break;
                case "VS": typeName = "vandalism"; break;
                default: typeName = "ER"; break;
            }
            return typeName;
        }
        internal static string TranslateProperty(string propertyTitle)
        {
            // changes property identifier to text

            string propertyName = "n/a";
            try
            {
                int propertyIndex = int.Parse(propertyTitle.TrimStart('0'));
                propertyName = Spaces.SpaceNameArray[propertyIndex];
            }
            catch
            {
                DisplayError("!! error: could not convert property index to int.");
            }
            return propertyName;
        }
        internal static void Turn(Player player1, Player player2)
        {
            // cycles between 2 players turns if they are alive/active, else it skips
            if (player1.Active == true)
            {
                GameEngine.PlayerAction(player1);
                CheckWin(player1, player2);
            }
            if (player2.Active == true)
            {
                GameEngine.PlayerAction(player2);
                CheckWin(player1, player2);
            }
        }
        internal static void Turn(Player player1, Player player2, Player player3)
        {
            // cycles between 2 players turns if they are alive/active, else it skips
            if (player1.Active == true)
            {
                GameEngine.PlayerAction(player1);
                CheckWin(player1, player2, player3);
            }
            if (player2.Active == true)
            {
                GameEngine.PlayerAction(player2);
                CheckWin(player1, player2, player3);
            }
            if (player3.Active)
            {
                GameEngine.PlayerAction(player3);
                CheckWin(player1, player2, player3);
            }
        }
        internal static void Turn(Player player1, Player player2, Player player3, Player player4)
        {
            // cycles between 2 players turns if they are alive/active, else it skips
            if (player1.Active == true)
            {
                GameEngine.PlayerAction(player1);
                CheckWin(player1, player2, player3, player4);
            }
            if (player2.Active == true)
            {
                GameEngine.PlayerAction(player2);
                CheckWin(player1, player2, player3, player4);
            }
            if (player3.Active)
            {
                GameEngine.PlayerAction(player3);
                CheckWin(player1, player2, player3, player4);
            }
            if (player4.Active)
            {
                GameEngine.PlayerAction(player4);
                CheckWin(player1, player2, player3, player4);
            }
        }
        internal static void GameplayLoop(Player player1, Player player2, Player player3, Player player4)
        {
            // loops for 2, 3, and 4 players
            switch (CurrentNumberOfPlayers)
            {
                case 2: Turn(player1, player2);  break;
                case 3: Turn(player1, player2, player3); break;
                case 4: Turn(player1, player2, player3, player4); break;
                default: break;
            }
        }
        internal static void CheckWin(Player player1, Player player2)
        {
            // checks if there is only one player, then the game ends. displays winner info between 2 players
            if (currentNumberOfPlayers <= 1)
            {
                
                if (player1.Active == true && player2.Active == false)
                {
                    ColorPicker(player1.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 1 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player1.PlayerName, player1.TurnCount, player1.HeldCardCount, player1.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == true)
                {
                    ColorPicker(player2.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 2 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player2.PlayerName, player2.TurnCount, player2.HeldCardCount, player2.OwnedPropertyCount);
                }
                Console.ResetColor();
                Console.WriteLine("\nthank you for playing!\n\n");
                GameOver = true;
            }
        }
        internal static void CheckWin(Player player1, Player player2, Player player3)
        {
            // checks if there is only one player, then the game ends. displays winner info between 2 players
            if (currentNumberOfPlayers <= 1)
            {

                if (player1.Active == true && player2.Active == false && player3.Active == false)
                {
                    ColorPicker(player1.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 1 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player1.PlayerName, player1.TurnCount, player1.HeldCardCount, player1.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == true && player3.Active == false)
                {
                    ColorPicker(player3.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 2 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player2.PlayerName, player2.TurnCount, player2.HeldCardCount, player2.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == false && player3.Active == true)
                {
                    ColorPicker(player3.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 3 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player3.PlayerName, player3.TurnCount, player3.HeldCardCount, player3.OwnedPropertyCount);
                }
                Console.WriteLine("\nthank you for playing!\n\n");
                GameOver = true;
            }
        }
        internal static void CheckWin(Player player1, Player player2, Player player3, Player player4)
        {
            // checks if there is only one player, then the game ends. displays winner info between 2 players
            if (currentNumberOfPlayers <= 1)
            {

                if (player1.Active == true && player2.Active == false && player3.Active == false && player4.Active == false)
                {
                    ColorPicker(player1.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 1 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player1.PlayerName, player1.TurnCount, player1.HeldCardCount, player1.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == true && player3.Active == false && player4.Active == false)
                {
                    ColorPicker(player3.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 2 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player2.PlayerName, player2.TurnCount, player2.HeldCardCount, player2.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == false && player3.Active == true && player4.Active == false)
                {
                    ColorPicker(player3.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 3 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player3.PlayerName, player3.TurnCount, player3.HeldCardCount, player3.OwnedPropertyCount);
                }
                else if (player1.Active == false && player2.Active == false && player3.Active == false && player4.Active == true)
                {
                    ColorPicker(player3.PlayerColorIndex);
                    Console.WriteLine($"congratualations to player 4 for winning the game!");
                    Console.ResetColor();
                    Console.WriteLine("{0} won in {1} turns, while holding {2} cards and owning {3} properties.", player4.PlayerName, player4.TurnCount, player4.HeldCardCount, player4.OwnedPropertyCount);
                }
                else
                {
                    DisplayError("!! error: multiple players were active or all were inactive");
                }
                    Console.WriteLine("\nthank you for playing!\n\n");
                GameOver = true;
            }
        }
        internal static void KillPlayer(Player playerX)
        {
            // deactivates a player, returns their properties to the board, decreases current # of players
            int index;
            currentNumberOfPlayers--;
            ColorPicker(playerX.PlayerColorIndex);
            Console.WriteLine(playerX.PlayerName + " has bankrupted! they are no longer in the game!\n");
            Console.ResetColor();
            if (CurrentNumberOfPlayers >= 2)
            {
                Console.WriteLine($"good luck to the remaining {CurrentNumberOfPlayers} players!\n");
                string[] propertyArray = playerX.OwnedProperties.Split(',');
                for (int i = 0; i < propertyArray.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(propertyArray[i]))
                    {
                        index = int.Parse(propertyArray[i].TrimStart('0'));
                        PropertyCard.Owned[index] = false;
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