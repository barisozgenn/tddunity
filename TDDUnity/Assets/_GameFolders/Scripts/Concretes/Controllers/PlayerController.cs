using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Combats;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Inputs;
using TDDUnity.Abstracts.Movements;
using TDDUnity.Abstracts.ScriptableObjects;
using TDDUnity.Combats;
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
        IFlip _flip;
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
        public IHealth Health { get; private set; }

        void Awake()
        {
            InputReader = new InputReader();

            _mover = new PlayerMoveWithTranslate(playerController: this);
            _flip = new PlayerFlipWithScale(playerController: this);
            Health = new Health(maxHealth: _playerStats.MaxHealth);
        }

        void Update()
        {
            _mover.Tick();
            _flip.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void OnCollisionEnter2D (Collision2D collisionOther){
            Debug.Log(nameof(OnCollisionEnter2D));
        }
    }
}

