using System;

// program name: IGME105 monopoly game
// created by: charisma allen
// purpose: make a monopoly game but w/ gambling
/* modifications: 
 * 09/03/2025 = created file, made psuedocode for tic-tac-toe
 * 09/08/2025 = replaced tictactoe w/ monopoly
 * 09/12/2025 = monopoly pseudocode
 */

namespace IGME105HW_cda
{
	internal class Architecture
	{
		internal Architecture()
		{
            /*
             
             game set-up
                name: Battle Monopoly: Vandalism Edition
                genre: boardgame, card battler
                audience: teens - adults
                goal: last one standing
                # of players: 2-4
                players start with one property, chosen from the 5 weakest
                    weakest = the starting strip
                    players can call dibs depending on their roll/order
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
            Board()
                Roll() method
                    generate random number 2-12
                    return that number as an int
            Spaces() 
                VandalizeSpace()
                    starts VandalismEvent()
                        each player chooses a card to be in danger of being vandalized
                        player with the most amount of property damage done gets their property card full healed
                        player w/ the least amount of damage loses their property card
                        for player(s) in the middle, nothing happens
                        // damage calculation is explained in detail later, but it’s basically card damage x diceroll
                PropertySpace()
                    int ownershipStatus = 0 
                        // all property spaces are set to 0 at the start of the game, meaning they are unowned and players can acquire them
                    if ownershipStatus = 0, int cost = PropertyCost[i] 
                    // cost regards not money, but how much damage a space can take before being acquired by a player
                        players do not have to attack the property
                        if they want the property, then Buy() method occurs
                            they do damage to the property and try to bring it to 0
                    if ownershipStatus > 0, initiate Sabotage() between currentPlayer and player x
                        check if currentPlayer + 1 == ownershipStatus, so that they don’t sabotage/start combat with themselves
                            + 1 because indexing starts at 0
                                i think, maybe
                    // more info below
                GoSpace()
                    players get a free property upgrade for their weakest card
                CommunityChestSpace()
                    pull community chest card, CommunityChestCard() method
                    // cards are reusable / put back into the deck
                ChanceSpace()
                    pull chance card, ChanceCard() method
                    // these cards are also reused
                PropertyValueSpaces()
                    call Roll() method after landing on a space
                TaxSpace()
                    subtract pv from any one card based on diceroll amount (1-12)
                UtilitySpace()
                    add pv to any one card based on diceroll amount (1-12)
            Player()
                Token()
                base monopoly tokens: 
                    dog, cat, car, thimble, boat, shoe, tophat, wheelbarrow
                int order (from a dice roll in the beginning of the game)
                string name (token name used for placeholder is the player is lazy)
                    if the input for name is left blank and the player picked a thimble for their token, their name will be thimble
            PropertyCards()
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
                ex. set houseUpgrades = 5, and hotelUpgrades = 2. with each house, the pv increases from 5, 10, 15, 20, 25, 30. when players can no longer buy any houses (capped at four), players can buy a hotel. hotel pv calculation is 5 x 2. +10 pv for a hotel, as opposed to +5 for houses. hotels are the final upgrade.

             
             
             */
        }
    }
}