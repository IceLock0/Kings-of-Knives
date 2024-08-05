using System;
using Kings_of_Knives.Scripts.SO.Configs;
using Kings_of_Knives.Scripts.View.Outline;
using UnityEngine;

namespace Kings_of_Knives.Scripts
{
public class PlayerInteractionController
{
    private readonly InputService _inputService;
    private readonly PlayerConfig _playerConfig;
    private readonly Transform _playerTransform;

    private Vector3 _currentDirection;
    private IInteractable _lastInteractable;
    private IHighlightable _lastHighlightable;

    public PlayerInteractionController(InputService inputService, PlayerConfig playerConfig,
        Transform playerTransform)
    {
        _inputService = inputService;
        _playerConfig = playerConfig;
        _playerTransform = playerTransform;
    }
    
    public void CheckInteraction()
    {
        UpdateCurrentDirection();

        if (Physics.Raycast(_playerTransform.position, _currentDirection, out RaycastHit hit,
                _playerConfig.InteractDistance))
        {
            ProcessHit(hit);
        }
        else
        {
            ClearLastInteractable();
        }
    }

    public void TryToInteract()
    {
        if (_lastInteractable == null)
            throw new NullReferenceException("No objects to interact with");

        _lastInteractable.Interact();
    }

    private void UpdateCurrentDirection()
    {
        Vector3 newDirection = GetCurrentDirectionToVector3();
        if (newDirection != Vector3.zero)
            _currentDirection = newDirection;
    }

    private Vector3 GetCurrentDirectionToVector3()
    {
        Vector2 inputDirection = _inputService.Gameplay.Movement.ReadValue<Vector2>();
        return new Vector3(inputDirection.x, 0, inputDirection.y);
    }

    private void ProcessHit(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out IInteractable interactable))
        {
            SetLastInteractable(interactable);
            SetHighlightable(hit.transform);
        }
        else
        {
            ClearLastInteractable();
        }
    }

    private void SetLastInteractable(IInteractable interactable)
    {
        _lastInteractable = interactable;
    }

    private void SetHighlightable(Transform hitTransform)
    {
        if (hitTransform.TryGetComponent(out IHighlightable highlightable))
        {
            if (_lastHighlightable != highlightable)
            {
                DisableLastHighlightable();
                EnableHighlightable(highlightable);
            }
        }
        else
        {
            DisableLastHighlightable();
        }
    }

    private void EnableHighlightable(IHighlightable highlightable)
    {
        _lastHighlightable = highlightable;
        _lastHighlightable.Highlight(true);
    }

    private void DisableLastHighlightable()
    {
        if (_lastHighlightable != null)
        {
            _lastHighlightable.Highlight(false);
            _lastHighlightable = null;
        }
    }

    private void ClearLastInteractable()
    {
        _lastInteractable = null;
        DisableLastHighlightable();
    }
}

}