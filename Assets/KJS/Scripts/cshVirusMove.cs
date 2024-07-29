using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVirusMove : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject plane;
    public float minY = 0.01f;
    public float maxY = 1.0f;
    public float rotationSpeed = 2.0f;
    public float bobbingSpeed = 0.1f;
    public float bobbingAmount = 0.1f;

    private Vector3 targetPosition;
    private float timer = 0.0f;

    private void Start()
    {
        targetPosition = GetRandomPositionOnPlane();
    }

    private void Update()
    {
        // 목표 위치까지 이동
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // 목표 위치를 향해 회전
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // 위아래 움직임
        timer += Time.deltaTime * bobbingSpeed;
        float waveOffset = (Mathf.Sin(timer) + 1) / 2 * bobbingAmount;
        transform.position = new Vector3(transform.position.x, waveOffset, transform.position.z);

        // 목표 위치에 가까워지면 새로운 위치 선택
        if (Vector3.Distance(transform.position, targetPosition) < 2.0f)
        {
            targetPosition = GetRandomPositionOnPlane();
        }
    }

    private Vector3 GetRandomPositionOnPlane()
    {
        float planeWidth = plane.transform.localScale.x*10;
        float planeLength = plane.transform.localScale.z*10;

        float randomX = Random.Range(-planeWidth / 2, planeWidth / 2);
        float randomZ = Random.Range(-planeLength / 2, planeLength / 2);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, randomZ);
    }
}
