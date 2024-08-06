using Kings_of_Knives.Scripts.Interact.Tables.CuttingTable;
using Kings_of_Knives.Scripts.Services;
using Kings_of_Knives.Scripts.Services.Fabric.Ingredient;
using Kings_of_Knives.Scripts.Services.IngredientDestroyer;
using Kings_of_Knives.Scripts.Services.ProgressSavers;
using Kings_of_Knives.Scripts.Tables;
using UnityEngine;
using Zenject;

namespace Kings_of_Knives.Scripts.Installers.Services
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private IngredientDestroyerService _ingredientDestroyerService;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindInteractionSerivce();
            BindHoldingInteractionService();
            BindIngredientFabricService();
            BindCuttingProgressSaverService();
            BindIngredientDestroyerService();
            BindFryingProgressSaverService();
        }

        private void BindInputService()
        {
            Container.Bind<InputService>().AsSingle().NonLazy();
        }

        private void BindInteractionSerivce()
        {
            Container.Bind<InteractionService>().AsSingle().NonLazy();
        }

        private void BindHoldingInteractionService()
        {
            Container.Bind<HoldingInteractionService>().AsSingle().NonLazy();
        }

        private void BindIngredientFabricService()
        {
            Container.Bind<IIngredientFabric>().To<IngredientFabric>().AsSingle().NonLazy();
        }

        private void BindCuttingProgressSaverService()
        {
            Container.Bind<IProgressSaverService<Ingredient>>().To<CuttingProgressSaverService>().AsSingle().WhenInjectedInto<CuttingTable>();
        }

        private void BindFryingProgressSaverService()
        {
            Container.Bind<IProgressSaverService<Ingredient>>().To<FryProgressSaverService>().AsSingle().WhenInjectedInto<FryingTable>();
        }
        
        private void BindIngredientDestroyerService()
        {
            Container.Bind<IngredientDestroyerService>().FromInstance(_ingredientDestroyerService).AsSingle().NonLazy();
        }
    }
}