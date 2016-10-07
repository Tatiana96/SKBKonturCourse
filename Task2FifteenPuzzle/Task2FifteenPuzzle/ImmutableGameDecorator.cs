using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2FifteenPuzzle
{
    class ImmutableGameDecorator : ImmutableGame
    {
        private ImmutableGame ImmutableGameInitialVersion;
        private ImmutableGame ImmutableGameChangedVersion;
        private Stack<int> ShiftedMatrixValuesStack;
        public ImmutableGameDecorator(ImmutableGame immutableGame)
        {
            ImmutableGameInitialVersion = immutableGame;
            ImmutableGameChangedVersion = immutableGame;

            ShiftedMatrixValuesStack = new Stack<int>();
        }
        public int this[int x, int y]
        {
            get { return ImmutableGameChangedVersion[x, y]; }
        }
        public Index GetLocation(int value)
        {
            return ImmutableGameChangedVersion.GetLocation(value);
        }
        public ImmutableGameDecorator Shift(int value)
        {
            ImmutableGameChangedVersion = (ImmutableGame)ImmutableGameChangedVersion.Shift(value);
            ShiftedMatrixValuesStack.Push(value);

            return this;
        }
    }
}
