using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    //나에게 부딪힌 대상을 제거한다.
    //public GameObject bullet;

    public PlayerFire pFire;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("Player"))
        {
            //Destroy(collision.gameObject);

            if (collision.gameObject.name.Contains("Bullet")) // == if(collision.gameObject.name == "Bullet(Clone)")
            {
                //Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;

                collision.gameObject.SetActive(false);

                // 충돌한 총알을 탄창 비활성화 리스트에 다시 추가한다.
                pFire.magazine.Add(collision.gameObject);
            }
        }
    }
}
