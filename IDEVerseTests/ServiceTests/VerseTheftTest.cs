using System;
using System.Linq;
using System.Threading.Tasks;
using IdeVerseContracts.Services;
using IDEVerseCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IDEVerseTests.ServiceTests
{
    [TestClass]
    public class VerseTheftTest
    {
        
        [TestMethod]
        public async Task CheckInterface()
        {
            var service = new VerseTheftService(); 
            var result = await service.GetRhymes("Трость");
            Console.WriteLine(result.Aggregate((x, acc) => acc + " " + x));
            Assert.IsTrue(result.Length > 0);
        }
        
    }
}