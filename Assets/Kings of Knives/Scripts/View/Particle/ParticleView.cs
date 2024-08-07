using System;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;

namespace Kings_of_Knives.Scripts.View.Particle
{
    public class ParticleView : MonoBehaviour
    {
        [SerializeField] private GameObject _particleGO;

        private FryingTable _fryingTable;

        private void Awake()
        {
            HideParticle();
            _fryingTable = GetComponent<FryingTable>();
        }

        private void ShowParticle()
        {
            _particleGO.SetActive(true);
        }

        private void HideParticle()
        {
            _particleGO.SetActive(false);
        }
        
        private void OnEnable()
        {
            _fryingTable.FryingStarted += ShowParticle;
            _fryingTable.FryingStopped += HideParticle;
        }

        private void OnDisable()
        {
            _fryingTable.FryingStarted -= ShowParticle;
            _fryingTable.FryingStopped -= HideParticle;
        }
    }
}