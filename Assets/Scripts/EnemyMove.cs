using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 10.0f;
    public int probability = 70;
    
    

    GameObject player;
    // 0번이면 내려가기, 1번이면 쫓아가기
    int selection = 0;
    Vector3 dir;

    void Start()
    {
        player = GameObject.Find("Player");
        // 확률에 따라 1번 또는 2번의 이동 방식을 사용한다.
        selection = UnityEngine.Random.Range(0, 100);
        if(selection < probability)
        {
            dir = Vector3.down * enemySpeed * Time.deltaTime;
            dir.Normalize();
        }
        else
        {
            if(player != null)
            {
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
        }
    }

    void Update()
    {
        // 밑으로 가는 방향을 만든다.
        //Vector3 dir = Vector3.down;

        // 플레이어가 있는 위치를 행해서 이동한다.
        //dir = player.transform.position - transform.position;
        //dir.Normalize();

        //if(selection > probability)
        //{
        //    dir = player.transform.position - transform.position;
        //    dir.Normalize();
        //}

        // 움직이고 싶다.
        transform.position += dir * enemySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 대상의 태그가 Player라면
        if(collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            
            // 플레이어가 죽었을 때 옵션 창을 활성화 한다.
            GameManager.gm.SetActiveOption(true);

            // 현재 점수를 저장한다.
            GameManager.gm.SaveScore();

            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Contains("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
