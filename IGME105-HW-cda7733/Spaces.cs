using IGME105_HW_cda7733;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal class Spaces
    {
        internal string spaceName;
        // variable and property for spaceIndex
        protected int spaceIndex;
        internal int SpaceIndex { get { return spaceIndex; } set { spaceIndex = value; } }
    }
    internal class GoSpace : Spaces
    {
        GoSpace()
        {
            spaceIndex = 0;
        }

        internal void PassGo()
        {
            // players get a free property upgrade for their weakest card
        }
    }
    internal class PropertySpaces : Spaces
    {
        // all property spaces are set to 0 at the start of the game, meaning they are unowned and players can acquire them
        int ownershipStatus = 0;
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
            if owned:
                // order doesn’t factor into damage calculation, but the player who landed on the space rolls first
                // combat in this edition of the game is called sabotaging
                the player who lands on a space can choose which card they would like to fight with from their own deck
                the player whose property was landed on can only fight with that card
                damage is calculated for each player
                Roll()    // for each player
                    attackersDamage = diceroll x chosen card damage ()
                    defendersDamage = diceroll x defending card damage
                    PropertyValue[defending card index] - attackersDamage
                    PropertyValue[attacking card index] - defendersDamage
                if player cards, at any point, reach 0, that card is eliminated from the game. it cannot be repurchased on its property space. 
            string color
                if players own multiple properties of the same color, damage is x2 or x3
                train stations are unique. one train station → 1x multiplier, two train stations → 2x, three train stations → 4x, four train stations (max) → 7x
            integer stats to replace rent
                // apply to every property card
                int pv = PropertyPV[i] 
                int damage = PropertyDamage[i]
                multiply by dice roll. low level cards have a x1 multiplier. the highest multiplier is x6. 
                int houseUpgrades (how much each house upgrade increases pv)
                int hotelUpgrades (multiply it with houseUpgrades)
             */
        }
    }
    internal class VandalismSpaces : Spaces
    {
        // constructor
        internal VandalismSpaces(int index)
        {
            spaceName = "vandalize!";
            spaceIndex = index;
        }

        internal void VandalismEvent()
        {
            // starts vandalism event

            /*
             * each player chooses a card to be in danger of being vandalized
               player with the most amount of property damage done gets their property card full healed
               player w/ the least amount of damage loses their property card
               for player(s) in the middle, nothing happens
               damage calculation is explained in detail later, but it’s basically card damage x diceroll
             */
        }
    }
    /*
                CommunityChestSpaces:Spaces
                    pull community chest card, CommunityChestCard() method
                    // cards are reusable / put back into the deck
                ChanceSpaces:Spaces
                    pull chance card, ChanceCard() method
                    // these cards are also reused
                PropertyValueSpaces:Spaces
                    call Roll() method after landing on a space
                TaxSpaces:Spaces
                    subtract pv from any one card based on diceroll amount (1-12)
                UtilitySpaces:Spaces
                    add pv to any one card based on diceroll amount (1-12)
         */
}