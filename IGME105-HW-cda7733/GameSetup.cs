using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGME105_HW_cda7733
{
    internal class GameSetup
    {
        string gameName = "";

        internal const int minPlayers = 2;
        internal const int maxPlayers = 4;
        internal const int maxSpaces = 40;
    }
    internal class BoardSetup : GameSetup
    {

    }

    internal class BoardMovement : BoardSetup
    {

    }
    /*
     * game set-up
                name: Battle Monopoly: Vandalism Edition
                genre: boardgame, card battler
                audience: teens - adults who are familiar w/ the gameplay of monopoly AND simple battle systems/they can do math
                goal: last one standing
                # of players: 2-4
                players start with one property, chosen from the 5 weakest
                    weakest = the starting strip
                    players can call dibs depending on their roll/order
                    {get rollValue} {set order}
                movement follows normal monopoly rules
                    two 6-sided die
                menu
                tutorial/rulebook
                player order
                    dice roll 1-12
                    ties are settled with rerolls from both players
                initialize property, chance, and community chest cards
                    make property arrays that store each card’s index, name, cost, pv, damage multiplier, upgrade value, and hotel upgrade value (these are elaborated on later)
                    // pv stands for property value!! it acts as a card’s hp
                trading with other players is allowed, but only if i can figure out how to code that
            internal Board()
                Roll() method
                    generate random number 2-12
                    return that number as an int
                    {set rollValue}
     */
}
