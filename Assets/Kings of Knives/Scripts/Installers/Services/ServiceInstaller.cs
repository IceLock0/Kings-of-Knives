﻿using Kings_of_Knives.Scripts.Services;
using Zenject;

namespace Kings_of_Knives.Scripts.Installers.Services
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindInteractionSerivce();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>().AsSingle().NonLazy();
        }
        
        private void BindInteractionSerivce()
        {
            Container.Bind<InteractionService>().AsSingle().NonLazy();
        }
    }
}