using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts.Character.Interaction
{
    public class PlayerHoldingInteractionInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private bool _isHoldingKey = false;

        private PlayerInteractionDeterminant _playerInteractionDeterminant;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _playerInteractionDeterminant = GetComponent<PlayerInteractionDeterminant>();
        }

        private void Update()
        {
            if (_isHoldingKey)
                SecondaryInteractionProcessing();
        }

        private void SecondaryInteractionProcessing()
        {
            if (_playerInteractionDeterminant.LastInteract != null &&
                _playerInteractionDeterminant.LastInteract == _playerInteractionDeterminant.LastHoldingInteract)
            {
                _playerInteractionDeterminant.LastHoldingInteract?.HoldingInteract();
            }
        }

        private void OnEnable()
        {
            _playerInput.Gameplay.HoldingInteraction.started += OnHoldKeyStarted;
            _playerInput.Gameplay.HoldingInteraction.canceled += OnHoldKeyCanceled;
        }

        private void OnDisable()
        {
            _playerInput.Gameplay.HoldingInteraction.started -= OnHoldKeyStarted;
            _playerInput.Gameplay.HoldingInteraction.canceled -= OnHoldKeyCanceled;
        }

        private void OnHoldKeyStarted(InputAction.CallbackContext obj)
        {
            _isHoldingKey = true;
        }

        private void OnHoldKeyCanceled(InputAction.CallbackContext obj)
        {
            _isHoldingKey = false;
        }
    }
}