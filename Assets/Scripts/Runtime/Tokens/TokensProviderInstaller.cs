using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Runtime.Tokens
{
    public class TokensProviderInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_marksProviderPrefab")] [SerializeField] private TokensProvider tokensProviderPrefab;
        
        public override void InstallBindings()
        {
            TokensProvider tokensProvider = Container
                .InstantiatePrefabForComponent<TokensProvider>(tokensProviderPrefab, Vector3.zero, Quaternion.identity, null);
            
            Container
                .Bind<ITokensProvider>()
                .To<TokensProvider>()
                .FromInstance(tokensProvider)
                .AsSingle();
        }
    }
}