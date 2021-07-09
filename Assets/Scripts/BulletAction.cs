using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    public float bulletSpeed = 8.0f;
    public GameObject bulletEffect;

    void Start()
    {
        //ps = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // 총알은 생성되면 위쪽으로 한없이 올라간다.
        // 위로 가는 방향을 만들고
        Vector3 dir = Vector3.up;

        // 총알을 이동시킨다.
        transform.position += dir * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 대상의 이름이 Enemy를 포함하고 있다면
        //if (collision.gameObject.name.Contains("Enemy"))
        // 부딪힌 대상의 태그가 Enemy라면
        if(collision.gameObject.tag == "Enemy")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 6.0f, 1 << 8);
            for(int i = 0; i < cols.Length; i++)
            {
                Destroy(cols[i].gameObject);
            }

            // while 반복문
            //int i = 0;
            //while(i < cols.Length)
            //{
            //    Destroy(cols[i].gameObject);
            //    i++
            //}

            // foreach 반복문
            //foreach(Collider enemy in cols)
            //{
            //    Destroy(enemy.gameObject);
            //}
            
            Destroy(collision.gameObject);

            // 폭발 이펙트 오브젝트를 생성한 뒤 이펙트를 실행한다.
            GameObject go = Instantiate(bulletEffect, collision.transform.position, Quaternion.identity);
            ParticleSystem ps = go.GetComponentInChildren<ParticleSystem>();
            ps.Stop();
            ps.Play();

            GameManager.gm.currentScore++;

            Destroy(gameObject);
        }
    }
}
