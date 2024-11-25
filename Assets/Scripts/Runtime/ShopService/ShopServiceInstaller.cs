using UnityEngine;
using Zenject;

namespace Runtime.ShopService
{
    public class ShopServiceInstaller : MonoInstaller
    {
        [SerializeField] private ShopService _shopServicePrefab;
        
        public override void InstallBindings()
        {
            BindShopService();
        }

        private void BindShopService()
        {
            ShopService shopService = Container
                .InstantiatePrefabForComponent<ShopService>(_shopServicePrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IShopService>()
                .FromInstance(shopService)
                .AsSingle();
        }
    }
}