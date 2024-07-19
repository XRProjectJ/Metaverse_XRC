using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMakeVirus : MonoBehaviour
{
    public GameObject cubePrefab; // Cube prefab을 연결해주세요.
    public int numberOfCubes = 30; // 생성할 cube의 수를 30으로 설정했습니다.
    public float radius = 1f; // Sphere의 반지름을 설정하세요.

    void Start()
    {
        float phi = Mathf.PI * (3 - Mathf.Sqrt(5)); // 황금각을 계산합니다.

        for (int i = 0; i < numberOfCubes; i++)
        {
            float y = 1 - (i / (float)(numberOfCubes - 1)) * 2; // y 좌표를 계산합니다.
            float radiusForY = Mathf.Sqrt(1 - y * y); // y에 대한 반지름을 계산합니다.

            float theta = phi * i; // 각도를 계산합니다.

            // Sphere 위의 규칙적인 위치를 계산합니다.
            Vector3 position = new Vector3(
                Mathf.Cos(theta) * radiusForY,
                y,
                Mathf.Sin(theta) * radiusForY
            ) * radius;
            position += transform.position; // Sphere의 중심 위치를 더해줍니다.

            // Cube를 생성하고, 위치를 설정합니다.
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
            cube.transform.up = (cube.transform.position - transform.position).normalized; // Cube를 Sphere의 중심을 향하게 회전시킵니다.
            cube.transform.parent = this.transform; // Cube의 부모를 Sphere로 설정합니다.
        }
    }
}
