using UnityEngine.SceneManagement;
using Zenject;

namespace Runtime.Extensions
{
    public static class LoadingExtensions
    {
        public static SceneContext FindSceneContext(string sceneName)
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            
            foreach (var rootObject in scene.GetRootGameObjects())
            {
                var sceneContext = rootObject.GetComponent<SceneContext>();
                if (sceneContext != null)
                {
                    return sceneContext;
                }
            }
            return null;
        }
    }
}