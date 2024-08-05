using Kings_of_Knives.Scripts.Character;
using Zenject;

namespace Kings_of_Knives.Scripts.Installers.Player.Inventory
{
    public class PlayerInventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerInventory();
        }

        private void BindPlayerInventory()
        {
            Container
                .Bind<PlayerInventory>()
                .AsSingle()
                .NonLazy();
        }
    }
}