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
    public Text bestScore;

    public Animator anim;

    float time = 0.0f;

    string key = "bestScore";
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
        anim.SetBool("isDie", true);
        Invoke("TimeStop", 0.5f);   // delay 시키는 함수 timestop을 0.5f 뒤에
        nowScore.text = time.ToString("N2");

        // 최고 점수가 있다면
        if (PlayerPrefs.HasKey(key)) 
        {
            float best = PlayerPrefs.GetFloat(key);
            

            if (best < time) { // 최고 점수 < 현재 점수
                // 현재 점수를 최고 점수에 저장한다.
                PlayerPrefs.SetFloat(key, time);
                // 현재 점수를 text로 보내서 띄운다
                bestScore.text = time.ToString("N2");
            }
            else { // 최고 점수 > 현재 점수 
                // 최고 점수를 text로 보내서 띄운다
                bestScore.text = best.ToString("N2");
            }
        }

        // 최고 점수가 없다면
        else {
            // 현재 점수를 저장한다.
            PlayerPrefs.SetFloat(key, time);
            // 현재 점수를 text로 보내서 띄운다다
            bestScore.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }

    void TimeStop() {
        Time.timeScale = 0.0f;
    }
}
