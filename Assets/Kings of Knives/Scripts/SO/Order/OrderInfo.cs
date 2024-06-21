using Kings_of_Knives.Scripts;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "OrderInfo", menuName = "Scriptable Objects/OrderInfo")]
public class OrderInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _spriteIcon;
    [SerializeField] private List<IngredientInfo> _ingredients;

    public string Name => _name;
    public Sprite SpriteIcon => _spriteIcon;
    public List<IngredientInfo> Ingredients => _ingredients;
}