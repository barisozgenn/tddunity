using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TDDUnity.Controllers;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using TDDUnity.Abstracts.Inputs;
using UnityEngine.SceneManagement;
using TDDUnity.Abstracts.Controllers;

namespace Movements
{
    public class player_flip_test_play_mode_script
    {
        IPlayerController _playerController;

        private IEnumerator LoadScenePlayerMovementTestScene()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTestScene");
        }

        [UnitySetUp]
        IEnumerator Setup()
        {
            yield return LoadScenePlayerMovementTestScene();

            _playerController = GameObject.FindObjectOfType<PlayerController>();

            _playerController.InputReader = Substitute.For<IInputReader>();

        }


        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator when_input_value_1_is_flipped(float horizontalInput)
        {
            #region Arrange: Get Reference what we will use
          
            #endregion
            #region Act: Use references we defined in Arrange

            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);
            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: horizontalInput , actual: _playerController.transform.GetChild(0).transform.localScale.x);
            yield return null;

            #endregion


        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator when_input_value_0_is_showing(float horizontalInput)
        {
            #region Arrange: Get Reference what we will use

            float firstInputValue = horizontalInput;

            #endregion
            #region Act: Use references we defined in Arrange

            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            horizontalInput =0;
            _playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: firstInputValue, actual: _playerController.transform.GetChild(0).transform.localScale.x);
            yield return null;
            #endregion


        }
    }
}

