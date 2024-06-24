using System;
using System.Collections;
using System.Collections.Generic;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts
{
    public class PlayerInteractionDeterminant : MonoBehaviour
    {
        [SerializeField] private float _interactDistance;

        private PlayerMovementController _playerMovementController;

        private Vector3 _lastDirection;

        private IInteractable _lastInteract;

        private IHoldingInteractable _lastHoldingInteract;
        
        public IInteractable LastInteract => _lastInteract;

        public IHoldingInteractable LastHoldingInteract => _lastHoldingInteract;
        
        private void Awake()
        {
            _playerMovementController = GetComponent<PlayerMovementController>();
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

                    if (hit.transform.TryGetComponent(out IHoldingInteractable secondaryInteractable))
                    {
                        _lastHoldingInteract = secondaryInteractable;
                    }
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

    }
}