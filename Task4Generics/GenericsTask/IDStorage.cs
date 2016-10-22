using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTask
{
    class IDStorage
    {
        private Dictionary< Type, Dictionary<Guid, Object> > database;

        public IDStorage()
        {
            database = new Dictionary< Type, Dictionary<Guid, Object> >();
        }

        public T CreateObject<T>()
            where T : new()
        {
            T objectItem = new T();

            if ( !database.ContainsKey( typeof(T) ) )
            {
                database[typeof(T)] = new Dictionary<Guid, Object>();
            }

            database[typeof(T)][Guid.NewGuid()] = objectItem;

            return objectItem;
        }

        public Dictionary<Guid, Object> GetPairsOfType<T>()
        {
            if ( database.ContainsKey( typeof(T) ) )
            {
                Dictionary<Guid, Object> pairs = new Dictionary<Guid, Object>( database[typeof(T)] );
                return pairs;
            }
            else
            {
                return null;
            }
        }

        public T GetObjectByGuid<T>(Guid guid)
        {
            if ( database.ContainsKey( typeof(T) ) )
            {
                if ( database[typeof(T)].ContainsKey(guid) )
                {
                    return (T)database[typeof(T)][guid];
                }
            }

            return default(T);
        }

    }
}
