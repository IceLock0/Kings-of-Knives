namespace Kings_of_Knives.Scripts
{
    public interface IInteractable
    {
        public bool CanInteract { get; set; }

        public void Interact();
    }
}