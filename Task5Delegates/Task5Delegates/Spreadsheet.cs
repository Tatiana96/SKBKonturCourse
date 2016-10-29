using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Delegates
{
    // Task 3

    class Spreadsheet
    {
        public List< List<int> > CellsValues { get; private set; }
        private List<IObserver> observers = new List<IObserver>();

        public Spreadsheet()
        {
            CellsValues = new List< List<int> >();
        }

        public void Put(int row, int column, int value)
        {
            CellsValues[row][column] = value;
            NotifyObservers();
        }

        public void InsertRow(int rowIndex)
        {
            CellsValues.Insert( rowIndex, new List<int>() );
            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            for (int i = 0; i < CellsValues.Count; i++)
            {
                CellsValues[i].Insert( columnIndex, default(int) );
            }
            NotifyObservers();
        }

        public int Get(int row, int column)
        {
            return CellsValues[row][column];
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(CellsValues);
            }
        }

    }

}
