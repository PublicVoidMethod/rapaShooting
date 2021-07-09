using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Material�� UV�� OffSet ������ y���� ������Ų��.
    // Material, MeshRenderer, OffSet(Vector2), ��ũ�� �ӵ�
    public float scrollSpeed = 0.3f;

    MeshRenderer mr;
    Material mat;

    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();

        // �޽� �������� Material�� �����´�.
        mat = mr.materials[0];
    }

    void Update()
    {
        // Material�� UV offset ���� �����Ѵ�.
        mat.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
