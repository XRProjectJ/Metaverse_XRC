using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCamFollow : MonoBehaviour
{
    // 목표가 될 트랜스폼 컴포넌트
    public Transform target;

    void Update()
    {
        // 카메라의 위치를 목표 트랜스폼의 위치에 일치시킨다.
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }

}
