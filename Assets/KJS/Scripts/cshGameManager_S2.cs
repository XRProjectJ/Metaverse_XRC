using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshGameManager_S2 : MonoBehaviour
{
    public GameObject virusPrefab; // 바이러스 프리팹
    private int virusCount = 0; // 현재 생성된 바이러스 수

    void Start()
    {
        StartCoroutine(SpawnVirus());
    }

    IEnumerator SpawnVirus()
    {
        while (virusCount < 4)
        {
            Instantiate(virusPrefab, Vector3.zero, Quaternion.identity);
            virusCount++;
            yield return new WaitForSeconds(5);
        }
    }
}
