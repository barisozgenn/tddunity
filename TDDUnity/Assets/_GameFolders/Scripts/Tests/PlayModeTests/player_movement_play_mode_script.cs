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
    public class player_movement_play_mode_script
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

        private Vector3 GetPlayerPosition()
        {
            return _playerController.transform.position;
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator can_player_move(float inputHorizontalValue)
        {
            #region Arrange: Get Reference what we will use

            Vector3 playerStartPosition = GetPlayerPosition();

            #endregion
            #region Act: Use references we defined in Arrange

            _playerController.InputReader.Horizontal.Returns(inputHorizontalValue);

            yield return new WaitForSeconds(3f);

            #endregion

            #region Assert: Get Result
            Vector3 playerEndPosition = GetPlayerPosition();

            Debug.Log("player start position => " + playerStartPosition);
            Debug.Log("player end position => " + playerEndPosition);

            Assert.AreNotEqual(expected: playerStartPosition.x, actual: playerEndPosition.x);

            yield return null;
            #endregion

        }
        [UnityTest]
        public IEnumerator did_player_move_right()
        {
            #region Arrange: Get Reference what we will use

            Vector3 playerStartPosition = GetPlayerPosition();

            #endregion
            #region Act: Use references we defined in Arrange

            _playerController.InputReader.Horizontal.Returns(1f);

            yield return new WaitForSeconds(3f);

            #endregion

            #region Assert: Get Result
            Vector3 playerEndPosition = GetPlayerPosition();

            Debug.Log("player start position => " + playerStartPosition);
            Debug.Log("player end position => " + playerEndPosition);

            Assert.Greater(arg1: playerEndPosition.x, arg2: playerStartPosition.x);

            yield return null;
            #endregion

        }
    }

}
