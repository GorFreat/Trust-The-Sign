using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator sceneAnimator;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(SceneTransitionRoutine());
    }

    IEnumerator SceneTransitionRoutine()
    {
        SoundManager.StopSFX();
        sceneAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        sceneAnimator.SetTrigger("Start");
    }


    public void LoadMainMenuScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadStartPlayGameScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level1");
    }
}
