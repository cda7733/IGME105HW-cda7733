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
 */

namespace IGME105_HW_cda7733
{
    internal class Architecture
    {
        static void Main(string[] args)
        {
            GameSetup.Startup();
            Player player1 = new Player();
            Player CPU1 = new Player(5);
            Player.PromptName(player1);
            Player.PromptToken(player1);
            Player.PromptColor(player1);
            Player.DisplayPlayerInfo(player1);

            // Utility.RollForMovement(player1,GameSetup.);

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
            DrawnCards.DisplayChanceCard(player1.PlayerName, 1, "advance to board walk! if you pass go, upgrade your weakest card!");
            DrawnCards.DisplayCommunityChestCard(player1.PlayerName, 6, "one of your properties got TPed! lose 5 property value for a random card.");
            Utility.IndividualVandalism();
            Utility.GroupVandalism();
            Utility.PropertyLanding(player1);
            Console.WriteLine("all methods have successfully been called!\n");
            
        }
    }
}
