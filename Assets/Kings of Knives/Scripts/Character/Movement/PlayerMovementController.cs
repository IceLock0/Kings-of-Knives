using System;
using Kings_of_Knives.Scripts.Character;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kings_of_Knives
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Character Collide Info")]
        [SerializeField] private float _characterRadius = 4.0f;
        [SerializeField] private float _characterHeight = 5.0f;
        [SerializeField] private float _characterrSpeed = 0.5f;

        private IControllable _controllable;

        private Vector3 _direction;

        private PlayerInput _playerInput;
        
        private void Awake()
        {
            _controllable = GetComponent<IControllable>();

            if (_controllable == null)
            {
                Debug.Log("IControllable component not founded");
            }

            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }

        private void Update()
        {
            Move();
        }

        private Vector3 ReadMove()
        {
            var inputDirection = _playerInput.Gameplay.Movement.ReadValue<Vector2>().normalized;
            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);

            return direction;
        }

        private bool IsCanMove()
        {
            _direction = ReadMove();
            
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _characterHeight,
                _characterRadius, _direction, _characterrSpeed);

            if (!canMove)
            {
                var directionX = new Vector3(_direction.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _characterHeight,
                    _characterRadius, directionX, _characterrSpeed);

                if (canMove)
                {
                    _direction = directionX;
                }
                else
                {
                    var directionZ = new Vector3(0, 0, _direction.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * _characterHeight,
                        _characterRadius, directionZ, _characterrSpeed);

                    if (canMove)
                    {
                        _direction = directionZ;
                    }
                }
            }

            return canMove;
        }

        private void Move()
        {
            if(IsCanMove())
                _controllable.Move(_direction);
        }

        public Vector3 GetDirection() => _direction;
    }
}