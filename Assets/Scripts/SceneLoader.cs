using UnityEngine.SceneManagement;

public class SceneLoader
{
    class OnceSceneLoader {
        private bool isLoaded = false;
        private string name;

        public OnceSceneLoader(string name)
        {
            this.name = name;
        }

        public void loadScene()
        {
            if (!isLoaded)
            {
                SceneManager.LoadScene(name);
                isLoaded = true;
            }
        }
    }

    OnceSceneLoader menuLoader = new OnceSceneLoader("Menu");
    OnceSceneLoader gameLoader = new OnceSceneLoader("Game");

    public void loadMenuScene()
    {
        menuLoader.loadScene();
    }

    public void loadGameScene()
    {
        gameLoader.loadScene();
    }
}
