using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public class WarDeck : Deck<WarCard>
    {
        public int SuitCount = 4;
        public int cardsPerSuit = 14;

        public override void GenerateDeck()
        {
            // Creation of each card suite deck
            for (int k = 0; k < SuitCount; k++)
            {
                // Creation of the individual card
                for (int i = 1; i < cardsPerSuit; i++)
                {
                    deck.Add(new WarCard((Card.Suit)k, (Card.Face)i));
                }
            }
        }
        public override void ShuffleDeck()
        {
            Random randomNumberGenerator = new Random();

            for (int i = deck.Count - 1; i > 1; i--)
            {
                int randomNum = randomNumberGenerator.Next(i);

                WarCard warCard = deck[randomNum];
                deck[randomNum] = deck[i];
                deck[i] = warCard;

            }
        }
        public override WarCard DrawCard()
        {
            WarCard popCard = deck[0];
            deck.Remove(popCard);

            return (popCard);
        }
        public override void PlaceInDeck(WarCard c1, WarCard c2)
        {
            deck.Add(c1);
            deck.Add(c2);
            ShuffleDeck();
        }
        public override bool IsEmpty()
        {
            return (deck.Count <= 0);
        }
    }
}
