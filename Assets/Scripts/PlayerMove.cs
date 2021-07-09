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
        //    print("아이 빌립~ 아이 캔 플라이~");
        //}

        // 사용자의 입력을 받아서 상하 또는 좌우로 이동을 하고 싶다.
        // 사용자 입력 : 좌우 화살표 키, 상하 화살표 키, WASD 키
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 필요 요소 : 속도(=방향, 속력), 시간
        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();

        // 좌측 Shift 키를 누른 상태일 때에는 속도가 2배로 증가한다.
        // 좌측 Shift 키에서 손을 떼면 다시 원래 속도대로 돌아온다.
        if(Input.GetKey(KeyCode.LeftShift) && moveSpeed < 14.0f)
        {
            moveSpeed *= 2;
        }
        else
        {
            moveSpeed = 7.0f;
        }
        // dir에 정해진 방향대로 이동하고 싶다.
        //transform.position += dir * moveSpeed * Time.deltaTime;
        //Vector3 pos = transform.position + dir * moveSpeed * Time.deltaTime;
        //rb.MovePosition(pos);

        #region 플레이어를 뷰포트에 가둔다.
        //// 플레이어를 Viewport에 가둔다
        //// 월드 공간의 위치를 뷰포트 공간의 위치로 바꾼다.
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);
        //Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        //// 제한 적용된 뷰포트 좌표를 월드 좌표로 변환해서플레이어 포지션으로 덮어쓴다.
        //transform.position = worldPos;

        //rb.velocity = dir * moveSpeed;
        #endregion

        // 이번 프레임에 도착할 지점의 좌표를 구한다.
        Vector3 arrivePos = dir * moveSpeed * Time.deltaTime;

        // 현재 위치에서 도착 지점까지 레이를 발사해본다.
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
