using Kings_of_Knives.Scripts.Services;
using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Character.Interaction
{
    [RequireComponent(typeof(Transform))]
    public class PlayerInteractionView : MonoBehaviour
    {
        private PlayerInteractionController _controller;
        private InputService _inputService;
        private InteractionService _interactionInput;
        private HoldingInteractionService _holdingInteractionService;
        
        [Inject]
        public void Initialize(InputService inputService, PlayerConfig playerConfig, InteractionService interactionService, HoldingInteractionService holdingInteractionService)
        {
            _inputService = inputService;
            _controller = new PlayerInteractionController(inputService, playerConfig, GetComponent<Transform>());
            _interactionInput = interactionService;
            _holdingInteractionService = holdingInteractionService;
        }
        
        public void Update()
        {
            _controller.CheckInteraction();
        }

        private void Interact()
        {
            _controller.TryToInteract();
        }    
        
        private void HoldingInteract()
        {
            _controller.TryToHoldingInteract();
        }

        private void OnEnable()
        {
            _inputService.Enable();
            _interactionInput.InteractPerformed += Interact;

            _holdingInteractionService.OnHoldingInteraction += HoldingInteract;
        }

        private void OnDisable()
        {
            _inputService.Disable();
            _interactionInput.InteractPerformed -= Interact;

            _holdingInteractionService.OnHoldingInteraction -= HoldingInteract;
        }
    }
}