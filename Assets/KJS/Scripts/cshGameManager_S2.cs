using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;

public class cshGameManager_S2 : MonoBehaviour
{
    public GameObject virusPrefab; // 바이러스 프리팹
    private int virusCount = 0; // 현재 생성된 바이러스 수

    public int countVirus;
    public TextMeshProUGUI countingText;
    public GameObject OriginCanvas;
    public GameObject FinishCanvas;
    public GameObject rayModel;

    void Start()
    {
        rayModel.SetActive(false); 
        countVirus = 0;
        StartCoroutine(SpawnVirus());
    }

    void Update()
    {
        GameObject[] viruses = GameObject.FindGameObjectsWithTag("SadVirus");
        countVirus = viruses.Length;

        countingText.text = countVirus.ToString();

        if (countVirus == 4)
        {
            OriginCanvas.SetActive(false);
            FinishCanvas.SetActive(true);

            foreach (GameObject virus in viruses)
            {
                Destroy(virus);
            }

        }

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
