using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts.Character.Interaction
{
    public class PlayerInteractionInputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private PlayerInteractionDeterminant _interactionDeterminant;
        
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();

            _interactionDeterminant = GetComponent<PlayerInteractionDeterminant>();
        }

        private void OnEnable()
        {
            _playerInput.Gameplay.Interaction.performed += OnInteractPerformed;
        }

        private void OnDisable()
        {
            _playerInput.Gameplay.Interaction.performed -= OnInteractPerformed;
        }

        private void OnInteractPerformed(InputAction.CallbackContext obj)
        {
            if (_interactionDeterminant.LastInteract != null && _interactionDeterminant.LastInteract.CanInteract == true)
                _interactionDeterminant.LastInteract.Interact();
        }
    }
}