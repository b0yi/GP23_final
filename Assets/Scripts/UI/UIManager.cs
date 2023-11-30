using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    void Start()
    {
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
