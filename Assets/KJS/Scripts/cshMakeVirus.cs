using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshMakeVirus : MonoBehaviour
{
    public GameObject cubePrefab; // Cube prefab�� �������ּ���.
    public int numberOfCubes = 30; // ������ cube�� ���� 30���� �����߽��ϴ�.
    public float radius = 1f; // Sphere�� �������� �����ϼ���.

    void Start()
    {
        float phi = Mathf.PI * (3 - Mathf.Sqrt(5)); // Ȳ�ݰ��� ����մϴ�.

        for (int i = 0; i < numberOfCubes; i++)
        {
            float y = 1 - (i / (float)(numberOfCubes - 1)) * 2; // y ��ǥ�� ����մϴ�.
            float radiusForY = Mathf.Sqrt(1 - y * y); // y�� ���� �������� ����մϴ�.

            float theta = phi * i; // ������ ����մϴ�.

            // Sphere ���� ��Ģ���� ��ġ�� ����մϴ�.
            Vector3 position = new Vector3(
                Mathf.Cos(theta) * radiusForY,
                y,
                Mathf.Sin(theta) * radiusForY
            ) * radius;
            position += transform.position; // Sphere�� �߽� ��ġ�� �����ݴϴ�.

            // Cube�� �����ϰ�, ��ġ�� �����մϴ�.
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
            cube.transform.up = (cube.transform.position - transform.position).normalized; // Cube�� Sphere�� �߽��� ���ϰ� ȸ����ŵ�ϴ�.
            cube.transform.parent = this.transform; // Cube�� �θ� Sphere�� �����մϴ�.
        }
    }
}
