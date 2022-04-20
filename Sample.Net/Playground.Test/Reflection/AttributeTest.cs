using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test.Reflection
{
    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void Test1()
        {
            var type = typeof(People);

            var inh = type.GetCustomAttributes(true).Where(attr => attr is BaseAttribute).ToList();
            var notin = type.GetCustomAttributes(false);
            var a3 = type.GetCustomAttribute<TestRefAttribute>(false);
            // var a4 = type.GetCustomAttribute<BaseAttribute>(true);
        }
    }
}