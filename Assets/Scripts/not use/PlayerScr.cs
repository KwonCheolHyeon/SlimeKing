using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{

    public float Speed;              // 좌, 우로 움직이는 스피드.
    public float Gravity;            // 작용하는 중력.

    // 비공개
    private Vector2 Pos;            // 플레이어가 실직적으로 움직일 좌, 우 벡터.
    private Vector2 Dir;            // 점프 및 낙하 여부의 벡터.
    private Vector2 Radius;         // 플레이어의 x,y의 반지름.

    private float H;                // Horizontal.
    private bool isGround;          // 현재 땅이냐? true 땅이 아니냐? false

    // 각종 값 초기화.
    void Init()
    {
        Pos = Vector2.zero;
        Dir = Vector2.down;
        Radius = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);

        H = 0;
        isGround = false;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        H = Input.GetAxis("Horizontal");
        CollisionCheck();
        Move();
    }

    // 좌, 우 움직임.
    void Move()
    {
        Pos.Set(H * Speed, Pos.y);
        transform.Translate(Pos * Time.deltaTime);
    }

    // 충돌 체크를 위한 레이 캐스트.
    void CollisionCheck()
    {
        for (int i = -1; i < 2; i++)
        {
            Vector2 MyPos = transform.position;
            MyPos = new Vector2(MyPos.x + (Radius.x * i), MyPos.y);
            RayCastFire(MyPos, Dir, Radius.y + 0.1f);
        }

    }

    // 레이캐스트를 발사한다.
    void RayCastFire(Vector2 _Axis, Vector2 _Dir, float _length)
    {
        RaycastHit Hit;
        Debug.DrawRay(_Axis, _Dir * _length, Color.blue, 1);
        if (Physics.Raycast(_Axis, _Dir, out Hit, _length))
        {
            // Ray를 발사 했는데 땅에 맞았음.
            if (Hit.collider.gameObject.layer == 8)
            {
                // 플레이어가 땅에 있으면 함수 종료.
                if (isGround)
                    return;

                Transform Target = Hit.transform;

                // 충돌한 블럭의 위에 정착.
                transform.position = new Vector2(transform.position.x, Target.position.y + (Target.localScale.y * 0.5f) + _length);
                Pos.y = 0;       // 중력이 작용했던 값에 대해 0으로 초기화.
                isGround = true; // 이제 땅에 있다고 표시.
                return;
            }
        }

        // Ray를 발사 했는데 땅에 맞지 않았음.
        isGround = false;
        Pos.y -= Gravity * Time.deltaTime;
    }
}
