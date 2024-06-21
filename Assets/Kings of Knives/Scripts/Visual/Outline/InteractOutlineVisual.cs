using Kings_of_Knives.Scripts;
using UnityEngine;

public class InteractOutlineVisual : MonoBehaviour
{
    private Outline _outline;

    private IInteractable _interactable;

    private void Awake()
    {
        _interactable = GetComponent<IInteractable>();

        _outline = GetComponent<Outline>();

        _outline.enabled = false;
    }

    private void Update()
    {
        _outline.enabled = _interactable.CanInteract;
    }
}