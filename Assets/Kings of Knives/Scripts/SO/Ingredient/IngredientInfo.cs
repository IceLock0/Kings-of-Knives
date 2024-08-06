using System;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    [CreateAssetMenu(fileName = "IngredientInfo", menuName = "Scriptable Objects/Ingredients/IngredientInfo")]
    public class IngredientInfo : ScriptableObject
    {
        [SerializeField] private IngredientInfo _output;
        [SerializeField] private GameObject _prefab;

        [SerializeField] private bool _isCanTake;
        [SerializeField] private bool _isCanPutOnSimpleTable;
        [SerializeField] private bool _isCanPutOnContainerTable;
        [SerializeField] private bool _isCanPutOnCuttingTable;
        [SerializeField] private bool _isCanPutOnFryingTable;
        
        [SerializeField] private bool _isCanCut;
        [SerializeField] private bool _isCanFry;
        
        public IngredientInfo Output => _output;

        public GameObject Prefab => _prefab;

        public bool IsCanTake => _isCanTake;
        public bool IsCanPutOnSimpleTable => _isCanPutOnSimpleTable;
        public bool IsCanPutOnContainerTable => _isCanPutOnContainerTable;
        public bool IsCanPutOnCuttingTable => _isCanPutOnCuttingTable;
        public bool IsCanPutOnFryingTable => _isCanPutOnFryingTable;
        
        public bool IsCanCut => _isCanCut;
        public bool IsCanFry => _isCanFry;
    }
}