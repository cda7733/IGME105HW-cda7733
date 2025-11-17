using System;
using System.Collections.Generic;

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
 * 10/30/2025 - changed the if statement in TranslateSpaceType(..) to a ternary
 * 11/05/2025 - fixed display methods to handle lists
 */

namespace IGME105_HW_cda7733
{
    internal static class Utility
    {
        // variables & properties
        internal static Random RNG = new Random();
        internal static bool GameOver = false;

        internal static int CurrentNumberOfPlayers;
        internal static int CurrentPlayerIndex = 0;
        internal static int CardQuantity = 12;

        internal static Dictionary<string, string> SpaceTypes = new Dictionary<string, string>()
        {
            {"GO","go"},{"OP","owned property"}, {"UP","unowned property"}, {"CH","chance"}, 
            {"CO","community chest"}, {"TX","tax"}, {"UT","utility"}, {"VS","vansalism"}
        };
        

        internal static void SpaceAction(Player playerX, List<Player> players)
        {
            // triggers space methods depending on location

            switch (Spaces.SpaceType[playerX.PlayerLocation])
            {
                case "GO": break;
                case "UP": Spaces.PropertySpace(playerX, players); break;
                case "OP": Spaces.PropertySpace(playerX, players); break;
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
                    goto case 3;
            }
        }

        internal static void FillBoard(List<Player> players, string spaceNumber, char direction)
        {

            if (PropertyCard.Owned[int.Parse(spaceNumber)] == true)
            {
                foreach (Player player in players)
                {
                    if (player.OwnedProperties.Contains(spaceNumber))
                    {
                        ColorPicker(player.PlayerColorIndex);
                    }
                }
            }
            if (direction == 'h')
            {
                Console.Write("===");
                Console.ResetColor();
                Console.Write("|");
            }
            else if (direction == 'v')
            {
                Console.Write("|");
                Console.Write(" ==== ");
                Console.ResetColor();
                Console.Write("|");
            }
            
        }
        internal static void FillBoard(List<Player> players, string spaceNumber, char direction, bool railroad)
        {

            if (PropertyCard.Owned[int.Parse(spaceNumber)] == true)
            {
                foreach (Player player in players)
                {
                    if (player.OwnedProperties.Contains(spaceNumber))
                    {
                        ColorPicker(player.PlayerColorIndex);
                    }
                }
            }
            if (direction == 'h')
            {
                Console.Write("=R=");
                Console.ResetColor();
                Console.Write("|");
            }
            else if (direction == 'v')
            {
                Console.Write("|");
                Console.Write(" =RR= ");
                Console.ResetColor();
                Console.Write("|");
            }

        }
        internal static void DisplayBoard(List<Player> players)
        {
            Console.Write(" _________________________________________________\r\n| free |");
            FillBoard(players, "21", 'h'); Console.Write(" ? |"); FillBoard(players, "23", 'h'); FillBoard(players, "24", 'h'); FillBoard(players, "25", 'h',true);  FillBoard(players, "26", 'h'); FillBoard(players, "27", 'h'); Console.Write(" + |"); FillBoard(players, "29", 'h');
            Console.Write("  vs  |\r\n| park |   |   |   |   |   |   |   |   |   |      |\r\n|______|___|___|___|___|___|___|___|___|___|______|\r\n");
            FillBoard(players, "19", 'v'); Console.Write("\t\t\t\t   "); FillBoard(players, "31", 'v'); Console.Write("\n|______|\t\t\t\t   |______|\n");
            FillBoard(players,"18",'v'); Console.Write("     __________                    "); FillBoard(players, "32",'v'); 
                               Console.Write("\n|______|    /         /\t\t\t   |______|\n");
            Console.Write("|  !!  |");   Console.Write("   / chest ! /\t\t\t   "); Console.Write("|  !!  |"); 
                               Console.Write("\n|______|  /_________/\t\t\t   |______|\n");
            FillBoard(players, "16",'v'); Console.Write("\t\t\t\t   "); FillBoard(players, "34", 'v'); Console.Write("\n|______|\t\t\t\t   |______|\n");
            FillBoard(players, "15", 'v',true); Console.Write("\t\t\t\t   "); FillBoard(players, "35", 'v',true); Console.Write("\n|______|\t\t\t\t   |______|\n");
            FillBoard(players, "14", 'v'); Console.Write("\t\t\t\t   "); Console.Write("|  ??  |"); Console.Write("\n|______|\t\t\t\t   |______|\n");

            FillBoard(players, "13", 'v'); Console.Write("\t\t      ___________  "); FillBoard(players, "37", 'v'); Console.Write("\n|______|\t\t     / \t        /  |______|\n");
            Console.Write("|  ++  |"); Console.Write("\t\t    / chance ? /   "); Console.Write("|  xx  |"); Console.Write("\n|______|\t\t   /__________/    |______|\n");

            FillBoard(players, "11", 'v'); Console.Write("\t\t\t\t   "); FillBoard(players, "39", 'v'); Console.WriteLine("\n|______|___________________________________|______|");
            Console.Write("|  vs  |"); FillBoard(players, "09", 'h'); FillBoard(players, "08", 'h'); Console.Write(" ? |"); FillBoard(players, "06", 'h'); FillBoard(players, "05", 'h',true); Console.Write(" x |"); FillBoard(players, "03", 'h'); Console.Write(" ! |"); FillBoard(players, "01", 'h');
            Console.Write("  GO  |\r\n|      |   |   |   |   |   |   |   |   |   |      |\r\n|______|___|___|___|___|___|___|___|___|___|______|\r\n");
            Console.WriteLine();
        }
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
            if (playerX.DrawnCards.Count == 0)
            {
                Console.WriteLine(playerX.PlayerName + " currently has no cards!\n");
            }
            else
            {
                Console.WriteLine($"{playerX.PlayerName} is holding {playerX.DrawnCards.Count} cards! they say..\n");
                foreach (string drawnCard in playerX.DrawnCards)
                {
                    Console.WriteLine(TranslateCard(drawnCard));
                }
                Console.WriteLine();
            }
        }
        internal static void DisplayOwnedProperties(Player playerX)
        {
            // displays the player's amount of own properties, if any, along with their names and info
            if (playerX.OwnedProperties.Count == 0)
            {
                DisplayError("!! error: this player should not exist.");
            }
            else
            {
                int propertyIndex;
                Console.WriteLine($"{playerX.PlayerName} owns {playerX.OwnedProperties.Count} properties!\ntheir names and values are as follows..\n");
                foreach (string property in playerX.OwnedProperties)
                {
                    propertyIndex = int.Parse(property.TrimStart('0'));
                    Console.WriteLine(TranslateProperty(property));
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
        internal static string TranslateSpaceType(Player playerX, Dictionary<string,string> translations)
        {
            // changes space identifier to text
            
            string type = Spaces.SpaceType[playerX.PlayerLocation];
            string typeName = translations.ContainsKey(type) ? translations[type]: "ERROR";
            return typeName; 
        }
    }
}