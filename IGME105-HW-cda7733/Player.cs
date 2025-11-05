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
 * 11/05/2025 - made player properties and cards into a list
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

        int playerTokenIndex;
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
        internal List<string> DrawnCards = new List<string>(); // formatted as chanceX or chestX, ex. chance2, chest11

        internal List<string> OwnedProperties = new List<string>(); // formatted as 00, ex. boardwalk = 39

        /* string ownedProperties = ""; 
        internal string OwnedProperties
        {
            get { return ownedProperties; }
            set {  ownedProperties = value; }
        }
        int ownedPropertyCount = 0;
        internal int OwnedPropertyCount
        {
            get { return ownedPropertyCount; }
            set { ownedPropertyCount = value; }
        } */
        int turnCount = 1;
        internal int TurnCount
        {
            get { return turnCount; }
            set { turnCount = value; }
        }
        string onSpaceType = "GO";
        internal string OnSpaceType
        {
            get { return onSpaceType; }
            set { onSpaceType = value; }
        }
        int currentHealth = 10;
        internal int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        int maxHealth = 10;
        internal int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        int dice = 1;
        internal int Dice
        {
            get { return dice; }
            set { dice = value; }
        }
        bool active = false;
        internal bool Active
        {
            get { return active; }
            set { active = value; }
        }
        int equippedCardIndex;
        internal int EquippedCardIndex
        {
            get { return equippedCardIndex; }
            set { equippedCardIndex = value; }
        }

        // constructors

        internal Player()
        {
            // actual player character
            // filled with prompted info
        }
        internal Player(int difficulty)
        {
            // not made yet!!

            // cpu player, automatically controlled
            // their info can be randomly generated
            // difficulty ranges 1-5
        }

        // methods
        internal void PromptName()
        {
            // ask player what name they want
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
            Console.WriteLine();
        }
        internal void PromptToken()
        {
            // ask player what token they want
            bool done = false;
            while (done == false)
            {
                Console.WriteLine($"which token would you like this player to be? please enter a single number.");
                Console.WriteLine(" 0. cat \n 1. dog \n 2. car \n 3. thimble \n 4. ship \n 5. shoe \n 6. tophat \n 7. wheelbarrow");
                string chosenTokenNumber = Console.ReadLine().Trim();
                try
                {
                    playerTokenIndex = int.Parse(chosenTokenNumber);
                    if (PlayerTokenIndex >= 0 && PlayerTokenIndex <= 7)
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
            // ask player what color they want
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"which color would you like {PlayerName} to be? please enter the number preceding the color.");
                GameSetup.DisplayAvailableColors();
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
                    Utility.DisplayError("invalid entry! enter a numerical value. (0,1,2,3..)");
                }
                Console.WriteLine($"{playerName}'s color will be ");
            }
            Console.Clear();
        }
        internal void DisplayPlayerInfo()
        {
            // displays a bunch of player info to console
            Utility.ColorPicker(PlayerColorIndex);
            Console.WriteLine($"\nplayer {PlayerIndex + 1 } info");
            Console.WriteLine("  name: " + PlayerName);
            Console.WriteLine($"  health: {currentHealth}/{maxHealth}");
            Console.WriteLine($"  # of dice equipped (damage multiplier): " + Dice);
            Console.WriteLine("  equipped card: " + Spaces.SpaceNameArray[EquippedCardIndex]);
            Console.WriteLine("  token: " + PlayerTokenName[playerTokenIndex]);
            Console.WriteLine("  color: " + PlayerColorNames[PlayerColorIndex]);
            Console.WriteLine("  turn: " + TurnCount);
            Console.ResetColor();
        }
        internal void DisplaySimplePlayerInfo()
        {
            // displays a bit of player info to the console, used for verification during setup
            Utility.ColorPicker(PlayerColorIndex);
            Console.WriteLine($"\nplayer {PlayerIndex + 1} info");
            Console.WriteLine("  name: " + PlayerName);
            Console.WriteLine("  token: " + PlayerTokenName[playerTokenIndex]);
            Console.WriteLine("  color: " + PlayerColorNames[PlayerColorIndex]);
            Console.ResetColor();
        }
    }
}