using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotto : MonoBehaviour
{
    // 1~45������ ���� �߿� �ϳ��� ���� 6�� ��÷�Ѵ�.
    // �� ������ ���� �ߺ��Ǵ� ���� ������ �Ͽ��� �Ѵ�.

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
        //        // �� �̾Ҽ�
        //        int draw = UnityEngine.Random.Range(1, 46);
        //        // �� ������ �ߺ������� �߿���
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
