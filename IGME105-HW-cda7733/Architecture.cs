using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * program name: IGME105 monopoly game
 * created by: charisma allen
 * purpose: make monopoly more fun by making it a card battler
 * 
 * 09/03/2025 - created file, made psuedocode for tic-tac-toe
 * 09/08/2025 - replaced tictactoe w/ monopoly
 * 09/12/2025 - monopoly pseudocode
 * 09/17/2025 - adding classes and properties
 * 09/18/2025 - created a new repo and project because my other one was busted
 * 09/19/2025 - distrubuted comments to classes for HW3
 * 09/26/2025 - calling methods from all classes
 * 10/10/2025 - called new methods w/ RNG elements
 * 10/15/2025 - cleanup! commented out game setup bc it was tedious for testing. removed magenta coloring.
 * 10/24/2025 - reimplemented game setup. the game works for most things. win conditions, property acquisition, cards, etc.
 * 10/31/2025 - changed some if-statements to ternaries, and a FEW methods to lambdas
 */

// github link: https://github.com/cda7733/IGME105HW-cda7733

namespace IGME105_HW_cda7733
{
    internal class Architecture
    {
        static void Main(string[] args)
        {
            List<Player>players = new List<Player>();

            GameSetup.Startup(players);

            // this is the whole game
            while (Utility.GameOver == false)
            {
                GameEngine.GameplayLoop(players);
            }
        }
    }
}
