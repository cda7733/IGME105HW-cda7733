using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        // methods
        
        /* internal static void RollForFirstProperty(int chosenPlayer, Player player1, Player player2, Player player3, Player player4)
        {
            int diceRoll = RNG.Next(0, 5);
        }
        */
        internal static void SpaceAction(Player playerX)
        {
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
            if (spaceType == "GO" || spaceType == "OP" || spaceType == "UP" || spaceType == "TX" || spaceType == "UT" || spaceType == "VS")
            {
                playerX.OnSpaceType = spaceType;
            }
            else
            {
                DisplayError("code error: invalid space type assigned.");
            }

        }
        internal static void CyclePlayerIndex(string option, Player playerX, int currentMaxPlayers)
        {
            // FIX THIS.
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
        internal static void CyclePlayerLocation(Player playerX)
        {
            if (playerX.PlayerLocation >= 40)
            {
                playerX.PlayerLocation = playerX.PlayerLocation - 40;
                Spaces.GoSpace(playerX);
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
                    goto case 2;
            }
        }
        internal static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }
        internal static void DisplayAvailableColors()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. red");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. orange");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. yellow");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3. cyan");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("4. blue");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("5. purple");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("6. pink");
            Console.ResetColor();
        }
        internal static void DisplayHeldCards(Player playerX)
        {
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
                Console.WriteLine("");
            }
        }
        internal static string TranslateCard(string cardTitle)
        {
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
                    default: cardText = "range error"; break;
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
                    default: cardText = "range error"; break;
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
        internal static void Turn(Player player1, Player player2)
        {
            GameEngine.PlayerAction(player1);
            GameEngine.PlayerAction(player2);
        }
        internal static void Turn(Player player1, Player player2, Player player3)
        {
            GameEngine.PlayerAction(player1);
            GameEngine.PlayerAction(player2);
            GameEngine.PlayerAction(player3);
        }
        internal static void Turn(Player player1, Player player2, Player player3, Player player4)
        {
            GameEngine.PlayerAction(player1);
            GameEngine.PlayerAction(player2);
            GameEngine.PlayerAction(player3);
            GameEngine.PlayerAction(player4);
        }
        internal static void GameplayLoop(Player player1, Player player2, Player player3, Player player4)
        {
            switch (CurrentNumberOfPlayers)
            {
                case 2: Turn(player1, player2); break;
                case 3: Turn(player1, player2, player3); break;
                case 4: Turn(player1, player2, player3, player4); break;
                default: break;
            }
        }

    }
}