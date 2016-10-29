using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Delegates
{
    // Task 3

    public interface IObserver
    {
        void Update(IReadOnlyList< IReadOnlyList<int> > cellsValues);

    }
}
