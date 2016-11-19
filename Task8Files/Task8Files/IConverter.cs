using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Files
{
    interface IConverter
    {
        object Convert(string typeName, string value);
    }
}
