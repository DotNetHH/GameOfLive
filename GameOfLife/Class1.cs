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

        [Test]
        public void JedeEinzelneLebendeZelleStirbt()
        {
            var startArray = new bool[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, true, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
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

        [Test]
        public void JedeEinzelneLebendeZelleStirbt2()
        {
            var startArray = new bool[,]
                             {
                                 {true, true, false, true, false, false, false, false},
                                 {true, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            var expectedArray = new bool[,]
                             {
                                 {true, true, false, false, false, false, false, false},
                                 {true, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };
            var actualArray = schritt(startArray);

            Assert.AreEqual(actualArray, expectedArray);
        }

        [Test]
        public void JedeEinzelneLebendeZelleStirbt3()
        {
            var startArray = new bool[,]
                             {
                                 {true, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            var expectedArray = new bool[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };
            var actualArray = schritt(startArray);

            Assert.AreEqual(actualArray, expectedArray);
        }

        private object schritt(bool[,] startArray)
        {
            if (startArray[0, 0])
            {
                return new bool[,]
                {
                    {true, true, false, false, false, false, false, false},
                    {true, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false},
                    {false, false, false, false, false, false, false, false}
                };
            }

            return new bool[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };
        }

        /// <summary>
        /// (-1,-1), (0,-1), (1,-1)
        /// (-1, 0), (0, 0), (1, 0)
        /// (-1, 1), (0, 1), (1, 1)
        /// </summary>
        private int ZaehleLebendeNachbarn(bool[,] array, int posX, int posY)
        {
            var n = 0;
            if (posX > 0 && posY > 0 && array[posX - 1, posY - 1])
            {
                n++;
            }
            return n;
        }
    }
}
