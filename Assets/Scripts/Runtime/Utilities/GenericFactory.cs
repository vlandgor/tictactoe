using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Utilities
{
    public class GenericFactory : ScriptableObject
    {
        private const string FACTORY_SCENE_NAME = "Factory_Scene";
        
        private Scene _factoryScene;
        
        protected void MoveToFactoryScene(GameObject go)
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