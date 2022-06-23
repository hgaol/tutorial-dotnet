using System.Linq;
using System.Reflection;
using Xunit;

namespace Playground.Test.Reflection
{
    public class AttributeTest
    {
        [Fact]
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