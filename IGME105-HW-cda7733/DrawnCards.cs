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
 */

namespace IGME105_HW_cda7733
{
    class DrawnCards
    {
        internal string text;
        int cardQuantity = 12; // 4 less than original monopoly
        // perhaps a string array that stores "first", "second".. "twelve"
        internal int cardIndex;

        internal void ReadChanceCard(int index, string text)
        {
            Console.WriteLine("player drew a chance card!");
            Console.WriteLine($"it is the {index} chance card in its deck");
            Console.WriteLine($"it says: {text}");

        }
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
    }

}
