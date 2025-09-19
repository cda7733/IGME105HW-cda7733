using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    class DrawnCards
    {
        string text;
        int cardQuantity = 12; // 4 less than original monopoly
        internal int cardIndex;

        internal class CommunityChestCards : DrawnCards
        {
            // 12 cards that add/subtract total pv, heal/damage cards, and can send players the vandalism event
        }

        

        /*
         * string text;
                int cardQuantity = 16;
                internal int cardIndex; 
                
                CommunityChestCards:DrawnCards
                    
                ChanceCards:DrawnCards
         */
    }

}
