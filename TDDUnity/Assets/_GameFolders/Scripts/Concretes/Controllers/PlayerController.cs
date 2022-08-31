using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Inputs;
using TDDUnity.Abstracts.Movements;
using TDDUnity.Abstracts.ScriptableObjects;
using TDDUnity.Inputs;
using TDDUnity.Movements;
using TDDUnity.ScriptableObjects;
using UnityEngine;

namespace TDDUnity.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStats _playerStats;

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
        public IPlayerStats Stats => _playerStats;

        void Awake()
        {
            InputReader = new InputReader();

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

