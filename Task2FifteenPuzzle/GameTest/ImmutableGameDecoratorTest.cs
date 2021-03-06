﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2FifteenPuzzle;

namespace GameTest
{
    [TestClass]
    public class ImmutableGameDecoratorTest : GameTests
    {
        protected override Game CreateGameObjectForTest(params int[] valuesArray)
        {
            return new ImmutableGameDecorator( new ImmutableGame (valuesArray) );
        }

        [TestMethod]
        public void Game_ValidValues_ObjectImmutableGameDecoratorCreates()
        {
            // Arrange:
            Game initialImmutableGame = CreateGameObjectForTest(3, 0, 2, 1);

            // Act:
            int requiredValue = 3;

            var index2 = new Index { x = 1, y = 0 };
            var index3 = new Index { x = 0, y = 0 };

            var index2AfterShift = new Index { x = 1, y = 0 };
            var index3AfterShift = new Index { x = 0, y = 1 };

            var initialIndex2 = new Index { };
            var initialIndex3 = new Index { };

            var changedIndex2 = new Index { };
            var changedIndex3 = new Index { };

            IGame changedImmutableGame = initialImmutableGame.Shift(requiredValue);

            changedIndex2 = changedImmutableGame.GetLocation(2);
            changedIndex3 = changedImmutableGame.GetLocation(3);

            // Assert:
            Assert.IsTrue(index2AfterShift.x == changedIndex2.x && index2AfterShift.y == changedIndex2.y);
            Assert.IsTrue(index3AfterShift.x == changedIndex3.x && index3AfterShift.y == changedIndex3.y);
        }
    }
}
