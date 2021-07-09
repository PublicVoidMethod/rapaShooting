using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7.0f;
    //public float boostSpeed = 14.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    print("���� ����~ ���� ĵ �ö���~");
        //}

        // ������� �Է��� �޾Ƽ� ���� �Ǵ� �¿�� �̵��� �ϰ� �ʹ�.
        // ����� �Է� : �¿� ȭ��ǥ Ű, ���� ȭ��ǥ Ű, WASD Ű
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // �̵� �ʿ� ��� : �ӵ�(=����, �ӷ�), �ð�
        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();

        // ���� Shift Ű�� ���� ������ ������ �ӵ��� 2��� �����Ѵ�.
        // ���� Shift Ű���� ���� ���� �ٽ� ���� �ӵ���� ���ƿ´�.
        if(Input.GetKey(KeyCode.LeftShift) && moveSpeed < 14.0f)
        {
            moveSpeed *= 2;
        }
        else
        {
            moveSpeed = 7.0f;
        }
        // dir�� ������ ������ �̵��ϰ� �ʹ�.
        //transform.position += dir * moveSpeed * Time.deltaTime;
        //Vector3 pos = transform.position + dir * moveSpeed * Time.deltaTime;
        //rb.MovePosition(pos);

        #region �÷��̾ ����Ʈ�� ���д�.
        //// �÷��̾ Viewport�� ���д�
        //// ���� ������ ��ġ�� ����Ʈ ������ ��ġ�� �ٲ۴�.
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);
        //Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //// ���� ����� ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ�ؼ��÷��̾� ���������� �����.
        //transform.position = worldPos;

        //rb.velocity = dir * moveSpeed;
        #endregion

        // �̹� �����ӿ� ������ ������ ��ǥ�� ���Ѵ�.
        Vector3 arrivePos = dir * moveSpeed * Time.deltaTime;

        // ���� ��ġ���� ���� �������� ���̸� �߻��غ���.
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, arrivePos.magnitude))
        {
            transform.position = hitInfo.point;
            transform.position -= dir * 0.5f;
        }
        else
        {
            rb.velocity = dir * moveSpeed;
        }
    }
}
