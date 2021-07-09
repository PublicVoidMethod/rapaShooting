using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Material의 UV의 OffSet 값에서 y축을 증가시킨다.
    // Material, MeshRenderer, OffSet(Vector2), 스크롤 속도
    public float scrollSpeed = 0.3f;

    MeshRenderer mr;
    Material mat;

    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();

        // 메쉬 렌더러의 Material을 가져온다.
        mat = mr.materials[0];
    }

    void Update()
    {
        // Material의 UV offset 값을 변경한다.
        mat.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
