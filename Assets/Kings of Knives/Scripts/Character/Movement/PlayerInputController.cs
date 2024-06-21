using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Kings_of_Knives.Scripts.Character
{
    public class PlayerInputController : MonoBehaviour
    {
        private static PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Enable();
        }

        public static PlayerInput GetPlayerInput() => _playerInput;
    }
}