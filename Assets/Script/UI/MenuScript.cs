using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }
    public void ToggleMenu()
    {
        if (menuPanel == null) return;
        bool isOpening = !menuPanel.activeSelf;
        menuPanel.SetActive(isOpening);
        Time.timeScale = isOpening ? 0.0f : 1.0f;
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void LoadMainMenu()
    {
        SceneController.instance.LoadMainMenuScene();
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        if (SceneController.instance != null)
        {
            StartCoroutine(PlayGameTransition());
            SceneController.instance.LoadStartPlayGameScene();
        }
        else
        {
            StartCoroutine(PlayGameTransition());
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }

    private IEnumerator PlayGameTransition()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
