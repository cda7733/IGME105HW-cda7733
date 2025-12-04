using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static IGME105_HW_cda7733.DrawnCards;

namespace IGME105_HW_cda7733
{
    internal abstract class DrawnCards
    {
        internal int cardIndex = 0;
        internal string[] cardText;
        internal string[] cardName;
        internal bool immediateUse = true;
        internal int RandomizeCard()
        {
            return Utility.RNG.Next(0, Utility.CardQuantity);
        }
        internal abstract bool GetUseBool();
        internal abstract void Action(Player playerX, List<Player> players);
        internal abstract int ReadCardIndex();
        internal abstract string ReadCardText();
        internal abstract string ReadCardName();
        internal void PlusPropertyValue(Player playerX, int healedValue)
        {
            playerX.CurrentHealth += healedValue;
            if (playerX.CurrentHealth > playerX.MaxHealth)
            {
                playerX.CurrentHealth = playerX.MaxHealth;
            }
        }
        internal class ChanceCard : DrawnCards
        {
            internal ChanceCard(Player playerX, List<Player> players)
            {

            }
            internal new int cardIndex = Utility.RNG.Next(Utility.CardQuantity);
            internal new string[] cardText =
            {
                "take a catch a train on the reading railroad!",
                "pulling this card triggered a vandalism event!",
                "pay back your debts! -1 for each person (and +1 for them)",
                "advance to the nearest railroad!",
                "pulling this card made you trip and fall back 3 spaces!",
                "advance to the nearest utility space!",
                "advance to illinois avenue!",
                "advance to boardwalk!"
            };

            internal new string[] cardName =
            {
                "reading railroad ticket",
                "vandalism trigger",
                "debt repayment",
                "ticket for the nearest railroad",
                "trip and fall",
                "walk to the nearest utility space",
                "walk to illinois avenue",
                "walk to boardwalk"
            };
            internal new bool immediateUse;
            internal override bool GetUseBool()
            {
                switch (cardIndex)
                {
                    case 0: immediateUse = true; break;
                    case 1: immediateUse = true; break;
                    case 2: immediateUse = true; break;
                    case 3: immediateUse = true; break;
                    case 4: immediateUse = true; break;
                    case 5: immediateUse = true; break;
                    case 6: immediateUse = true; break;
                    case 7: immediateUse = true; break;
                    default: break;
                }
                return immediateUse;
            }
            internal override int ReadCardIndex()
            {
                return cardIndex;
            }
            internal override string ReadCardText()
            {
                return cardText[cardIndex];
            }
            internal override string ReadCardName()
            {
                return cardName[cardIndex];
            }
            
