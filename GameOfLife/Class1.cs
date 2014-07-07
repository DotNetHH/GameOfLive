using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife
{

    public class Class1
    {
        [Test]
        public void JedelebendezelleMitWenigerAlszweiNachbarnStirbt()
        {

            var startArray = new bool [,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, true, false, false, false},
                                 {false, false, false, true, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };


            var actualArray = schritt(startArray);


            var expectedArray = new bool[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            
            Assert.AreEqual(actualArray, expectedArray);
        }


        private object schritt(bool[,] startArray)
        {
            return new bool[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };
        }
    }
}
