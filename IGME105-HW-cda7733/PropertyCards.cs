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
 * 09/26/2025 - gave all variables a read-only property
 */

namespace IGME105_HW_cda7733
{
    internal class PropertyCards
    {
        // variables & properties
        // therye alllllll gets. 
        int propertyCardIndex = 0;
        internal int PropertyCardIndex
        {
            get { return propertyCardIndex; }
        }
        string propertyCardName;
        internal string PropertyCardName
        {
            get { return propertyCardName; }
        }
        int propertyValue;
        internal int PropertyValue
        {
            get { return propertyValue; }
        }
        int damageMultiplier;
        internal int DamageMultiplier
        {
            get { return damageMultiplier; }
        }
        int houseUpgradeValue;
        internal int HouseUpgradeValue
        {
            get { return houseUpgradeValue; }
        }
        int hotelUpgradeValue;
        internal int HotelUpgradeValue
        {
            get { return hotelUpgradeValue; }
        }
        string color;
        internal string Color
        {
            get { return  color; }
        }
        internal PropertyCards()
        {
            /*
             * PropertyCards()
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
}