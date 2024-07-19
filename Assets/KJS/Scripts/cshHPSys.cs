using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshHPSys : MonoBehaviour
{
    public int HP = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 모든 자식 오브젝트들 중에서 SetActive 상태인 antibody의 개수를 세기
        int activeAntibodyCount = CountActiveAntibodies(transform);

        // 만약 그 개수가 3개 이상이면, 해당 오브젝트들을 파괴
        if (activeAntibodyCount >= HP)
        {
            Destroy(gameObject);
        }
    }

    int CountActiveAntibodies(Transform parent)
    {
        int count = 0;
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf && child.name == "antibody")
            {
                count++;
            }
            count += CountActiveAntibodies(child);
        }
        return count;
    }
}
