using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Kings_of_Knives.Scripts.Plate
{
    public class PlateSpawner : MonoBehaviour
    {
        [SerializeField] private int _startPlatesCount;
        [SerializeField] private int _maxPlatesCount;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private Transform _baseSpawnPointTransform;
        [SerializeField] private Vector3 _plateOffset;
        [SerializeField] private GameObject _plateGO;

        private int _currentPlates = 0;
        private Vector3 _lastSpawnPointVector;

        private bool _isCanGeneratePlate = true;
        
        private void Start()
        {
            for (int i = 1; i <= _startPlatesCount; i++) 
                CreatePlate();
            
            GeneratePlatePerTime().Forget();
        }

        private async UniTask GeneratePlatePerTime()
        {
            while (_isCanGeneratePlate)
            {
                await UniTask.Delay((int) (_spawnDelay * 1000));
                CreatePlate();
            }
        }
        
        private void CreatePlate()
        {
            if (_currentPlates >= _maxPlatesCount)
                return;
            
            var spawnPointVector = _currentPlates == 0 ? _baseSpawnPointTransform.position : _lastSpawnPointVector; 
            
            var spawnedPlateGO = Instantiate(_plateGO, spawnPointVector, Quaternion.identity, null);

            var newSpawnPointPosition = spawnedPlateGO.transform.position + _plateOffset;

            _lastSpawnPointVector = newSpawnPointPosition;

            _currentPlates++;
        }
        
        private void OnValidate()
        {
            _startPlatesCount = Mathf.Clamp(_startPlatesCount, 1, _maxPlatesCount);
        }
    }
}
