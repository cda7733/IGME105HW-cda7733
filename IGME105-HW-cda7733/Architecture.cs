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
            Utility.Welcome();
            Utility.GameSetup(false);
            Player player1 = new Player();
            Player.PromptName(0, player1);
            Player.PromptToken(player1);
            DrawnCards.DisplayChanceCard(player1.PlayerName, 1, "advance to board walk! if you pass go, upgrade your weakest card!");
            DrawnCards.DisplayCommunityChestCard(player1.PlayerName, 6, "one of your properties got TPed! lose 5 property value for a random card.");
            Utility.RollForMovement(player1);
            Utility.IndividualVandalism();
            Utility.GroupVandalism();
            Utility.PropertyLanding(player1.PlayerName);
            Console.WriteLine("all methods have successfully been called!\n");
        }
    }
}
