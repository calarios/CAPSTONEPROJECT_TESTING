using UnityEngine;
using UnityEngine.SceneManagement;

//[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    //LOAD LEVEL
    private void Start()
    {
        Application.targetFrameRate = 60;
        ResetLevel();
    }

    public void ResetLevel()
    {
        int world = 1;
        int stage = 1;
        SceneManager.LoadScene($"{world}-{stage}");
    }
}