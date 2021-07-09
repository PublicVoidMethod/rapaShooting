using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // ������ �ð����� ���ʹ̸� �����ϰ� �ʹ�.
    // 1. ���� �ð��� üũ�ؼ� ������ �ð��� �Ǿ����� Ȯ���Ѵ�.
    // 1-1. ���� ��ġ�� ������ ��ġ�� ���ʹ̸� �����Ѵ�.
    // 1-2. ���� �ð��� 0���� �ʱ�ȭ�Ѵ�
    // 2. ���� ���������κ��� ���� �����ӱ��� �ɸ� �ð��� ���� �ð� ������ �����Ѵ�.
    public float coolTime = 2.0f;
    public GameObject enemySource;

    float currentTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // ���� �ð��� ����
        currentTime += Time.deltaTime;

        // ���� �����Ǵ� �ð��� coolTime���� Ŀ���ٸ�
        if(currentTime >= coolTime)
        {
            //// ���ʹ� �������� �����ϰ�
            //GameObject go = Instantiate(enemySource);
            //// ������ ���ʹ� �������� ���� ��ġ�� ��ġ��Ų��.
            //go.transform.position = transform.position;
            Instantiate(enemySource, transform.position, Quaternion.identity);

            // ���� �ð��� 0�ʷ� �ʱ�ȭ��Ų��.
            currentTime = 0f;
        }
    }
}
