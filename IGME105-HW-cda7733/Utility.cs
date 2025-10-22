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
 * 09/26/2025 - gave variables properties, all methods do somethingg
 * 10/10/2025 - added roll for movement & first property
 * 10/15/2025 - added a switch case block to trigger space events
 */

namespace IGME105_HW_cda7733
{
    internal class Utility
    {
        // variables & properties
        
        int currentNumberOfPlayers;
        internal int CurrentNumberOfPlayers
        {
            get { return currentNumberOfPlayers; }
            set { currentNumberOfPlayers = value; }
        }
        int currentPlayerIndex = 0;
        internal int CurrentPlayerIndex
        {
            get { return currentPlayerIndex; }
            set { currentPlayerIndex = value; }
        }

        // methods
        
        internal static void RollForFirstProperty()
        {
            int diceRoll = GameSetup.RNG.Next(0,5);
            // Console.WriteLine($"you get the {diceRoll + 1}st/nd/rd/th property");
        }
        internal static void CyclePlayerIndex(string option, Player playerX, int currentMaxPlayers)
        {
            // 0 is previous, 1 is next
            if (option == "increase")
            {
                if (playerX.PlayerIndex < currentMaxPlayers)
                {
                    playerX.PlayerIndex++;
                }
                else
                {
                    playerX.PlayerIndex = 0;
                }
            }
            else if (option == "decrease")
            {
                if (playerX.PlayerIndex < currentMaxPlayers)
                {
                    playerX.PlayerIndex++;
                }
                else
                {
                    playerX.PlayerIndex = 0;
                }
            }
        }
        internal static void ColorPicker (int colorIndex)
        {

            switch (colorIndex)
            {

                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    break;
            }
        }
        internal static void DisplayAvailableColors()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. red");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. orange");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. yellow");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("3. cyan");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("4. blue");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("5. purple");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("6. pink");
            Console.ResetColor();
            Console.WriteLine("7. white");
        }

    }
}