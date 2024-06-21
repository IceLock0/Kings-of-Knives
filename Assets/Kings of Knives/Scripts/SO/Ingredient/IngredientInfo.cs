using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    [CreateAssetMenu(fileName = "IngredientInfo", menuName = "Scriptable Objects/IngredientInfo")]
    public class IngredientInfo : ScriptableObject
    {
        [SerializeField] private Sprite _spriteIcon;
        [SerializeField] private GameObject _prefab;
        
        [SerializeField] private string _name;
        
        [SerializeField] private bool _isCanTake;
        [SerializeField] private bool _isCanPutOnSimpleTable;
        [SerializeField] private bool _isCanPutOnContainerTable;

        public Sprite SpriteIcon => _spriteIcon;

        public GameObject Prefab => _prefab;
        
        public string Name => _name;
        
        public bool IsCanTake => _isCanTake;
        public bool IsCanPutOnSimpleTable => _isCanPutOnSimpleTable;

        public bool IsCanPutOnContainerTable => _isCanPutOnContainerTable;
    }
}