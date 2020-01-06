using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public abstract class Card
    {
        public enum Suit { Spades = 0, Hearts, Clubs, Diamonds };
        public enum Face { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

        public Suit suit;
        public Face face;

        public Card(Suit s, Face f)
        {
            this.suit = s;
            this.face = f;
        }

        public abstract void PrintCard();
        public abstract int GetFaceValue();
    }
}
