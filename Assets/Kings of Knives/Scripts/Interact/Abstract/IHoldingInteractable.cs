using System;

namespace Kings_of_Knives.Scripts
{
    public interface IHoldingInteractable
    {
        public event Action<float, float> OnHoldTimeChanged;
        
        public void HoldingInteract();
    }
}