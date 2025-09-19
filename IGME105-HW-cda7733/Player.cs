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
 */


namespace IGME105_HW_cda7733
{
    internal class Player
    {
        // pull player index from PlayerInfo:Utility, which has get/set properties
        internal string playerName;
        internal int playerTokenIndex;
        internal string playerTokenName;

        /*
           base monopoly tokens: 
                dog, cat, car, thimble, boat, shoe, tophat, wheelbarrow
           int order (from a dice roll in the beginning of the game)
           string name (token name used for placeholder is the player is lazy)
           if the input for name is left blank and the player picked a thimble for their token, their name will be thimble
         */
        public Player()
        {

        }
    }
}
