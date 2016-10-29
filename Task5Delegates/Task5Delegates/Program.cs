using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // test block

            Spreadsheet spreadsheetObject = new Spreadsheet();

            for (int x = 0; x < 3; x++)
            {
                spreadsheetObject.InsertRow(x);

                for (int y = 0; y < 3; y++)
                {
                    spreadsheetObject.InsertColumn(y);
                }
            }

            LoggingSystem systemObject = new LoggingSystem( new ReadOnlyCollection< List<int> >(spreadsheetObject.CellsValues) );

            spreadsheetObject.AddObserver(systemObject);

            spreadsheetObject.Put(1, 2, 3);
            int result = spreadsheetObject.Get(1, 2);

            Console.WriteLine("Test value: " + result); // 3
            Console.ReadLine();

        }

    }
}
