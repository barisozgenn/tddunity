using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Inputs;
using TDDUnity.Abstracts.Movements;
using TDDUnity.Movements;
using UnityEngine;

namespace TDDUnity.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        #region Movement
        IMover _mover;
        #region Flip
        #endregion
        #region Jumps
        #endregion
        #region Attack
        #endregion

        #endregion

        #region Healt
        #endregion
        #region Collect
        #endregion
        #region Animation
        #endregion
        public IInputReader InputReader { get; set; }

        void Awake()
        {
            _mover = new PlayerMoveWithTranslate(this);
        }

        void Update()
        {
            _mover.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }

}

