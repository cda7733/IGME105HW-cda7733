using IGME105_HW_cda7733;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    // 
    internal class Spaces
    {
        // variables & methods
        string spaceName;
        internal string SpaceName
        {
            get { return spaceName; }
        }
        int spaceIndex;
        internal int SpaceIndex 
        { 
            get { return spaceIndex; } 
            set { spaceIndex = value; } 
        }

    }
    // classes
    internal class GoSpace : Spaces
    {
        GoSpace()
        {
            SpaceIndex = 0;
        }

        internal void PassGo()
        {
            // players get a free property upgrade for their weakest card
        }
    }
    internal class PropertySpaces : Spaces
    {
        // all property spaces are set to 0 at the start of the game, meaning they are unowned and players can acquire them
        internal int ownershipStatus = 0;
        internal int cost;
        internal PropertySpaces(int index)
        {
            /*
             * PropertyCards()
                if unowned:
                    property cards have a set property value, and a 0 damage multiplier
                        players can only take damage from community chest cards and other players, never from unowned property spaces
                players can attack a card on their turn
                    they can choose not to attack it if no other player owns it
                damage done to property carries over between players
                whoever does the finishing blow, get the card
             */
        }
    }
    internal class VandalismSpaces : Spaces
    {
        // constructor
        VandalismSpaces(int index)
        {
            SpaceIndex = index;
        }

        internal void VandalismEvent()
        {
            // starts vandalism event

            /*
             * each player chooses a card to be in danger of being vandalized
               player with the most amount of property damage done gets their property card full repaired
               player w/ the least amount of damage loses their property card
               for player(s) in the middle, nothing happens
               damage calculation is explained in detail later, but it’s basically card damage x diceroll
             */
        }
    }

    // community chest & chance cards are reused / put back into the deck
    internal class CommunityChestSpaces : Spaces
    {
        internal CommunityChestSpaces(int index)
        {
            SpaceIndex = index;
        }
        internal void PullCommunityChest()
        {
            // pull community chest card, CommunityChestCard() method
        }
    }
    
    internal class ChanceCardSpaces : Spaces
    {
        internal ChanceCardSpaces(int index)
        {
            SpaceIndex = index;

        }
        internal void PullChanceCard()
        {
            // pull chance card, DisplayChanceCard
        }
    }

    internal class TaxSpaces : Spaces
    {
        int taxValue = 5;
        internal TaxSpaces(int index)
        {
            // TaxSpaces:Spaces
              // subtract pv from any one card based on diceroll amount(1 - 12)
        }
    }
    internal class UtilitySpaces : Spaces
    {
        int utilityValue = 5;
        internal UtilitySpaces()
        {
            //UtilitySpaces:Spaces
              // add pv to any one card based on diceroll amount(1 - 12)
        }
    }
}