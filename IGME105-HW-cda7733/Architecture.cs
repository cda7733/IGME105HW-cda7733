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
 * 09/03/2025 - created file, made psuedocode for tic-tac-toe
 * 09/08/2025 - replaced tictactoe w/ monopoly
 * 09/12/2025 - monopoly pseudocode
 * 09/17/2025 - adding classes and properties
 * 09/18/2025 - created a new repo and project because my other one was busted
 * 09/19/2025 - distrubuted comments to classes for HW3
 */

namespace IGME105_HW_cda7733
{
    internal class Architecture
    {
        static void Main(string[] args)
        {
            
            /*
             *  genre: boardgame, card battler
                audience: teens - adults who are familiar w/ the gameplay of monopoly AND simple battle systems/they can do math
                goal: last one standing
                # of players: 2-4
             */
            Utility game = new Utility();
            Player player1 = new Player();
            DrawnCards.ChanceCards chancecard1 = new DrawnCards.ChanceCards(0,"advance to board walk! if you pass go, upgrade your weakest card!");
            game.Welcome();
            game.RNG(12);
            player1.PromptToken();
            chancecard1.ReadChanceCard(chancecard1.cardIndex, chancecard1.text);
        }
    }
}
