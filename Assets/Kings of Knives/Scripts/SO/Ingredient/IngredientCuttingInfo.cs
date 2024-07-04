using UnityEngine;

namespace Kings_of_Knives.Scripts
{
    [CreateAssetMenu(fileName = "IngredientCuttingInfo", menuName = "Scriptable Objects/Ingredients/IngredientCuttingInfo")]
    public class IngredientCuttingInfo : IngredientInfo
    {
        [SerializeField] private float _timeToCutting;
        
        public float TimeToCutting => _timeToCutting;
    }
}