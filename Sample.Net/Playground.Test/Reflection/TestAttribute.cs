using System;

namespace Playground.Test.Reflection
{
    [AttributeUsage(AttributeTargets.All)]
    public class BaseAttribute : Attribute
    {
        public string name { get; set; }
    }
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestRefAttribute : BaseAttribute
    {
        public int age { get; set; }
    }

    public class Test2RefAttribute : BaseAttribute
    {
        public int age { get; set; }
    }
    
    [TestRef(age = 10)]
    [Test2Ref(age = 10)]
    public class People
    {
        public string name { get; set; }

        public string Hello()
        {
            return $"hello {name}!";
        }
    }
}