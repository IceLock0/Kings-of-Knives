using System;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;
using Zenject;

namespace Kings_of_Knives.Scripts.Services
{
    public class HoldingInteractionService : IDisposable
    {
        private InputService _inputService;
        private bool _isHolding;

        public event Action InteractStarted;
        public event Action InteractCanceled;
        public event Action OnHoldingInteraction;

        [Inject]
        public void Initialize(InputService inputService)
        {
            _inputService = inputService;
            
            _inputService.Enable();
            
            _inputService.Gameplay.HoldingInteraction.started += OnInteractStarted;
            _inputService.Gameplay.HoldingInteraction.canceled += OnInteractCanceled;
        }

        public void Dispose()
        {
            _inputService.Disable();
            
            _inputService.Gameplay.HoldingInteraction.started -= OnInteractStarted;
            _inputService.Gameplay.HoldingInteraction.canceled -= OnInteractCanceled;
            
            _inputService?.Dispose();
        }

        private void OnInteractStarted(InputAction.CallbackContext obj)
        {
            _isHolding = true;
            InteractStarted?.Invoke();
            MonitorHoldingInteraction().Forget();
        }

        private void OnInteractCanceled(InputAction.CallbackContext obj)
        {
            _isHolding = false;
            InteractCanceled?.Invoke();
        }

        private async UniTaskVoid MonitorHoldingInteraction()
        {
            while (_isHolding)
            {
                OnHoldingInteraction?.Invoke();
                await UniTask.Yield();
            }
        }
    }
}