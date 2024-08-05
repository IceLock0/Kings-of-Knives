using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Kings_of_Knives.Scripts.Services
{
    public class InteractionService : IDisposable
    {
        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;
            
            _inputService.Enable();
            
            _inputService.Gameplay.Interaction.performed += OnInteractPerformed;
        }
        
        public event Action InteractPerformed;
        
        public void Dispose()
        {
            _inputService.Disable();
            
            _inputService.Gameplay.Interaction.performed -= OnInteractPerformed;
            
            _inputService?.Dispose();
        }
        
        private void OnInteractPerformed(InputAction.CallbackContext obj)
        {
            InteractPerformed?.Invoke();
        }
    }
}