using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotto : MonoBehaviour
{
    // 1~45까지의 정수 중에 하나의 값을 6번 추첨한다.
    // 단 각각의 값이 중복되는 일이 없도록 하여야 한다.

    public List<int> myNumbers = new List<int>();
    

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    for(int i = 0; i < 6; i++)
        //    {
        //        // 난 뽑았소
        //        int draw = UnityEngine.Random.Range(1, 46);
        //        // 이 뽑은게 중복인지가 중요해
        //        if (myNumbers.Contains(draw))
        //        {
        //            i--;
        //        }
        //        else
        //        {
        //            myNumbers.Add(draw);
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 6; i++)
            {
                int draw = UnityEngine.Random.Range(1, 46);
                myNumbers.Add(draw);
                for (int j = 0; j < i; j++)
                {
                    if (myNumbers[j] == draw)
                    {
                        myNumbers.RemoveAt(i);
                        i--;
                        break;
                    }
                    //else
                    //{
                    //    myNumbers.Add(draw);
                    //}
                }
            }
        }
    }
}
