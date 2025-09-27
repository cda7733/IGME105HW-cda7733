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

        // there would be a playerTokenName array thats controlled w/ playerTokenIndex
        internal int playerTokenIndex; // used for indexing & tracking which tokens are taken by other players
        internal string playerTokenName; // used in setup and as a placeholder name (and maybe later for visuals)

        // methods
        internal static void PromptName(int playerIndex, Player playerX)
        {
            Console.Write($"what is the name of player {playerIndex + 1}? ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("this player will be named after their token.");
                Console.WriteLine("(in later versions, the player's name will ACTUALLY be named after a token,\nex. cat --> kitty, ship --> sailor, tophat --> fancy, etc)");
                playerX.PlayerName = "tolkein";
            }
            else
            {
                playerX.PlayerName = input;
            }
            Console.WriteLine("");
        }
        internal static void PromptToken(Player playerX)
        {
            Console.WriteLine($"which token would you like {playerX.PlayerName} to be? please enter a single number.");
            Console.WriteLine(" 0. cat \n 1. dog \n 2. car \n 3. thimble \n 4. ship \n 5. shoe \n 6. tophat \n 7. wheelbarrow");
            string chosenTokenNumber = Console.ReadLine().Trim();
            // make an array that translates the numerical id of the token to the name. wrap it in an if statement that checks if its a valid number
            Console.WriteLine($"the player entered {chosenTokenNumber} \n");
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
        }
    }
}
