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
 * 10/24/2025 - the game works for most things. win conditions, property acquisition, cards, etc.
 */

namespace IGME105_HW_cda7733
{
    internal class Architecture
    {
        static void Main(string[] args)
        {
            
            GameSetup.Startup();

            Player player1 = new Player();  Player player2 = new Player();
            Player player3 = new Player();  Player player4 = new Player();

            // collectible properties
            // i know this probably takes up a billion memory, but it's the only way i got it working with what we were taught so far </3

            /*
            PropertyCard propertydeed01 = new PropertyCard();   PropertyCard propertydeed03 = new PropertyCard();
            PropertyCard propertydeed05 = new PropertyCard();   PropertyCard propertydeed06 = new PropertyCard();
            PropertyCard propertydeed08 = new PropertyCard();   PropertyCard propertydeed09 = new PropertyCard();
            PropertyCard propertydeed11 = new PropertyCard();   PropertyCard propertydeed13 = new PropertyCard();
            PropertyCard propertydeed14 = new PropertyCard();   PropertyCard propertydeed15 = new PropertyCard();
            PropertyCard propertydeed16 = new PropertyCard();   PropertyCard propertydeed18 = new PropertyCard();
            PropertyCard propertydeed19 = new PropertyCard();   PropertyCard propertydeed21 = new PropertyCard();
            PropertyCard propertydeed23 = new PropertyCard();   PropertyCard propertydeed24 = new PropertyCard();
            PropertyCard propertydeed25 = new PropertyCard();   PropertyCard propertydeed26 = new PropertyCard();
            PropertyCard propertydeed27 = new PropertyCard();   PropertyCard propertydeed29 = new PropertyCard();
            PropertyCard propertydeed31 = new PropertyCard();   PropertyCard propertydeed32 = new PropertyCard();
            PropertyCard propertydeed34 = new PropertyCard();   PropertyCard propertydeed35 = new PropertyCard();
            PropertyCard propertydeed37 = new PropertyCard();   PropertyCard propertydeed39 = new PropertyCard(); 
            */

            GameSetup.DetermineCreationAmount(player1, player2, player3, player4);
            
            // this is the whole game
            while (Utility.GameOver == false)
            {
                Utility.GameplayLoop(player1, player2, player3, player4);
            }
        }
    }
}
