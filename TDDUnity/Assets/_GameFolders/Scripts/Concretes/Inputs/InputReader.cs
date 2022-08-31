using System;
using System.Collections;
using System.Collections.Generic;
using TDDUnity.Abstracts.Inputs;
using TDDUnityAssemblyCustomReference.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDDUnity.Inputs
{
    public class InputReader : IInputReader
    {
        public float Horizontal { get; private set; }

        public InputReader()
        {
            GameInputActions input = new GameInputActions();

            input.Player.Move.performed += HandleOnMoved;
            input.Player.Move.canceled += HandleOnMoved;

            input.Enable();
        }

        void HandleOnMoved(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }

}
