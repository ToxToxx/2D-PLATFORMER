using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenu,
        LoadingScreen,
        Level1,
        Level2,
    }

    private static Scene _targetScene;

    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetScene.ToString());
    }
}
