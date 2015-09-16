using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFirst.ReverseEngineered.PowerTools
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Power Tools hack for VS2015 by Julie Lerman:
        ///   http://thedatafarm.com/data-access/installing-ef-power-tools-into-vs2015/
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new TeamDemoContext())
            {
                context.DemoData.Add(new DemoData { Description = "Demo", Rating = 5 });
            }
        }
        
        
    }
}
