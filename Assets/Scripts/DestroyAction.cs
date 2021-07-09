using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    //������ �ε��� ����� �����Ѵ�.
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

                // �浹�� �Ѿ��� źâ ��Ȱ��ȭ ����Ʈ�� �ٽ� �߰��Ѵ�.
                pFire.magazine.Add(collision.gameObject);
            }
        }
    }
}
