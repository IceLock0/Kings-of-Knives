using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Character.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementView : MonoBehaviour
    {
        private PlayerMovementController _controller;
        
        private InputService _inputService;
        
        [Inject]
        public void Initialize(PlayerConfig playerConfig, InputService inputService)
        {
            _controller = new PlayerMovementController(playerConfig, inputService, GetComponent<Rigidbody>());
            _inputService = inputService;
        }

        private void Update()
        {
            _controller.TryToMove();
        }
        
        private void OnEnable()
        {
            _inputService.Enable();
        }

        private void OnDisable()
        {
            _inputService.Disable();
        }
    }
}