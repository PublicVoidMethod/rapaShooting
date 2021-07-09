//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameOverFadeIn : MonoBehaviour
//{
//    public float animTime = 1.0f;

//    Text fadeText;

//    float start = 0f;
//    float end = 1.0f;
//    float currentTime = 0f;

//    private void Start()
//    {
//        // 이미지 컴포넌트를 가져온다.
//        fadeText = GetComponent<Text>();
//    }

//    private void Update()
//    {
//        PlayFadeIn();
//    }

//    void PlayFadeIn()
//    {
//        //Time.timeScale = 1f;

//        // 시간을 누적시킨다.
//        currentTime += Time.deltaTime / animTime;

//        // 이미지 컴포넌트의 컬러를 불러온다.
//        Color color = fadeText.color;

//        // 컬러의 투명도를 0 ~ 1 값으로 점점 늘린다.
//        color.a = Mathf.Lerp(start, end, currentTime);

//        fadeText.color = color;
        
        
//    }

//    #region Lerp
//    //public float result = 1.0f;
//    //public float playSpeed = 1.0f;

//    //float currentTime = 0;

//    //Vector3 startPos;

//    //void Start()
//    //{
//    //    startPos = transform.position;
//    //}

//    //void Update()
//    //{
//    //    if(currentTime <= 1.0f)
//    //    {
//    //        currentTime += Time.deltaTime * (1.0f / playSpeed);

//    //        result = Mathf.Lerp(1, 10, currentTime);
//    //        Vector3 test = new Vector3(result, 0, 0);
//    //        transform.position = startPos + test;
//    //    }
//    //    else
//    //    {
//    //        currentTime = 0;
//    //    }
//    //}
//    #endregion
//}
