using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Movements;
using UnityEngine;

namespace TDDUnity.Movements
{
    public class PlayerFlipWithScale: IFlip
    {
        readonly Transform _transform;
        readonly IPlayerController _playerController;

        public PlayerFlipWithScale(IPlayerController playerController)
        {
            _transform = playerController.transform.GetChild(0).transform;/*get body child*/
            _playerController = playerController;
        }

        public void Tick()
        {
            float horizontalInput = _playerController.InputReader.Horizontal;

            if (horizontalInput == 0f) return;

            _transform.localScale = new Vector3(horizontalInput,1f,1f);
        }
    }
}

