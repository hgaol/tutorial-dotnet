using System;
using System.Linq;

namespace Playground.Reflection
{
    public class ReflectionDemo
    {
        public static void Run()
        {
            Type type = typeof(People);
            var instance = Activator.CreateInstance(type);
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
                if (method.Name.StartsWith("set_name"))
                {
                    method.Invoke(instance, new[] {"Hello"});
                }
            }

            Console.WriteLine(((People)instance).name);
        }

        public class People
        {
            public string name { get; set; }
            public string sex { get; set; }
            public int age { get; set; }
        }
    }
}