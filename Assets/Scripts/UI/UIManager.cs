using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private AsyncOperation async = null;

    public bool isPlayerDead = false;

    void Start()
    {
        // Lock Mouse Here.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        DontDestroyOnLoad(gameObject);
    }
    private void LoadScene(string target)
    {
        // async = SceneManager.LoadSceneAsync(target);
        SceneManager.LoadScene(target);
        // while (!async.isDone) {
        //     yield return null;
        // }
    }

    public void LoadMainMenuScene()
    {
        // IEnumerator coroutine = LoadScene("MainMenu");
        // StartCoroutine(coroutine);
        LoadScene("MainMenu");
    }

    public void LoadPlayScene()
    {
        // IEnumerator coroutine = LoadScene("Play");
        // StartCoroutine(coroutine);
        LoadScene("Play");
    }

    public void LoadEndScene()
    {
        // IEnumerator coroutine = LoadScene("Play");
        // StartCoroutine(coroutine);
        LoadScene("EndScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void PlayerDead(int deadString) {
        if (!isPlayerDead) {
            isPlayerDead = true;
            UIPlayerDead uIDead = GameObject.FindWithTag("UIPlayerDeadCanvas").GetComponent<UIPlayerDead>();
            if (uIDead == null) Debug.LogError("Can't find UIPlayerDead in scene!!!");

            uIDead.FadePlayerDeadCanvas(deadString);
        }
    }
}
