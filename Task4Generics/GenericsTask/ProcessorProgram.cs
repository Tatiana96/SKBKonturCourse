using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTask
{
    class ProcessorProgram
    {
        class MyEngine
        {
        }
        class MyEntity
        {
        }
        class MyLogger
        {
        }

        public static void Main()
        {
            var ProcessorObject = ProcessorCreator.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}
