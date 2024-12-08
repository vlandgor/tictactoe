using Runtime.Tokens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.GameBoard
{
    [CreateAssetMenu(fileName = "TokensFactory", menuName = "Playcbo/Factories/Tokens Factory", order = 0)]
    public class TokensFactory : ScriptableObject
    {
        private const string FACTORY_SCENE_NAME = "Tokens_Scene";
        
        private Scene _factoryScene;
        
        public Token Get(Token prefab)
        {
            Debug.Log("Get Token");
            Token instance = Instantiate(prefab);
            instance.OriginFactory = this;
            MoveToFactoryScene(instance.gameObject);
            return instance;
        }
        
        public void Reclaim(Token token)
        {
            Destroy(token.gameObject);
        }

        private void MoveToFactoryScene(GameObject go)
        {
            if(!_factoryScene.isLoaded)
            {
                if(Application.isEditor)
                {
                    _factoryScene = SceneManager.GetSceneByName(FACTORY_SCENE_NAME);
                    if(!_factoryScene.isLoaded)
                    {
                        _factoryScene = SceneManager.CreateScene(FACTORY_SCENE_NAME);
                    }
                }
                else
                {
                    _factoryScene = SceneManager.CreateScene(FACTORY_SCENE_NAME);
                }
            }
            SceneManager.MoveGameObjectToScene(go, _factoryScene);
        }
    }
}