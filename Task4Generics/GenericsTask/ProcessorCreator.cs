using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTask
{
    class ProcessorCreator
    {
        public static ProcessorCreator<TEngine> CreateEngine<TEngine>()
        {
            Console.WriteLine("CreateEngine");
            return new ProcessorCreator<TEngine>();
        }
    }
    class ProcessorCreator<TEngine>
    {
        public ProcessorCreator<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorCreator<TEngine, TEntity>();
        }
    }
    class ProcessorCreator<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
