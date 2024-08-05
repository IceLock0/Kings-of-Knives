using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kings_of_Knives.Scripts.Character.Movement
{
    public class PlayerMovementController
    {
        private readonly PlayerConfig _playerConfig;
        private readonly InputService _inputService;
        private readonly Rigidbody _playerRigidbody;

        public PlayerMovementController(PlayerConfig playerConfig, InputService inputService, Rigidbody playerRigidbody)
        {
            _playerConfig = playerConfig;
            _inputService = inputService;
            _playerRigidbody = playerRigidbody;
        }
        
        public void TryToMove()
        {
            _playerRigidbody.linearVelocity = ReadInput();
        }

        private Vector3 ReadInput()
        {
            var direction = _inputService.Gameplay.Movement.ReadValue<Vector2>().normalized * _playerConfig.LinearSpeed * Time.deltaTime;
            
            return new Vector3(direction.x, 0, direction.y);
        }
    }
}