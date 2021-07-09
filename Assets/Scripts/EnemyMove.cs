using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 10.0f;
    public int probability = 70;
    
    

    GameObject player;
    // 0���̸� ��������, 1���̸� �Ѿư���
    int selection = 0;
    Vector3 dir;

    void Start()
    {
        player = GameObject.Find("Player");
        // Ȯ���� ���� 1�� �Ǵ� 2���� �̵� ����� ����Ѵ�.
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
        // ������ ���� ������ �����.
        //Vector3 dir = Vector3.down;

        // �÷��̾ �ִ� ��ġ�� ���ؼ� �̵��Ѵ�.
        //dir = player.transform.position - transform.position;
        //dir.Normalize();

        //if(selection > probability)
        //{
        //    dir = player.transform.position - transform.position;
        //    dir.Normalize();
        //}

        // �����̰� �ʹ�.
        transform.position += dir * enemySpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ����� �±װ� Player���
        if(collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            
            // �÷��̾ �׾��� �� �ɼ� â�� Ȱ��ȭ �Ѵ�.
            GameManager.gm.SetActiveOption(true);

            // ���� ������ �����Ѵ�.
            GameManager.gm.SaveScore();

            Destroy(gameObject);
        }
        else if (collision.gameObject.name.Contains("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
