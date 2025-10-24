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
 * 09/26/2025 - calling methods from all classes
 * 10/10/2025 - called new methods w/ RNG elements
 * 10/15/2025 - cleanup! commented out game setup bc it was tedious for testing. removed magenta coloring.
 */

namespace IGME105_HW_cda7733
{
    internal class Architecture
    {
        static void Main(string[] args)
        {
            
            GameSetup.Startup();
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            Player player4 = new Player();

            GameSetup.DetermineCreationAmount(player1, player2, player3, player4);


            /*
             * assign them in order, not random
            Utility.RollForFirstProperty();
            player1.RollForOrder();
            */

            while (Utility.GameOver == false)
            {
                Utility.GameplayLoop(player1, player2, player3, player4);
            }

            // add a diceroll here to determine player order and starting properties
            // first player's action turn
            // they can choose to open the menu, view their/their property info, trade, and roll the dice to progress
            // players can choose any number of actions until they roll, then
            // player lands on a space and triggers that event
            // player gets another action turn, mostlyyy same actions as before
            // players can choose to fight the space (IF it is a property space, otherwise the space would've already triggered)
            // ex. go space immediately upgrades ur card, chance/community chest immediately gives a card
            // players can't roll, just end their turn and pass to the next
            // second player's action turn
            // gameplay loop repeats from here until one player is left

            // these are js examples of methods being printed, later, they will be triggered by certain events/landings
        }
    }
}
