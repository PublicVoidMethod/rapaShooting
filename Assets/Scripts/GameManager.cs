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

        // ���� ������ UI�� �ݿ��Ѵ�.
        scoreText[0].text = "���� ���� : " + currentScore.ToString();

        // ���̵� ����Ʈ�� �����Ѵ�.
        if(fadeStart == true)
        {
            FadeEffect();
        }
    }

    // �ɼ� â�� �����ϴ� �Լ�
    public void SetActiveOption(bool toggle)
    {
        // UI â�� Ȱ��ȭ�Ѵ�.
        canvasUI.SetActive(toggle);

        fadeStart = toggle;

        //// ������Ʈ�� �ð��� �帧�� �����.
        //if (toggle)
        //{
        //    Time.timeScale = 0f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}
    }

    // �ְ� ���ھ ������ġ�� �����Ѵ�.
    public void SaveScore()
    {
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("score", currentScore);
            print("���� �Ϸ�ƽ��ϴ�.");
        }

    }

    // ����� ������ �ְ� ������ ����Ѵ�.
    void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("score");

        scoreText[1].text = "�ְ� ���� : " + bestScore.ToString();
    }

    void FadeEffect()
    {
        // ���� ���� ������ ������ ��ǥ�� ������ �ð��� �帧�� ���� ��ȭ��Ű�� �ʹ�.
        // Lerp �Լ�
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
