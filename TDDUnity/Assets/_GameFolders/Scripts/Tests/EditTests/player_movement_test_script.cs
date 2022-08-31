
using NUnit.Framework;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Movements;
using NSubstitute;
using TDDUnity.Movements;
using UnityEngine;
using TDDUnity.Abstracts.Inputs;
using TDDUnity.Abstracts.ScriptableObjects;

namespace Movements
{
    public class player_movement_test_script
    {
        private IPlayerController GetPlayer()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gObjExample = new GameObject();

            playerController.transform.Returns(gObjExample.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            playerController.Stats.Returns(Substitute.For<IPlayerStats>());
            playerController.Stats.MoveSpeed.Returns(5f);

            return playerController;
        }

        private IMover GetMoverWithTranslate(IPlayerController playerController)
        {
           return new PlayerMoveWithTranslate(playerController: playerController);
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void move_10_meters_right_from_start_position(float horizontalInputValue)
        {

            #region Arrange: Get Reference what we will use
            var playerController = GetPlayer();

            IMover mover = GetMoverWithTranslate(playerController: playerController);
            Vector3 playerStartPosition = playerController.transform.position;

            #endregion
            #region Act: Use references we defined in Arrange

            playerController.InputReader.Horizontal.Returns(horizontalInputValue);

            for (int i = 0; i < 10; i++)
            {
                mover.Tick();//get input
                mover.FixedTick();//action with input
            }

            Vector3 playerEndPosition = playerController.transform.position;

            Debug.Log("player start position => " + playerStartPosition);
            Debug.Log("player end position => " + playerEndPosition);
            #endregion

            #region Assert: Get Result

            Assert.AreNotEqual(expected: playerStartPosition, actual: playerEndPosition);     
       
            #endregion
        }

        [Test]
        public void is_end_position_greater_than_first()
        {

            #region Arrange: Get Reference what we will use

            var playerController = GetPlayer();

            IMover mover = GetMoverWithTranslate(playerController: playerController);
            Vector3 playerStartPosition = playerController.transform.position;

            #endregion
            #region Act: Use references we defined in Arrange

            playerController.InputReader.Horizontal.Returns(1f);

            for (int i = 0; i < 10; i++)
            {
                mover.Tick();//get input
                mover.FixedTick();//action with input
            }

            Vector3 playerEndPosition = playerController.transform.position;

            Debug.Log("player start position => " + playerStartPosition);
            Debug.Log("player end position => " + playerEndPosition);
            #endregion

            #region Assert: Get Result

            Assert.Greater(arg1: playerEndPosition.x, arg2: playerStartPosition.x);

            #endregion
        }

       
    }
}

