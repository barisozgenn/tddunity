
using NUnit.Framework;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Movements;
using NSubstitute;
using TDDUnity.Movements;
using UnityEngine;
using TDDUnity.Abstracts.Inputs;

namespace Movements
{
    public class player_movement_test_script
    {
        [Test]
        public void move_10_meters_right_from_start_position()
        {

            #region Arrange: Get Reference what we will use
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gObjExample = new GameObject();

            playerController.transform.Returns(gObjExample.transform);
            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController: playerController);
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

            Assert.AreNotEqual(expected: playerStartPosition, actual: playerEndPosition);     
       
            #endregion
        }

        [Test]
        public void is_end_position_greater_than_first()
        {

            #region Arrange: Get Reference what we will use
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gObjExample = new GameObject();

            playerController.transform.Returns(gObjExample.transform);
            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController: playerController);
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

        [Test]
        public void move_10_meters_left_from_start_position()
        {

            #region Arrange: Get Reference what we will use
            IPlayerController playerController = Substitute.For<IPlayerController>();

            GameObject gObjExample = new GameObject();

            playerController.transform.Returns(gObjExample.transform);
            playerController.InputReader = Substitute.For<IInputReader>();

            IMover mover = new PlayerMoveWithTranslate(playerController: playerController);
            Vector3 playerStartPosition = playerController.transform.position;

            #endregion
            #region Act: Use references we defined in Arrange

            playerController.InputReader.Horizontal.Returns(-1f);

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

            Assert.Less(arg1: playerEndPosition.x, arg2: playerStartPosition.x);

            #endregion
        }
    }
}

