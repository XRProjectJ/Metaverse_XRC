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
            //수류탄 오브젝트를 생성하고, 수류탄의 생성 위치를 발사 위치로 한다.

            //switch (wMode)
            //{
            //    case WeaponMode.Normal:
            //        // 수류탄 오브젝트를 생성하고, 수류탄의 생성 위치를 발사 위치로 한다.
            //        GameObject bomb = Instantiate(bombFactory);
            //        bomb.transform.position = firePosition.transform.position;
            //
            //        // 수류탄 오브젝트의 Rigidbody 컴포넌트를 가져온다.
            //        Rigidbody rb = bomb.GetComponent<Rigidbody>();
            //
            //        // 카메라의 정면 방향으로 수류탄에 물리적인 힘을 가한다.
            //        rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
            //        break;
            //
            //    case WeaponMode.Sniper:
            //        // 만일, 줌 모드 상태가 아니라면 카메라를 확대하고 줌 모드 상태로 변경한다.
            //        if (!ZoomMode)
            //        {
            //            Camera.main.fieldOfView = 15f;
            //            ZoomMode = true;
            //        }
            //        // 그렇지 않으면, 카메라를 원래 상태로 되돌리고 줌 모드 상태를 해제한다.
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
