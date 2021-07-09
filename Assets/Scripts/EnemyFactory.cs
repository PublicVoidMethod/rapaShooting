using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // 지정된 시간마다 에너미를 생성하고 싶다.
    // 1. 현재 시간을 체크해서 지정된 시간이 되었는지 확인한다.
    // 1-1. 나의 위치와 동일한 위치에 에너미를 생성한다.
    // 1-2. 현재 시간을 0으로 초기화한다
    // 2. 직전 프레임으로부터 현재 프레임까지 걸린 시간을 현재 시간 변수에 누적한다.
    public float coolTime = 2.0f;
    public GameObject enemySource;

    float currentTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // 현재 시간을 누적
        currentTime += Time.deltaTime;

        // 현재 누적되는 시간이 coolTime보다 커진다면
        if(currentTime >= coolTime)
        {
            //// 에너미 프리팹을 생성하고
            //GameObject go = Instantiate(enemySource);
            //// 생성한 에너미 프리팹을 나의 위치에 위치시킨다.
            //go.transform.position = transform.position;
            Instantiate(enemySource, transform.position, Quaternion.identity);

            // 현재 시간을 0초로 초기화시킨다.
            currentTime = 0f;
        }
    }
}
