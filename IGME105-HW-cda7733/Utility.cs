using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
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
    internal class Utility
    {
        internal string gameName = "battle monopoly: vandalism edition"; 

        internal const int minPlayers = 2;
        internal const int maxPlayers = 4;
        internal const int maxSpaces = 40;
    }
    internal class Setup : Utility
    {
        // methods and stuff stored here

        internal void Welcome()
        {
            Console.WriteLine(gameName);
        }

        // dicerolling, the die defaulted/start as 2 before the method is called
        internal int rolledValue = 2; 
        internal void DiceRoll()
        {
            // generate random number 1-12
            rolledValue = 12;
        }
        
        internal void IndividualBattle()
        {
            // battle method between players
        }
        internal void GroupVandalism()
        {
            // the method that's called when players trigger a vandalism event
        }
    }

    internal class BoardMovement : Setup
    {
        internal int[] playerLocation;
        internal int currentPlayer = 0;

        internal BoardMovement() 
        {
            // movement follows normal monopoly rules

            DiceRoll();
            playerLocation[currentPlayer] = playerLocation[currentPlayer] + rolledValue;
        }
    }
    internal class PlayerInfo : Setup
    {
        internal int playerIndex { get; set; }
        internal PlayerInfo()
        {
            // call diceroll to determine 
        }

    }
    internal class Gameplay : Setup
    {
        internal Gameplay()
        {
            /*
             * if ownershipStatus = 0, int cost = PropertyCost[i] 
                // cost regards not money, but how much damage a space can take before being acquired by a player
                    players do not have to attack the property
                    if they want the property, then Buy() method occurs
                        they do damage to the property and try to bring it to 0
                if ownershipStatus > 0, initiate Sabotage() between currentPlayer and player x
                    check if currentPlayer + 1 == ownershipStatus, so that they don’t sabotage/start combat with themselves
                        + 1 because indexing starts at 0
                            i think, maybe 
             */
        }
    }
    /*
     * game set-up
            menu
            tutorial/rulebook
            player order
                dice roll 1-12
                    ties are settled with rerolls from both players
            initialize property, chance, and community chest cards
            // pv stands for property value!! it acts as a card’s hp
     */
}
