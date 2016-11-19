using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Dynamic;

namespace Task8Files
{
    class ReadCsv
    {
        private readonly IConverter converterInterface;

        public ReadCsv(IConverter converter)
        {
            converterInterface = converter;
        }


        // ReadCsv1 Task
        public IEnumerable<string[]> ReadCsv1(string pathToFile)
        {
            Func<string[], string[], string[]> function = (header, line) =>
                line.Select(x => x == "NA" ? null : x).ToArray();

            return ExecuteYieldOperation(pathToFile, function);
        }


        // ReadCsv2 Task
        public IEnumerable<T> ReadCsv2<T>(string pathToFile) where T : new()
        {
            var propertiesInformation = typeof(T).GetProperties();

            Func<string[], string[], T> function = (header, line) =>
            {

                Action<T, string, string> action = (result, headerName, lineName) =>
                {
                    var propertyInformation = GetPropertyInformation(propertiesInformation, headerName);
                    var convertedValue = converterInterface.Convert(propertyInformation.Name, lineName);
                    propertyInformation.SetValue(result, convertedValue);
                } ;

                return ExecuteLineOperation(header, line, action);

            } ;

            return ExecuteYieldOperation(pathToFile, function);
        }

        private static PropertyInfo GetPropertyInformation(PropertyInfo[] propertiesInformation, string name)
        {
            var propertyInformation = propertiesInformation.FirstOrDefault(x => x.Name == name);
            if (propertyInformation == null)
                throw new ArgumentException("Property is absent.");

            return propertyInformation;
        }


        // ReadCsv3 Task

        public IEnumerable<Dictionary<string, object>> ReadCsv3(string pathToFile)
        {
            Func<string[], string[], Dictionary<string, object>> function = (header, line) =>
            {
                Action<Dictionary<string, object>, string, string> action =
                    (result, headerName, lineName) =>
                    {
                        var convertedValue = converterInterface.Convert(headerName, lineName);
                        result.Add(headerName, convertedValue);
                    } ;

                return ExecuteLineOperation(header, line, action);
            } ;

            return ExecuteYieldOperation(pathToFile, function);

        }


        // ReadCsv4 Task

        public IEnumerable<dynamic> ReadCsv4(string pathToFile)
        {
            Func<string[], string[], dynamic> function = (header, line) =>
            {
                IDictionary<string, object> DictionaryForCsv = null;
                Action<dynamic, string, string> action = (result, headerName, lineName) =>
                {
                    if (DictionaryForCsv == null)
                        DictionaryForCsv = result as IDictionary<string, object>;

                    var convertedValue = converterInterface.Convert(headerName, lineName);
                    DictionaryForCsv?.Add(headerName, convertedValue);
                };
                return ExecuteLineOperation<ExpandoObject>(header, line, action);
            };
            return ExecuteYieldOperation(pathToFile, function);
        }



        private static IEnumerable<T> ExecuteYieldOperation<T>(string pathToFile, Func<string[], string[], T> function)
        {
            using (var stream = new StreamReader(pathToFile))
            {
                var header = GetHeader(stream);
                while (true)
                {
                    var line = stream.ReadLine();

                    if (line == null)
                        yield break;

                    yield return function(header, line.Split(','));
                }
            }
        }

        private static string[] GetHeader(StreamReader stream)
        {
            var line = stream.ReadLine();
            if (line == null)
                throw new ArgumentException("Header is missed.");

            return line.Replace("\"", "").Split(',');
        }


        private static T ExecuteLineOperation<T>(string[] header, string[] line, Action<T, string, string> action)
            where T : new()
        {
            if (header.Length != line.Length)
                throw new ArgumentException("Csv file is invalid");

            var result = new T();
            for (var i = 0; i < header.Length; i++)
                action(result, header[i], line[i]);

            return result;
        }



    }
}
