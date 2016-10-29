using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Delegates
{
    // Task 3

    class LoggingSystem : IObserver
    {

        private IReadOnlyList< IReadOnlyList<int> > cellsValues;

        public LoggingSystem(IReadOnlyList< IReadOnlyList<int> > cellsValues)
        {
            this.cellsValues = cellsValues;
        }

        public void Update(IReadOnlyList<IReadOnlyList<int>> cellsValues)
        {

            this.cellsValues = cellsValues;

        }

    }

}
