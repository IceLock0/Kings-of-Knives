using UnityEngine;

namespace Kings_of_Knives.Scripts.SO.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _linearSpeed;
        [SerializeField] private float _angularSpeed;

        [Header("Interaction")]
        [SerializeField] private float _interactDistance;
        
        public float LinearSpeed => _linearSpeed;
        public float AngularSpeed => _angularSpeed;
        public float InteractDistance => _interactDistance;
    }
}