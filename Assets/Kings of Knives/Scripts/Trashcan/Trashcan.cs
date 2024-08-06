using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Character;
using Kings_of_Knives.Scripts.Services.IngredientDestroyer;
using UnityEngine;
using Zenject;

public class Trashcan : MonoBehaviour, IInteractable
{
    private PlayerInventory _playerInventory;
    private IngredientDestroyerService _ingredientDestroyerService;

    [Inject]
    public void Initialize(PlayerInventory playerInventory, IngredientDestroyerService ingredientDestroyerService)
    {
        _playerInventory = playerInventory;
        _ingredientDestroyerService = ingredientDestroyerService;
    }
    
   public void Interact()
    {
        if (_playerInventory.Ingredient != null)
            RemoveIngredient();
    }

    private void RemoveIngredient()
    {
        _ingredientDestroyerService.DestroyIngredient(_playerInventory.Ingredient);
        
        _playerInventory.ChangeIngredient(null);
    }
}
