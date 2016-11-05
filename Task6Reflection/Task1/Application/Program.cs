using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Framework;
using System.IO;
using System.Linq.Expressions;

namespace Application
{
    class Program
    {
        
        static void Main(string[] args)
        {
            foreach (var element in Directory.GetFiles(new FileInfo(@"..\..\..\Solution\").FullName, "*.dll"))
            {
                var dllPlugin = Assembly.LoadFile(element);
                foreach (var type in dllPlugin.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IPlugin)))
                    {
                        var pluginInstance = (IPlugin)Activator.CreateInstance(type);
                        Console.WriteLine(pluginInstance.Name);
                    }                        
                }
            }

            Expression<Func<double, double>> exp = x => Math.Sin(2 * (x + 5));
            Console.WriteLine(Differentiator.Differentiate(exp));
        }
    }
}
