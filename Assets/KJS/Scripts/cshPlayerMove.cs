using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPlayerMove : MonoBehaviour
{
    // �̵� �ӵ� ����
    public float moveSpeed = 7f;

    // ĳ���� ��Ʈ�ѷ� ����
    CharacterController cc;

    // �߷� ����
    float gravity = -20f;

    // ���� �ӷ� ����
    public float yVelocity = 0;

    // ������ ����
    public float jumpPower = 10f;

    // ���� ���� ����
    public bool isJumping = false;

    // �÷��̾� ü�� ����
    public int hp = 20;

    // �ִ� ü�� ����
    int maxHp = 20;




    void Start()
    {
        // ĳ���� ��Ʈ�ѷ� ������Ʈ �޾ƿ���
        cc = GetComponent<CharacterController>();

    }

    void Update()
    {
       

        // Ű���� <W>, <A>, <S>, <D> ��ư�� �Է��ϸ� ĳ���͸� �� �������� �̵���Ű�� �ʹ�.
        // Ű���� <Space> ��ư�� �Է��ϸ� ĳ���͸� �������� ������Ű�� �ʹ�.

        // 1. ������� �Է��� �޴´�.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. �̵� ������ �����Ѵ�.
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;


        // 2-1. ���� ī�޶� �������� ������ ��ȯ�Ѵ�.
        dir = Camera.main.transform.TransformDirection(dir);

        // 2-2. ����, ���� ���̾���, �ٽ� �ٴڿ� �����ߴٸ�...
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            // ���� �� ���·� �ʱ�ȭ�Ѵ�.
            isJumping = false;
            // ĳ���� ���� �ӵ��� 0���� �����.
            yVelocity = 0;
        }

        // 2-3. ����, Ű���� <Space> ��ư�� �Է��߰�, ������ �� �� ���¶��...
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // ĳ���� ���� �ӵ��� �������� �����ϰ� ���� ���·� �����Ѵ�.
            yVelocity = jumpPower;
            isJumping = true;
        }

        // 2-4. ĳ���� ���� �ӵ��� �߷� ���� �����Ѵ�.
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 3. �̵� �ӵ��� ���� �̵��Ѵ�.
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }

}
