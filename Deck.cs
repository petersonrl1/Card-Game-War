using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public abstract class Deck<Card>
    {
        public List<Card> deck;

        public Deck()
        {
            this.deck = new List<Card>();
        }
        //add stack for cards drawn in a round that results in War
        public abstract void GenerateDeck();
        public abstract void ShuffleDeck();
        public abstract Card DrawCard();
        public abstract void PlaceInDeck(Card c1, Card c2);
        //add method for cards won in a round that results in War
        public abstract bool IsEmpty();

    }
}
