using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keywords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keywords.Tests
{
    [TestClass()]
    public class WordsTests
    {
        [TestMethod()]
        public void GetWordTest()
        {   
            Words words = new Words();

            var word = words.GetWord();

            Assert.IsNotNull(word); 
        }
    }
}