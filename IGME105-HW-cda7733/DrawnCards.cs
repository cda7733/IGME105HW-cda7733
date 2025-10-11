using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

/*
 * program name: IGME105 monopoly game
 * created by: charisma allen
 * purpose: make monopoly more fun by making it a card battler
 * 
 * 09/18/2025 - created a new repo and project because my other one was busted
 * 09/19/2025 - created, copied comments from architecture, then changed to code for HW3
 * 09/26/2025 - gave variables read-only properties, gave some detail to the card display methods
 * 10/10/2025 - added RNG to display methods
 */

namespace IGME105_HW_cda7733
{
    class DrawnCards
    {
        // variables & properties
        string text;
        internal string Text
        {
            get { return text; }
        }
        const int cardQuantity = 12; // 4 less than original monopoly
        internal int CardQuantity
        {
            get { return cardQuantity; }
        }
        // perhaps a string array that stores "first", "second".. "twelve"
        int cardIndex;
        internal int CardIndex
        {
            get { return cardIndex; }
        }

        // methods
        internal class CommunityChestCards : DrawnCards
        {
            internal CommunityChestCards(int cardIndex, string text)
            {
                // 12 cards that add/subtract total property value, repair/damage cards, and can send players the vandalism event
                this.cardIndex = cardIndex;
                this.text = text;
            }
        }

        internal class ChanceCards : DrawnCards
        {
            internal ChanceCards(int cardIndex, string text)
            {
                // 12 cards that send you to different places on the board or change your property value
                this.cardIndex = cardIndex;
                this.text = text;
            }
        }
        internal static void DisplayChanceCard(string playerName, string text)
        {
            Console.WriteLine(playerName + " drew a chance card!");
            int number = GameSetup.RNG.Next(1,13);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"it is the {number}(st/nd/rd/th) chance card in its deck");
            Console.ResetColor();
            Console.WriteLine($"it says: {text}\n");
        }
        internal static void DisplayCommunityChestCard(string playerName, string text)
        {
            Console.WriteLine(playerName + " drew a community chest card!");
            int number = GameSetup.RNG.Next(1,13);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"it is the {number}(st/nd/rd/th) community chest card in its deck");
            Console.ResetColor();
            Console.WriteLine($"it says: {text}\n");
        }
    }
}
