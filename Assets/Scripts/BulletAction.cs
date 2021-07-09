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
        // �Ѿ��� �����Ǹ� �������� �Ѿ��� �ö󰣴�.
        // ���� ���� ������ �����
        Vector3 dir = Vector3.up;

        // �Ѿ��� �̵���Ų��.
        transform.position += dir * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ����� �̸��� Enemy�� �����ϰ� �ִٸ�
        //if (collision.gameObject.name.Contains("Enemy"))
        // �ε��� ����� �±װ� Enemy���
        if(collision.gameObject.tag == "Enemy")
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, 6.0f, 1 << 8);
            for(int i = 0; i < cols.Length; i++)
            {
                Destroy(cols[i].gameObject);
            }

            // while �ݺ���
            //int i = 0;
            //while(i < cols.Length)
            //{
            //    Destroy(cols[i].gameObject);
            //    i++
            //}

            // foreach �ݺ���
            //foreach(Collider enemy in cols)
            //{
            //    Destroy(enemy.gameObject);
            //}
            
            Destroy(collision.gameObject);

            // ���� ����Ʈ ������Ʈ�� ������ �� ����Ʈ�� �����Ѵ�.
            GameObject go = Instantiate(bulletEffect, collision.transform.position, Quaternion.identity);
            ParticleSystem ps = go.GetComponentInChildren<ParticleSystem>();
            ps.Stop();
            ps.Play();

            GameManager.gm.currentScore++;

            Destroy(gameObject);
        }
    }
}
