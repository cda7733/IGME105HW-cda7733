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
 * 10/30/2025 - changed the if statement in PropertySpace(..) to a ternary
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
        static string[] spaceNameArray = SpaceName.Split(',');
        internal static string[] SpaceNameArray
        {
            get { return spaceNameArray; }
            set { spaceNameArray = value; }
        }

        internal static string[] spaceType =
        {
            "GO","UP","CO","UP","TX","UP","UP","CH","UP","UP",
            "VS","UP","UT","UP","UP","UP","UP","CO","UP","UP",
            "UP","UP","CH","UP","UP","UP","UP","UP","UT","UP",
            "VS","UP","UP","CO","UP","UP","CH","UP","TX","UP",
        };
        internal static string[] SpaceType
        {
            get { return spaceType; }
            set {  spaceType = value; }
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
        }
        internal static void VandalismSpace(Player playerX)
        {
            Console.WriteLine("a free-for-all vandalism battle has been triggered!\n");
            
            // each player chooses a card to be in danger of being vandalized
            // player with the most amount of property damage done gets their property card full repaired
            // player w / the least amount of damage loses their property card
               // for player(s) in the middle, nothing happens
               // damage calculation is explained in detail later, but it’s basically card damage x diceroll
        }
        internal static void TaxSpace(Player playerX, Random rng)
        {
            // 1-5 damage
            int damagedValue = rng.Next(10);
            Console.WriteLine($"-{damagedValue} to their health..");
            if (damagedValue == 0)
            {
                Console.WriteLine("lucky!");
            }
            Console.WriteLine();
            playerX.CurrentHealth -= damagedValue;
            if (playerX.CurrentHealth <= 0)
            {
                playerX.CurrentHealth = 0;
                GameEngine.KillPlayer(playerX);
            }
        }
        internal static void UtilitySpace (Player playerX, Random rng)
        {
            // 1-20 healing
            int healedValue = rng.Next(10);
            Console.WriteLine($"+{healedValue} to their health!\n");
            if (healedValue == 0)
            {
                Console.WriteLine("unlucky..");
            }
            Console.WriteLine();
            playerX.CurrentHealth += healedValue;
            if (playerX.CurrentHealth > playerX.MaxHealth)
            {
                playerX.CurrentHealth = playerX.MaxHealth;
            }
        }
        internal static void PropertySpace(Player playerX)
        {
            string message = (PropertyCard.Owned[playerX.PlayerLocation] == true) ? "they landed on an owned property!\nand will now enter battle with the owner!\n":
            (PropertyCard.Owned[playerX.PlayerLocation] == false) ? "they have landed on an unowned property!\nand can damage the property to try and obtain it.\n":
            "!! error: ownership status unavailable.\n";
            Console.WriteLine(message);
        }
    }
}