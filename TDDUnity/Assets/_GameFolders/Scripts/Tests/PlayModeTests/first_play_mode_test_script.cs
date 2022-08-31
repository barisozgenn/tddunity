using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeSumTest //We define a namespace to manage it easily in hierarchy
{
    public class first_play_mode_test_script
    {

        //Play Mode Tests we use coroutine methods for playmode
        [UnityTest]
        public IEnumerator numbers_sum_test_is_equal_15()
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
            yield return null;
        }
        [UnityTest]
        public IEnumerator numbers_minus_test_is_equal_10()
        {
            #region Arrange: Get Reference what we will use

            int number1 = 5;
            int number2 = 10;
            int sumExpectedResult = -5;

            #endregion
            #region Act: Use references we defined in Arrange

            int result = number1 - number2;

            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: sumExpectedResult, actual: result);

            #endregion
            yield return null;
        }
        [UnityTest]
        public IEnumerator find_gameobject_in_scene()
        {
            #region Arrange: Get Reference what we will use

            string gObjName = "gameObjExample";
            GameObject gObj = new GameObject(name: gObjName);


            #endregion
            #region Act: Use references we defined in Arrange

            yield return new WaitForSeconds(1f);

            var gObjIsFound = GameObject.Find(gObjName);

            yield return new WaitForSeconds(1f);



            #endregion

            #region Assert: Get Result

            Assert.AreSame(expected: gObj, actual: gObjIsFound);

            #endregion
            yield return null;
        }
    }

}
