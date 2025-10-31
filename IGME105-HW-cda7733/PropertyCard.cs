using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
 * 10/31/2025 - methods to changes ownership are lambdas now. and not all variables are read-only
 */

namespace IGME105_HW_cda7733
{
    internal static class PropertyCard
    {
        // variables & properties

        static int[] currentPropertyValue = 
        {
            10,10,10,10,10,15,10,10,10,10,
            20,15,15,15,15,20,15,15,15,15,
            20,20,20,20,20,25,20,20,20,20,
            25,25,25,25,25,30,25,25,25,25
        };
        internal static int[] CurrentPropertyValue
        {
            get { return currentPropertyValue; }
            set { currentPropertyValue = value; }
        }
        static int[] maxPropertyValue =
        {
            10,10,10,10,10,15,10,10,10,10,
            20,15,15,15,15,20,15,15,15,15,
            20,20,20,20,20,25,20,20,20,20,
            25,25,25,25,25,30,25,25,25,25
        };
        internal static int[] MaxPropertyValue
        {
            get { return maxPropertyValue; }
        }
        static int[] damageMultiplier =
        {
            1,1,1,1,1,2,1,1,1,1,
            1,2,2,2,2,3,2,2,2,2,
            3,3,3,3,3,4,3,3,3,3,
            4,4,4,4,4,5,4,4,4,4
        };
        internal static int[] DamageMultiplier
        {
            get { return damageMultiplier; }
        }
        static bool[] owned =
        {
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false,
            false,false,false,false,false,false,false,false,false,false
        };
        internal static bool[] Owned
        {
            get { return owned; }
            set { owned = value; }
        }

        static string[] propertyID =
        {
            "00","01","02","03","04","05","06","07","08","09",
            "10","11","12","13","14","15","16","17","18","19",
            "20","21","22","23","24","25","26","27","28","29",
            "30","31","32","33","34","35","36","37","38","39"
        };
    
        internal static string[] PropertyID
        {
            get { return propertyID; }
        }

        /* int houseUpgradeValue;
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
            get { return color; }
        } */


        /*  if owned:
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
        } */
        
        internal static Action<Player, int> ChangeToOwned = (playerX, index) => { owned[index] = true; Spaces.SpaceType[index] = "OP"; };
        internal static Action<Player, int> ChangeToUnowned = (playerX, index) => { owned[index] = false; Spaces.SpaceType[index] = "UP"; };
        internal static void AcquirePropertyCard(int playerNumber, Player playerX)
        {
            // first properties given
            // gives players one of the first row of properties, auto-equips it, and increases their owned property count
            switch (playerNumber)
            {
                case 1: playerX.OwnedProperties = "01"; ChangeToOwned(playerX, 01); Utility.EquipNewCard(playerX, 1); playerX.OwnedPropertyCount++; break;
                case 2: playerX.OwnedProperties = "03"; ChangeToOwned(playerX, 03); Utility.EquipNewCard(playerX, 3); playerX.OwnedPropertyCount++; break;
                case 3: playerX.OwnedProperties = "06"; ChangeToOwned(playerX, 06); Utility.EquipNewCard(playerX, 6); playerX.OwnedPropertyCount++; break;
                case 4: playerX.OwnedProperties = "08"; ChangeToOwned(playerX, 08); Utility.EquipNewCard(playerX, 8); playerX.OwnedPropertyCount++; break;
                default: Utility.DisplayError("!! error: invalid player index"); break;
            }
        }
        internal static void AcquirePropertyCard(Player playerX)
        {
            // gives players the property they're on and increases their owned property count
            playerX.OwnedPropertyCount++;
            playerX.OwnedProperties = playerX.OwnedProperties + "," + PropertyID[playerX.PlayerLocation];
            CurrentPropertyValue[playerX.PlayerLocation] = MaxPropertyValue[playerX.PlayerLocation];
            ChangeToOwned(playerX, playerX.PlayerLocation);
        }
    }
}