using System;
using System.Net.Security;
using NUnit.Framework;

namespace GameOfLife
{
    public class Class1
    {
        [Test]
        public void JedelebendezelleMitWenigerAlszweiNachbarnStirbt()
        {
            var startArray = new[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, true, false, false, false},
                                 {false, false, false, true, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            object actualArray = schritt(startArray);

            var expectedArray = new[,]
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
            var startArray = new[,]
                             {
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, true, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };


            object actualArray = schritt(startArray);


            var expectedArray = new[,]
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
            var startArray = new[,]
                             {
                                 {true, true, false, true, false, false, false, false},
                                 {true, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            var expectedArray = new[,]
                                {
                                    {true, true, false, false, false, false, false, false},
                                    {true, false, false, false, false, false, false, false},
                                    {false, false, false, false, false, false, false, false},
                                    {false, false, false, false, false, false, false, false}
                                };
            object actualArray = schritt(startArray);

            Assert.AreEqual(actualArray, expectedArray);
        }

        [Test]
        public void JedeEinzelneLebendeZelleStirbt3()
        {
            var startArray = new[,]
                             {
                                 {true, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false},
                                 {false, false, false, false, false, false, false, false}
                             };

            var expectedArray = new[,]
                                {
                                    {false, false, false, false, false, false, false, false},
                                    {false, false, false, false, false, false, false, false},
                                    {false, false, false, false, false, false, false, false},
                                    {false, false, false, false, false, false, false, false}
                                };
            object actualArray = schritt(startArray);

            Assert.AreEqual(actualArray, expectedArray);
        }

        private object schritt(bool[,] startArray)
        {
            bool[,] cloneArray = (bool[,])startArray.Clone();

            for (int y = 0; y < cloneArray.GetLength(1); y++)
            {
                for (int x = 0; x < cloneArray.GetLength(0); x++)
                {
                    int retVal = ZaehleLebendeNachbarn(startArray, x, y);

                    if (startArray[x, y])
                    {
                        // lebende Zelle :)
                        if (retVal < 2)
                            cloneArray[x, y] = false;
                    }

                }
            }

            return cloneArray;
        }

        /// <summary>
        ///     (-1,-1), (0,-1), (1,-1)
        ///     (-1, 0), (0, 0), (1, 0)
        ///     (-1, 1), (0, 1), (1, 1)
        /// </summary>
        private int ZaehleLebendeNachbarn(bool[,] array, int posX, int posY)
        {
            return InhaltAnPosition(array, posX - 1, posY - 1) +
                   InhaltAnPosition(array, posX - 1, posY) +
                   InhaltAnPosition(array, posX - 1, posY + 1) +
                   InhaltAnPosition(array, posX, posY - 1) +
                   InhaltAnPosition(array, posX, posY + 1) +
                   InhaltAnPosition(array, posX + 1, posY - 1) +
                   InhaltAnPosition(array, posX + 1, posY) +
                   InhaltAnPosition(array, posX + 1, posY + 1);
        }

        private int InhaltAnPosition(bool[,] array, int posX, int posY)
        {
            if (posX < 0 || posY < 0 || posX >= array.GetLength(0) || posY >= array.GetLength(1))
            {
                return 0;
            }
            else if (array[posX, posY])
            {
                return 1;
            }
            return 0;
        }
    }
}