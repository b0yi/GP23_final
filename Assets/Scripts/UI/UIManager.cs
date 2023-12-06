using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameProgressStage
{
    PlanetR,
    PlanetE,
    PlanetF,
    Final,
}

public class UIManager : MonoBehaviour
{
    [DisplayOnly] public GameProgressStage stage;

    void Start()
    {
        stage = GameProgressStage.PlanetR;
        DontDestroyOnLoad(gameObject);
    }
    private void LoadScene(string target)
    {
        SceneManager.LoadSceneAsync(target);
    }

    public void LoadMainMenuScene()
    {
        LoadScene("MainMenu");
    }

    public void LoadPlayScene()
    {
        LoadScene("Play");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {

    }


}
