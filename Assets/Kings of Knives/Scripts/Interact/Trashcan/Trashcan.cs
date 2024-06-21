using Kings_of_Knives.Scripts;
using Kings_of_Knives.Scripts.Character;
using UnityEngine;

public class Trashcan : MonoBehaviour, IInteractable
{
    public bool CanInteract { get; set; }

    private PlayerInventory _playerInventory;
    
    private void Awake()
    {
        _playerInventory = PlayerInventory.GetInstance();
    }

    public void Interact()
    {
        if (_playerInventory.GetIngredient() != null)
        {
            RemoveIngredient();
        }
    }

    private void RemoveIngredient()
    {
        _playerInventory.SetIngredient(null);
    }
}
