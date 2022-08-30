using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Controllers;
using TDDUnity.Abstracts.Inputs;
using UnityEngine;

namespace TDDUnity.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        #region Movement

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
    }

}

