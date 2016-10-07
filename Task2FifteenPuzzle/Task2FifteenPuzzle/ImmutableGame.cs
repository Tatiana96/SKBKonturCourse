using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2FifteenPuzzle
{
    public class ImmutableGame : Game, IGame
    {
        public ImmutableGame(params int[] valuesArray) : base(valuesArray)
        {
        }

        public ImmutableGame(ImmutableGame immutableGameObject) : base(immutableGameObject)
        {
        }

        public override IGame Shift(int value)
        {
            base.Shift(value);
            IGame ImmutableGameObject = new ImmutableGame(this);
            base.Shift(value);
            return ImmutableGameObject;
        }
    }
}
