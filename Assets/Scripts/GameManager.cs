using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text nowScore;
    float time = 0.0f;

    bool isPlay = true;

    private void Awake() {
        if (Instance == null)
            Instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay) {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    void MakeSquare() {
        Instantiate(square);
    }

    public void GameOver() {
        isPlay = false;
        Time.timeScale = 0.0f;
        nowScore.text = time.ToString("N2");
        endPanel.SetActive(true);
    }
}
