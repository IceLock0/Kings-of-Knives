using Kings_of_Knives.Scripts.SO.Configs;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Installers.Config
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            BindPlayerConfig();
        }

        private void BindPlayerConfig()
        {
            Container
                .Bind<PlayerConfig>()
                .FromScriptableObject(_playerConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}