            internal override void Action(Player playerX, List<Player> players)
            {
                int actionIndex = cardIndex;
                switch (actionIndex)
                {
                    case 0: Travel(playerX, 5); break;
                    case 1: Spaces.VandalismSpace(playerX); break;
                    case 2: RepayDebts(playerX, players); break;
                    case 3: TravelNearest(playerX, "RR"); break;
                    case 4: playerX.PlayerLocation =- 3; Utility.CyclePlayerLocation(playerX); break;
                    case 5: TravelNearest(playerX, "UT"); break;
                    case 6: Travel(playerX, 24); break;
                    case 7: Travel(playerX, 39); break;
                    default: break;
                }
            }
            internal void RepayDebts(Player playerX, List<Player> players)
            {
                foreach (Player player in players)
                {
                    player.CurrentHealth++;
                    if (player.CurrentHealth > player.MaxHealth)
                    {
                        player.CurrentHealth = player.MaxHealth;
                    }
                }
                playerX.CurrentHealth -= players.Count;
                if (playerX.CurrentHealth <= 0)
                {
                    playerX.CurrentHealth = 0;
                    GameEngine.KillPlayer(playerX);
                }
            }
            internal void Travel(Player playerX, int destination)
            {
                // go to a space and pass go
                if (playerX.PlayerLocation < destination)
                {
                    playerX.PlayerLocation = destination;
                }
                else
                {
                    playerX.PlayerLocation = 0;
                    playerX.PlayerLocation = destination;
                }
                Console.WriteLine();
            }
            internal void TravelNearest(Player playerX, string spaceType)
            {
                if (spaceType == "RR")
                {
                    if (playerX.PlayerLocation <= 5)
                    {
                        playerX.PlayerLocation = 5;
                    }
                    else if (playerX.PlayerLocation <= 15)
                    {
                        playerX.PlayerLocation = 15;
                    }

                    else if (playerX.PlayerLocation <= 25)
                    {
                        playerX.PlayerLocation = 25;
                    }
                }
                else if (spaceType == "UT")
                {
                    if (playerX.PlayerLocation <= 12)
                    {
                        playerX.PlayerLocation = 12;
                    }
                    else
                    {
                        playerX.PlayerLocation = 28;
                    }
                }
            }

        }
        internal class ChestCard : DrawnCards
        {
            internal ChestCard(Player playerX, List<Player> players)
            {

            }
            internal new int cardIndex = Utility.RNG.Next(Utility.CardQuantity);
            internal new string[] cardText =
            {
                "once activated, you will be excluded from the next vandalism event.",
                "pulling this card triggered a vandalism event!",
                "you recieve inheritance from a distant family member! +5 property value",
                "it seems that you invested in the right stock! +5 property value",
                "life insurance matures. +1 property value",
                "charge your tenants to increase property value by 5",
                "you won second place in an eating contest! +1 property value",
                "debt collector",
            };
            internal new string[] cardName =
            {
                "insurance",
                "vandalism trigger",
                "+5 from inheritance",
                "+5 from stocks",
                "+1 life insurance matures",
                "+5 from being a landlord",
                "+1 from eating contest",
                "collect on debts from all other players! +1 for each person (and -1 for them)",
            };
            internal override bool GetUseBool()
            {
                switch (cardIndex)
                {
                    case 0: immediateUse = false; break;
                    case 1: immediateUse = true; break;
                    case 2: immediateUse = true; break;
                    case 3: immediateUse = true; break;
                    case 4: immediateUse = true; break;
                    case 5: immediateUse = false; break;
                    case 6: immediateUse = true; break;
                    case 7: immediateUse = true; break;
                    default: break;
                }
                return immediateUse;
            }
            internal override int ReadCardIndex()
            {
                return cardIndex;
            }
            internal override string ReadCardText()
            {
                return cardText[cardIndex];
            }
            internal override string ReadCardName()
            {
                return cardName[cardIndex];
            }
            internal override void Action(Player playerX, List<Player> players)
            {
                int actionIndex = cardIndex;
                switch (actionIndex)
                {
                    case 0: Console.WriteLine("insurance activated!"); break; // store
                    case 1: Spaces.VandalismSpace(playerX); break;
                    case 2: PlusPropertyValue(playerX, 5); break;
                    case 3: PlusPropertyValue(playerX, 5); break;
                    case 4: PlusPropertyValue(playerX, 1); break;
                    case 5: PlusPropertyValue(playerX, 5); break; // store
                    case 6: PlusPropertyValue(playerX, 1); break;
                    case 7: CollectDebts(playerX, players); break;
                    default: break;
                }
            }

            internal void CollectDebts(Player playerX, List<Player> players)
            {
                foreach (Player player in players)
                {
                    player.CurrentHealth--;
                    if (player.CurrentHealth <= 0)
                    {
                        player.CurrentHealth = 0;
                        GameEngine.KillPlayer(player);
                    }
                }
                playerX.CurrentHealth += players.Count;
                if (playerX.CurrentHealth > playerX.MaxHealth)
                {
                    playerX.CurrentHealth = playerX.MaxHealth;
                }
                Console.WriteLine("you collected your debts!"); 
            }
            internal void MinusPropertyValue(Player playerX)
            {

            }
        }
    }
}
