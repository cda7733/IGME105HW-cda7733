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
        // there would be a playerTokenName array thats controlled w/ playerTokenIndex
        internal int playerTokenIndex;
        internal string playerTokenName;

        /*
           base monopoly tokens: 
                dog, cat, car, thimble, boat, shoe, tophat, wheelbarrow
           int order (from a dice roll in the beginning of the game)
           string name (token name used for placeholder is the player is lazy)
           if the input for name is left blank and the player picked a thimble for their token, their name will be thimble
         */
        internal void PromptName()
        {

        }
        internal void PromptToken()
        {
            Console.WriteLine("which token would you like to be? please enter a single number.");
            Console.WriteLine("0. cat \n 1. dog. \n 2. cat \n 3. thimble \n 4. boat \n 5. shoe \n 6. tophat \n 7. wheelbarrow");
            string chosenTokenNumber = Console.ReadLine().Trim();
            // do an array that translates the numerical id of the token to the name. wrap it in an if statement that checks if its a valid number
            Console.WriteLine("the player entered " + chosenTokenNumber);
        }
    }
}
