using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Character.Rotation
{
    public class PlayerRotationController
    {
        private readonly PlayerConfig _playerConfig;
        private readonly InputService _inputService;
        private readonly Transform _playerTransform;
        
        public PlayerRotationController(PlayerConfig playerConfig, InputService inputService, Transform playerTransform)
        {
            _playerConfig = playerConfig;
            _inputService = inputService;
            _playerTransform = playerTransform;
        }

        public void TryRotate()
        {
            var rotation = ReadInput();

            _playerTransform.rotation = rotation;
        }

        private Quaternion ReadInput()
        {
            var input = _inputService.Gameplay.Movement.ReadValue<Vector2>();
            
            if(input == Vector2.zero)
                return _playerTransform.rotation;
            
            var lookDirection = Quaternion.LookRotation(new Vector3(input.x, 0 , input.y), Vector3.up);
            var targetRotation = Quaternion.RotateTowards(_playerTransform.rotation, lookDirection, _playerConfig.AngularSpeed );

            return targetRotation;
        }
    }
}