using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFire : MonoBehaviour
{
    public float bulletSpeed = 500.0f;
    public GameObject antibodyPref;
    public GameObject firePos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FireAntibody();
            //����ź ������Ʈ�� �����ϰ�, ����ź�� ���� ��ġ�� �߻� ��ġ�� �Ѵ�.

            //switch (wMode)
            //{
            //    case WeaponMode.Normal:
            //        // ����ź ������Ʈ�� �����ϰ�, ����ź�� ���� ��ġ�� �߻� ��ġ�� �Ѵ�.
            //        GameObject bomb = Instantiate(bombFactory);
            //        bomb.transform.position = firePosition.transform.position;
            //
            //        // ����ź ������Ʈ�� Rigidbody ������Ʈ�� �����´�.
            //        Rigidbody rb = bomb.GetComponent<Rigidbody>();
            //
            //        // ī�޶��� ���� �������� ����ź�� �������� ���� ���Ѵ�.
            //        rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            //        break;
            //
            //    case WeaponMode.Sniper:
            //        // ����, �� ��� ���°� �ƴ϶�� ī�޶� Ȯ���ϰ� �� ��� ���·� �����Ѵ�.
            //        if (!ZoomMode)
            //        {
            //            Camera.main.fieldOfView = 15f;
            //            ZoomMode = true;
            //        }
            //        // �׷��� ������, ī�޶� ���� ���·� �ǵ����� �� ��� ���¸� �����Ѵ�.
            //        else
            //        {
            //            Camera.main.fieldOfView = 60f;
            //            ZoomMode = false;
            //        }
            //        break;
            //}
        }
    }

    void FireAntibody()
    {
        GameObject antibody = Instantiate(antibodyPref);
        antibody.transform.position = firePos.transform.position;
        antibody.GetComponent<Rigidbody>().AddForce(firePos.transform.forward * bulletSpeed);
    }

}
