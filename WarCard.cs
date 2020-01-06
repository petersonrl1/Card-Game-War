using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public class WarCard : Card
    {
        public WarCard(Suit s, Face f) : base(s, f)
        {
        }

        public override void PrintCard()
        {
            throw new NotImplementedException();
        }
        public override int GetFaceValue()
        {
            //return the enum object
            return ((int)suit);
        }
    }
}
