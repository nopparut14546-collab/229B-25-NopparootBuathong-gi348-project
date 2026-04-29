using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject loseUI;

    private Vector3 spawnPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ?????????????????????
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ???????? spawn = ??????? Player ????????
        spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        spawnPoint = newPoint;
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint;
    }

    public void ShowLoseUI()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}