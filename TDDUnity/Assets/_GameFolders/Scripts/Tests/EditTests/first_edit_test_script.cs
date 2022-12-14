using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace EditModeSumTest //We define a namespace to manage it easily in hierarchy
{
    public class first_edit_test_script
    {
        //Test need to contain Arrange Act Assert
        // A Test behaves as an ordinary method for Edit method
        [Test]
        public void numbers_sum_test_is_equal_15()
        {
            #region Arrange: Get Reference what we will use

            int number1 = 5;
            int number2 = 10;
            int sumExpectedResult = 15;

            #endregion
            #region Act: Use references we defined in Arrange

            int result = number1 + number2;

            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: sumExpectedResult, actual: result);

            #endregion
        }
        [Test]
        public void numbers_minus_test_is_equal_10()
        {
            #region Arrange: Get Reference what we will use

            int number1 = 5;
            int number2 = 10;
            int sumExpectedResult = 10;

            #endregion
            #region Act: Use references we defined in Arrange

            int result = number1 - number2;

            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: sumExpectedResult, actual: result);

            #endregion
        }

        /* We won't use it now
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator first_edit_test_scriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }*/
    }
}


