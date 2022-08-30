using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Movements;
using UnityEngine;

namespace TDDUnity.Movements
{
    public class PlayerMoveWithTranslate : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;

        float _moveSpeed = 1f;
        float _horizontalInput = 0;


        public PlayerMoveWithTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform;
        }
        public void FixedTick()
        {

            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void Tick()
        {
            _transform.Translate(Vector2.right * _horizontalInput);
        }
    }

}
