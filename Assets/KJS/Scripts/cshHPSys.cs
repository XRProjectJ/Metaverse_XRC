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
        // ��� �ڽ� ������Ʈ�� �߿��� SetActive ������ antibody�� ������ ����
        int activeAntibodyCount = CountActiveAntibodies(transform);

        // ���� �� ������ 3�� �̻��̸�, �ش� ������Ʈ���� �ı�
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
