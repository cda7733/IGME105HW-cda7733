using System;
using System.Collections.Generic;
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
 */


namespace IGME105_HW_cda7733
{
    internal class Player
    {
        // variables & properties
        string playerName = "";
        internal string PlayerName
        {
            get { return playerName; } 
            set { playerName = value; }
        }

        int[] playerLocation = { 0, 0, 0, 0 };
        internal int[] PlayerLocation
        {
            get { return playerLocation; }
            set { playerLocation = value; }
        }

        int playerIndex = 0;
        internal int PlayerIndex
        {
            get { return playerIndex; }
            set { playerIndex = value; }
        }

        int playerTokenIndex; // used for indexing & tracking which tokens are taken by other players
        internal int PlayerTokenIndex
        {
            get { return playerTokenIndex; }
        }
        string[] playerTokenName = { "angelo","zoey","mcqueen","tailor","captain","hermes","fancy","flowerboy"};
        internal string[] PlayerTokenName
        {
            get { return  playerTokenName; }
        }
        int playerColorIndex;
        internal int PlayerColorIndex
        {
            get { return playerColorIndex; }
            set { playerColorIndex = value; }
        }


        // methods
        internal static void PromptName(Player playerX)
        {
            Console.Write($"what is the name of player {playerX.PlayerIndex + 1}? ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("this player will be named after their token.");
            }
            else
            {
                playerX.PlayerName = input;
            }
            Console.WriteLine("");
        }
        internal static void PromptToken(Player playerX)
        {
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"which token would you like this player to be? please enter a single number.");
                Console.WriteLine(" 0. cat \n 1. dog \n 2. car \n 3. thimble \n 4. ship \n 5. shoe \n 6. tophat \n 7. wheelbarrow");
                string chosenTokenNumber = Console.ReadLine().Trim();
                // make an array that translates the numerical id of the token to the name. wrap it in an if statement that checks if its a valid number
                Console.WriteLine($"the player entered {chosenTokenNumber} \n");
                try
                {
                    playerX.playerTokenIndex = Convert.ToInt32(chosenTokenNumber);
                    if (playerX.playerTokenIndex >= 0 && playerX.PlayerTokenIndex <= 7)
                    {
                        if (string.IsNullOrWhiteSpace(playerX.PlayerName))
                        {
                            playerX.PlayerName = playerX.PlayerTokenName[playerX.PlayerTokenIndex];
                        }
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("out of range! enter a number 0-7.");
                    }
                }
                catch
                {
                    Console.WriteLine("invalid entry! enter a numerical value. (0,1,2,3..)");
                }
            }
        }

        internal static void DisplayAvailableColors()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("red");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("orange");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("yellow");
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("green");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("cyan");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("blue");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("purple");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("pink");
            Console.ResetColor();
        }
        internal static void PromptColor(Player playerX)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"which color would you like {playerX.PlayerName} to be?");
                DisplayAvailableColors();
                string input = Console.ReadLine().Trim();
                try
                {
                    Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("please enter a valid number!");
                }
            }
            

        }
        internal static void CyclePlayerIndex(int playerIndex, int currentMaxPlayers)
        {
            if (playerIndex < currentMaxPlayers)
            {
                playerIndex++;
            }
            else 
            {
                playerIndex = 0;
            }
            Console.WriteLine("what would you like to do? ");
        }
    }
}
