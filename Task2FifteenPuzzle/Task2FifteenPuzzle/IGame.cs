using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2FifteenPuzzle
{
    public interface IGame
    {
        Index GetLocation(int value);
        IGame Shift(int value);
        int this[int x, int y] { get; }
    }
}
