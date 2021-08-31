using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{

    public float Speed;              // ��, ��� �����̴� ���ǵ�.
    public float Gravity;            // �ۿ��ϴ� �߷�.

    // �����
    private Vector2 Pos;            // �÷��̾ ���������� ������ ��, �� ����.
    private Vector2 Dir;            // ���� �� ���� ������ ����.
    private Vector2 Radius;         // �÷��̾��� x,y�� ������.

    private float H;                // Horizontal.
    private bool isGround;          // ���� ���̳�? true ���� �ƴϳ�? false

    // ���� �� �ʱ�ȭ.
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

    // ��, �� ������.
    void Move()
    {
        Pos.Set(H * Speed, Pos.y);
        transform.Translate(Pos * Time.deltaTime);
    }

    // �浹 üũ�� ���� ���� ĳ��Ʈ.
    void CollisionCheck()
    {
        for (int i = -1; i < 2; i++)
        {
            Vector2 MyPos = transform.position;
            MyPos = new Vector2(MyPos.x + (Radius.x * i), MyPos.y);
            RayCastFire(MyPos, Dir, Radius.y + 0.1f);
        }

    }

    // ����ĳ��Ʈ�� �߻��Ѵ�.
    void RayCastFire(Vector2 _Axis, Vector2 _Dir, float _length)
    {
        RaycastHit Hit;
        Debug.DrawRay(_Axis, _Dir * _length, Color.blue, 1);
        if (Physics.Raycast(_Axis, _Dir, out Hit, _length))
        {
            // Ray�� �߻� �ߴµ� ���� �¾���.
            if (Hit.collider.gameObject.layer == 8)
            {
                // �÷��̾ ���� ������ �Լ� ����.
                if (isGround)
                    return;

                Transform Target = Hit.transform;

                // �浹�� ���� ���� ����.
                transform.position = new Vector2(transform.position.x, Target.position.y + (Target.localScale.y * 0.5f) + _length);
                Pos.y = 0;       // �߷��� �ۿ��ߴ� ���� ���� 0���� �ʱ�ȭ.
                isGround = true; // ���� ���� �ִٰ� ǥ��.
                return;
            }
        }

        // Ray�� �߻� �ߴµ� ���� ���� �ʾ���.
        isGround = false;
        Pos.y -= Gravity * Time.deltaTime;
    }
}
