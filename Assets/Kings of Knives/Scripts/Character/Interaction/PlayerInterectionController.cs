using System;
using System.Collections;
using System.Collections.Generic;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private float _interactDistance;

        private PlayerMovementController _playerMovementController;
        
        private Vector3 _lastDirection;

        private IInteractable _lastInteract;

        private PlayerInput _playerInput;
        private bool _isActionAdded = false;
        
        private void Awake()
        {
            _playerMovementController = GetComponent<PlayerMovementController>();
            
            _playerInput = PlayerInputController.GetPlayerInput();
        }

        private void Start()
        {
            if (!_isActionAdded)
            {
                _playerInput = PlayerInputController.GetPlayerInput();
                
                _playerInput.Gameplay.Interaction.performed += OnInteractPerformed;
                
                _isActionAdded = true;
            }
        }

        private void Update()
        {
            CheckEnvironment();
        }

        private void CheckEnvironment()
        {
            if (_playerMovementController.GetDirection() != Vector3.zero)
            {
                _lastDirection = _playerMovementController.GetDirection();
            }

            if (Physics.Raycast(transform.position, _lastDirection, out RaycastHit hit, _interactDistance))
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    interactable.CanInteract = true;

                    _lastInteract = interactable;
                }
                else
                {
                    if (_lastInteract != null)
                        _lastInteract.CanInteract = false;
                }
            }
            else
            {
                if (_lastInteract != null)
                    _lastInteract.CanInteract = false;
            }
        }
        
        private void OnInteractPerformed(InputAction.CallbackContext obj)
        {
            if (_lastInteract != null && _lastInteract.CanInteract == true)
                _lastInteract.Interact();
        }
        
        private void OnEnable()
        {
            if (PlayerInputController.GetPlayerInput() != null)
            {
                _playerInput.Gameplay.Interaction.performed += OnInteractPerformed;
                _isActionAdded = true;
            }
        }

        private void OnDisable()
        {
            _playerInput.Gameplay.Interaction.performed -= OnInteractPerformed;
            _isActionAdded = false;
        }
    }
}