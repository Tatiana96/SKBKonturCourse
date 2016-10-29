using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Delegates
{
    // Task 3

    class ViewSystem : IObserver
    {
        private IReadOnlyList<IReadOnlyList<int>> cellsValues;

        public ViewSystem(IReadOnlyList<IReadOnlyList<int>> cellsValues)
        {
            this.cellsValues = cellsValues;
        }

        public void Update(IReadOnlyList<IReadOnlyList<int>> cellsValues)
        {
            try
            {
                // some blocks of code

                throw new NotImplementedException();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Realization in process...");
            }

        }

    }

}
