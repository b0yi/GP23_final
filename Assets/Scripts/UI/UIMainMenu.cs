using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    public UIManager uIManager;
    public GameObject start;
    public GameObject quit;
    private bool state;
    public UIMainMenuFade fade;
    bool _isLoading = false;

    void Start()
    {
        state = true; // start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
            state = !state;
        }

        if (state) {
            start.GetComponent<TextMeshProUGUI>().fontSize = 64f;
            start.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 50f);
            quit.GetComponent<TextMeshProUGUI>().fontSize = 32f;
            quit.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50f);
        }
        else {
            start.GetComponent<TextMeshProUGUI>().fontSize = 32f;
            start.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 50f);
            quit.GetComponent<TextMeshProUGUI>().fontSize = 64f;
            quit.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50f);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (state && !_isLoading) {
                // fade.Fade();
                _isLoading = true;
                uIManager.LoadPlayScene();
            }
            else {
                uIManager.QuitGame();
            }
        }
    }
}
