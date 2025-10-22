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
 * 10/10/2025 - added roll for order method
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

        int playerLocation = 0;
        internal int PlayerLocation
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
        string[] playerTokenName = { "cat", "dog", "car", "thimble", "ship", "shoe", "tophat", "wheelbarrow" };
        internal string[] PlayerTokenName
        {
            get { return playerTokenName; }
        }
        // for players to be named after their token
        string[] playerTokenNickname = { "angelo","zoey","mcqueen","tailor","captain","hermes","fancy","flowerboy" };
        internal string[] PlayerTokenNickname
        {
            get { return  playerTokenNickname; }
        }
        int playerColorIndex;
        internal int PlayerColorIndex
        {
            get{ return playerColorIndex; }
            set { playerColorIndex = value; }
        }
        string[] playerColorNames = { "red","orange","yellow","cyan","blue","purple","pink" };
        internal string[] PlayerColorNames
        {
            get { return  playerColorNames; }
        }
        string drawnCards = "";
        internal string DrawnCards
        {
            get { return drawnCards; }
            set {  drawnCards = value; }
        }
        int turnCount = 1;
        internal int TurnCount
        {
            get { return turnCount; }
            set { turnCount = value; }
        }


        // constructors

        internal Player()
        {
            // actual player character
            // filled with prompted info
        }
        internal Player(int difficulty)
        {
            // cpu player, automatically controlled
            // their info can be randomly generated
            // difficulty ranges 1-5
        }

        // methods
        internal void PromptName()
        {
            Console.Clear();
            Console.Write($"what is the name of player {PlayerIndex + 1}? ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("this player will be named after their token.");
            }
            else
            {
                PlayerName = input;
            }
            Console.WriteLine("");
        }
        internal void PromptToken()
        {
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"which token would you like this player to be? please enter a single number.");
                Console.WriteLine(" 0. cat \n 1. dog \n 2. car \n 3. thimble \n 4. ship \n 5. shoe \n 6. tophat \n 7. wheelbarrow");
                string chosenTokenNumber = Console.ReadLine().Trim();
                // make an array that translates the numerical id of the token to the name. wrap it in an if statement that checks if its a valid number
                try
                {
                    playerTokenIndex = Convert.ToInt32(chosenTokenNumber);
                    if (playerTokenIndex >= 0 && PlayerTokenIndex <= 7)
                    {
                        if (string.IsNullOrWhiteSpace(PlayerName))
                        {
                            PlayerName = PlayerTokenNickname[PlayerTokenIndex];
                        }
                        done = true;
                    }
                    else
                    {
                        Utility.DisplayError("out of range! enter a number 0-7.");
                    }
                }
                catch
                {
                    Utility.DisplayError("invalid entry! enter a numerical value. (0,1,2,3..)");
                }
            }
            Console.Clear();
        }
        internal void PromptColor()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"which color would you like {PlayerName} to be? please enter the number preceding the color.");
                Utility.DisplayAvailableColors();
                string input = Console.ReadLine().Trim();
                try
                {
                    int chosenColorIndex = Convert.ToInt32(input);
                    if (chosenColorIndex >= 0 && chosenColorIndex <= 6)
                    {
                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            PlayerColorIndex = chosenColorIndex;
                        }
                        done = true;
                    }
                    else
                    {
                        Utility.DisplayError("out of range! enter a number 0-6.");
                    }
                }
                catch
                {
                    Utility.DisplayError("please enter a valid number!");
                }
                Console.WriteLine($"{playerName}'s color will be ");
            }
            Console.Clear();
        }
        internal void DisplayPlayerInfo()
        {
            Utility.ColorPicker(PlayerColorIndex);
            Console.WriteLine($"\nplayer {PlayerIndex + 1 } info");
            Console.WriteLine("name: " + PlayerName);
            Console.WriteLine("color: " + PlayerColorNames[PlayerColorIndex]);
            Console.WriteLine("token: " + PlayerTokenName[playerTokenIndex]);
            Console.ResetColor();
        }
        internal void RollForOrder()
        {
            int diceRoll = GameSetup.RNG.Next(4);
            // keeping it 0-3 because i plan to set it = to player index
            Console.ForegroundColor= ConsoleColor.Magenta;
            // Console.WriteLine($"you are player {diceRoll + 1}");
            Console.ResetColor();
        }
    }
}
