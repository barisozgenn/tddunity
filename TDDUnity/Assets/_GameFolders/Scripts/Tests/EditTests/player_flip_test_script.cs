using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TDDUnity.Abstracts.Movements;
using TDDUnity.Movements;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Inputs;

namespace Movements
{
    public class player_flip_test_script
    {
        private IPlayerController GetPlayer(float horizontalInput)
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gameObjectParent = new GameObject();
            GameObject gameObjectBody = new GameObject();

            gameObjectBody.transform.SetParent(gameObjectParent.transform);

            playerController.transform.Returns(gameObjectParent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            return playerController;

        }
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void when_input_value_1_is_flipped(float horizontalInput)
        {
            #region Arrange: Get Reference what we will use

            var playerController = GetPlayer(horizontalInput: horizontalInput);

            IFlip flip = new PlayerFlipWithScale(playerController: playerController);

            #endregion
            #region Act: Use references we defined in Arrange

            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }

            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: horizontalInput, actual: playerController.transform.GetChild(0).transform.localScale.x);

            #endregion
        }
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void when_input_value_0_is_showing(float horizontalInput)
        {
            #region Arrange: Get Reference what we will use

            var playerController = GetPlayer(horizontalInput: horizontalInput);

            IFlip flip = new PlayerFlipWithScale(playerController: playerController);
            float firstInputValue = horizontalInput;

            #endregion
            #region Act: Use references we defined in Arrange

            for (int i = 0; i < 5; i++)
            {
                flip.Tick();
            }

            horizontalInput = 0;
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            for (int i = 0; i < 10; i++)
            {
                flip.Tick();
            }
            #endregion

            #region Assert: Get Result

            Assert.AreEqual(expected: firstInputValue, actual: playerController.transform.GetChild(0).transform.localScale.x);

            #endregion
        }
    }
}

