using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SoundManager.PlayBackgroundMusic(BGMType.BGM1, 0.1f);
    }

    public IEnumerator RespawRoutine(PlayerController player, float delaytime)
    {
        SoundManager.StopSFX();
        yield return new WaitForSeconds(delaytime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
