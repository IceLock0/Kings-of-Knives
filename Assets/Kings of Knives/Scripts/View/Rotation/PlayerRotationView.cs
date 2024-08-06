using Kings_of_Knives.Scripts.Character.Rotation;
using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Kings_of_Knives.Scripts.Character
{
    [RequireComponent(typeof(Transform))]
    public class PlayerRotationView : MonoBehaviour
    {
        private PlayerRotationController _controller;
        private InputService _inputService;

        [Inject]
        public void Initialize(PlayerConfig playerConfig, InputService inputService)
        {
            _inputService = inputService;
            _controller = new PlayerRotationController(playerConfig, inputService, GetComponent<Transform>());
        }

        private void FixedUpdate()
        {
            _controller.TryRotate();
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