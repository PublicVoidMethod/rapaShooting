using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // single tone pattern
    public static GameManager gm;

    public GameObject canvasUI;
    
    public Image backImage;
    public Text label;

    Color startImageColor;
    Color startlavelColor;
    int startFontSize;

    float currenTime = 0;

    public Text[] scoreText = new Text[2];

    public int currentScore = 0;
    public int bestScore = 0;

    bool fadeStart = false;
    
    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startImageColor = backImage.color;
        startlavelColor = label.color;
        startFontSize = label.fontSize;


        SetActiveOption(false);
        LoadScore();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActiveOption(true);
        }

        // 현재 점수를 UI에 반영한다.
        scoreText[0].text = "현재 점수 : " + currentScore.ToString();

        // 페이드 이펙트를 실행한다.
        if(fadeStart == true)
        {
            FadeEffect();
        }
    }

    // 옵션 창을 생성하는 함수
    public void SetActiveOption(bool toggle)
    {
        // UI 창을 활성화한다.
        canvasUI.SetActive(toggle);

        fadeStart = toggle;

        //// 오브젝트의 시간의 흐름을 멈춘다.
        //if (toggle)
        //{
        //    Time.timeScale = 0f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}
    }

    // 최고 스코어를 저장장치에 저장한다.
    public void SaveScore()
    {
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("score", currentScore);
            print("저장 완료됐습니다.");
        }

    }

    // 저장된 점수를 최고 점수로 출력한다.
    void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("score");

        scoreText[1].text = "최고 점수 : " + bestScore.ToString();
    }

    void FadeEffect()
    {
        // 값을 최초 저자한 값에서 목표한 값으로 시간에 흐름에 따라 변화시키고 싶다.
        // Lerp 함수
        if(currenTime <= 1)
        {
            currenTime += Time.deltaTime;

            //float alpha = Mathf.Lerp(startImageColor.a, 0.9f, currenTime);
            //backImage.color = new Color(startImageColor.r, startImageColor.g, startImageColor.b, alpha);
            backImage.color = Color.Lerp(startImageColor, new Color(startImageColor.r, startImageColor.g, startImageColor.b, 0.9f), currenTime);

            //float alpha2 = Mathf.Lerp(startlavelColor.a, 1.0f, currenTime);
            //label.color = startlavelColor + new Color(0, 0, 0, alpha2);
            label.color = Color.Lerp(startlavelColor, startlavelColor + new Color(0, 0, 0, 1.0f), currenTime);

            int size = (int)Mathf.Lerp((float)startFontSize, 90f, currenTime);
            label.fontSize = size;
        }
        else
        {
            Time.timeScale = 0;
            fadeStart = false;
        }

    }
}
