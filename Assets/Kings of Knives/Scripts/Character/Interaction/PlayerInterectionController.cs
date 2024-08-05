using System;
using System.Collections;
using System.Collections.Generic;
using Kings_of_Knives.Scripts.Character;
using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts
{
    public class PlayerInteractionController
    {
        private readonly InputService _inputService;
        private readonly PlayerConfig _playerConfig;
        private readonly Transform _playerTransform;

        private Vector3 _currentDirection;

        private IInteractable _lastInteractable;
        
        public PlayerInteractionController(InputService inputService, PlayerConfig playerConfig,
            Transform playerTransform)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerTransform = playerTransform;
        }

        public void CheckInteraction()
        {
            if (GetCurrentDirectionToVector3() != Vector3.zero)
                _currentDirection = GetCurrentDirectionToVector3();

            if (Physics.Raycast(_playerTransform.position, _currentDirection, out RaycastHit hit,
                    _playerConfig.InteractDistance))
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    _lastInteractable = interactable;

                    _lastInteractable.CanInteract = true;
                    

                    // if (hit.transform.TryGetComponent(out IHoldingInteractable secondaryInteractable))
                    // {
                    //     _lastHoldingInteract = secondaryInteractable;
                    // }
                }
                else
                {
                    _lastInteractable.CanInteract = false;
                    _lastInteractable = null;
                }
            }
            else
            {
                _lastInteractable.CanInteract = false;
                _lastInteractable = null;
            }
        }

        public void TryToInteract()
        {
            if (_lastInteractable == null)
            {
                Debug.LogWarning("Last interactable object == null");
                return;
            }

            _lastInteractable.Interact();
        }
        
        private Vector3 GetCurrentDirectionToVector3()
        {
            Vector2 inputDirection = _inputService.Gameplay.Movement.ReadValue<Vector2>();
            
            Vector3 direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            
            return direction;
        }
    }
}