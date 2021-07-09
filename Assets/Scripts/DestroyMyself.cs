using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    public float delayTime = 1.0f;

    float currentTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= delayTime)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
    }
}
