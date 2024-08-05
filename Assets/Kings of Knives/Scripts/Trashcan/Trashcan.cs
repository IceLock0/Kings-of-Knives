using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;
using Zenject;

public class Trashcan : MonoBehaviour, IInteractable
{
    [Inject] private PlayerInventory _playerInventory;

   public void Interact()
    {
        if (_playerInventory.Ingredient != null)
        {
            RemoveIngredient();
        }
    }

    private void RemoveIngredient()
    {
        _playerInventory.ChangeIngredient(null);
    }
}
