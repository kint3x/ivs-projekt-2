using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Test
    {
        [TestClass]
        public class Test
        {
            [TestMethod]
            public void TestAdd()
            {
                int vysledek = obj.Add(1, 1);
                Assert.AreEqual(20, vysledek);
            }

        }
    }
}
