using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;

    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        StartGame();
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int) surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void StartGame()
    {
        gameOverText.SetActive(false);
        recordText.enabled = false;
    }

    public void EndGame()
    {
        isGameover = true;
        recordText.enabled = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int)bestTime;
    }
}
