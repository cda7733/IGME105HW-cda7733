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
            while (!done && Utility.GameOver == false)
            {
                Console.WriteLine($"what would {playerX.PlayerName} like to do?");
                Console.WriteLine("0. roll\n1. view cards\n2. open menu\n3. trade");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "0": RollForMovement(playerX); done = true; break;
                    case "1":Utility.DisplayHeldCards(playerX); break;
                    case "2": Menu(playerX); break;
                    case "3": Console.WriteLine("this is where the trade menu will be!\n"); break;
                    default: Utility.DisplayError("invalid input. please enter one of the listed numbers."); break;
                }
            }
        }
        internal static void Menu(Player playerX)
        {
            bool done = false;
            while (!done && Utility.GameOver == false)
            {
                Console.WriteLine("\n0. resume\n1. view player info\n2. rulebook\n3. quit");
                string input = Console.ReadLine();
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
            int diceRoll = GameSetup.RNG.Next(2, 13);
            playerX.PlayerLocation = playerX.PlayerLocation + diceRoll;
            Utility.CyclePlayerLocation(playerX);
            Console.WriteLine("{0} rolled a {1}! they are now on {2}, space number {3}\n", playerX.PlayerName, diceRoll, Spaces.DisplayPropertyName(playerX.PlayerLocation), playerX.PlayerLocation);
            Utility.SpaceAction(playerX);
            playerX.TurnCount++;
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
            int cardIndex = GameSetup.RNG.Next(1, Utility.CardQuantity);
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
            int cardIndex = GameSetup.RNG.Next(1, Utility.CardQuantity);
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
