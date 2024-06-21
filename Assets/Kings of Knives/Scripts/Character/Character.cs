using Kings_of_Knives;
using UnityEngine;

public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        var scaledDirection = direction * _speed;

        transform.position += scaledDirection;
    }
}
