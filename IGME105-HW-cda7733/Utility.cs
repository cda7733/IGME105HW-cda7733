using System;

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

            switch (Spaces.SpaceType[playerX.PlayerLocation])
            {
                case "GO": break;
                case "UP": Spaces.PropertySpace(playerX); break;
                case "OP": Spaces.PropertySpace(playerX); break;
                case "CH": GameEngine.PullChanceCard(playerX); break;
                case "CO": GameEngine.PullCommunityChestCard(playerX); break;
                case "UT": Spaces.UtilitySpace(playerX, RNG); break;
                case "TX": Spaces.TaxSpace(playerX, RNG); break;
                case "VS": Spaces.VandalismSpace(playerX); break;

                default: DisplayError("!! error: player on unrecognised space type"); break;
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
                int propertyIndex;
                Console.WriteLine($"{playerX.PlayerName} owns {propertyArray.Length} properties!\ntheir names and values are as follows..\n");
                for (int i = 0; i < propertyArray.Length; i++)
                {
                    propertyIndex = int.Parse(propertyArray[i].TrimStart('0'));
                    Console.WriteLine(TranslateProperty(propertyArray[i]));
                    Console.WriteLine($"health: ({PropertyCard.CurrentPropertyValue[propertyIndex]}/{PropertyCard.MaxPropertyValue[propertyIndex]})");
                    Console.WriteLine($"damage multiplier: {PropertyCard.DamageMultiplier[propertyIndex]}\n");
                }
            }
            Console.WriteLine();
        }
        internal static void DisplayCardComparison(Player playerX)
        {
            // displays equipped card info and the newly acquired card's info
            
            Console.WriteLine($"{playerX.PlayerName} currently has {Spaces.SpaceNameArray[playerX.EquippedCardIndex]} equipped");
            Console.WriteLine("current health: " + playerX.CurrentHealth);
            Console.WriteLine("max health: " + playerX.MaxHealth);
            Console.WriteLine("damage multiplier: " + playerX.Dice);
            Console.WriteLine("\nthese are the stats of the new card, " + Spaces.SpaceNameArray[playerX.PlayerLocation]);
            Console.WriteLine("max health: " + PropertyCard.MaxPropertyValue[playerX.PlayerLocation]);
            Console.WriteLine("damage multiplier: " + PropertyCard.DamageMultiplier[playerX.PlayerLocation] + "");
            ColorPicker(playerX.PlayerColorIndex);
            Console.Write($"\nswitch {playerX.PlayerName}'s card? (y/n): ");
            Console.ResetColor();
            string input;
            bool done = false;
            while (!done)
            {
                input = Console.ReadLine().Trim().ToLower();
                Console.Clear();
                if (input.StartsWith("y"))
                {
                    EquipNewCard(playerX);
                    done = true;
                }
                else if (input.StartsWith("n"))
                {
                    done = true;
                }
                else
                {
                    DisplayError("invalid input! please enter a 'y' or an 'n'");
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
        internal static string TranslateSpaceType(Player playerX)
        {
            // changes space identifier to text



            string typeName = "";
            string spaceType = Spaces.SpaceType[playerX.PlayerLocation];
            
            switch (spaceType)
            {
                case "GO": typeName = "go"; break;
                case "OP": typeName = "owned property"; break;
                case "UP": typeName = "unowned property"; break;
                case "CH": typeName = "chance"; break;
                case "CO": typeName = "community chest"; break;
                case "TX": typeName = "tax"; break;
                case "UT": typeName = "utility"; break;
                case "VS": typeName = "vandalism"; break;
                default: typeName = "non-existent"; break;
            } 

            return typeName;
        }
    }
}