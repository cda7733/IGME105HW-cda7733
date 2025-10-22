using IGME105_HW_cda7733;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Lifetime;
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
 * 10/15/2025 - added a bunch of methods for each space. they basically js print to console.
 */

namespace IGME105_HW_cda7733
{
    // 
    internal static class Spaces
    {
        // variables & properties

        static string spaceName = "go,mediterranian ave.,community chest,baltic ave.,income tax,reading railroad,oriental ave.,chance,vermont ave.,connecticut ave.,vandalism,st. charles place,electric company,states ave.,virginia ave.,pennysylvania railroad,st. james place,community chest,tennessee ave.,new york ave.,free repairs,kentucky ave.,chance,indiana ave.,illinois ave.,B & O railroad,atlantic ave.,ventour ave.,water works,marvin gardens,vandalism,pacific ave.,north carolina ave.,community chest,pennysylania ave.,short line,chance,park place,luxury tax,boardwalk";
        internal static string SpaceName
        {
            get { return spaceName; }
            set { spaceName = value; }
        }
        internal static string DisplayPropertyName(int index)
        {
            string[] spaceNameArray = SpaceName.Split(',');
            return spaceNameArray[index];
        }

        internal static void GoSpace(Player playerX)
        {
            if (playerX.TurnCount != 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("they passed go! collect a free upgrade!\n");
                Console.ResetColor();
            }
            // players get a free property upgrade for their weakest card
            // get RNG, set max to the amount of cards they have
        }
        internal static void VandalismSpace()
        {
            Console.WriteLine("a free-for-all vandalism battle has been triggered!\n");
            // each player chooses a card to be in danger of being vandalized
            // player with the most amount of property damage done gets their property card full repaired
            // player w / the least amount of damage loses their property card
               // for player(s) in the middle, nothing happens
               // damage calculation is explained in detail later, but it’s basically card damage x diceroll
        }
        internal static void TaxSpace(Random rng)
        {
            // 1-20 damage
            int damagedValue = rng.Next(20);
            Console.WriteLine($"-{damagedValue} property value to one of their cards..\n");
        }
        internal static void UtilitySpace (Random rng)
        {
            // 1-20 healing
            int healedValue = rng.Next(20);
            Console.WriteLine($"+{healedValue} property value to one of their cards!\n");
        }


        internal static void PropertySpace()
        {

            bool owned = false;
            if (owned == true)
            {
                Console.WriteLine("they landed on an owned property!\nand will now enter battle with the owner!\n");
            }
            else if (owned == false)
            {
                Console.WriteLine("they have landed on an unowned property!\nand can damage the property to try and obtain it.\n");
            }
            else
            {
                Utility.DisplayError("!! error: ownership status unavailable.\n");
            }
            /*
             * all property spaces are set to 0 at the start of the game, meaning they are unowned and players can acquire them
               if unowned:
                    property cards have a set property value, and a 0 damage multiplier
                        players can only take damage from community chest cards and other players, never from unowned property spaces
                players can attack a card on their turn
                    they can choose not to attack it if no other player owns it
                damage done to property carries over between players
                whoever does the finishing blow, get the card
             */
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
}