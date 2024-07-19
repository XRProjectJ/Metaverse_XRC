using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EatVirus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countingText;
    [SerializeField] private GameObject belowJaw;
    [SerializeField] private GameObject overJaw;
    [SerializeField] private GameObject belowJaw2;
    [SerializeField] private GameObject overJaw2;
    private List<GameObject> eatableVirus = new List<GameObject>();
    private readonly object listLock = new object();
    private int counting = 0;
    public int count
    {
        get
        {
            return counting;
        }
        set
        {
            counting = value;
            countingText.text = counting.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EatingVirus();
        }
    }
    private void EatingVirus()
    {
        // �Ӱ豸���� ���� ()�ȿ��� object Ÿ���� ��ü�� ����� ���� ��
        // (readonly object�� ��õ-��ü�� ���ϸ� ����� ��� ���� �����ϱ� ����� ����)
        // �Ӱ豸������ ������ ������ ���������� �ڵ����� ����� ������
        lock(listLock)
        {
            // �������� �ؾ� Destroy �ص� �ε����� ��߳��� ����
            for (int i = eatableVirus.Count-1; i >= 0; i--)
            {
                GameObject obj = eatableVirus[i];
                eatableVirus.RemoveAt(i);
                // Destroy�� ��� �ı���Ű�� ���� �ƴ� ���� �����ӿ� �ı���ų ���� ������
                // -> �迭���� ���� �����ϴ� ���� �ڵ��� ������ ���鿡�� �� ����
                Destroy(obj);
                count++;
                Debug.Log(count);
            }
            //eatableVirus.Clear();
        }
        // ���� ����� ��ü�� ����� ���� ��� ������ �����ؾ� ������� ���ɼ��� ���� �� �ְ�
        // �Ӱ豸���� �۰� �ϴ� ���� ������� ���� ������ ���ɼ��� ����

        StartCoroutine(Bite());
    }
    public void AddEatableVirus(GameObject item)
    {
        lock (listLock)
        {
            eatableVirus.Add(item);
        }
        
    }
    public void RemoveEatableVirus(GameObject item)
    {
        lock (listLock)
        {
            eatableVirus.Remove(item);
        }
        
    }
    private void CloseMouth()
    {
        overJaw.transform.Translate(new Vector3(0, 0.3f, 0), Space.Self);
        belowJaw.transform.Translate(new Vector3(0, 0.3f, 0), Space.Self);
        overJaw2.transform.Translate(new Vector3(0, 0.4f, 0), Space.Self);
        belowJaw2.transform.Translate(new Vector3(0, 0.4f, 0), Space.Self);
    }
    private void OpenMouth()
    {
        overJaw.transform.Translate(new Vector3(0, -0.3f, 0), Space.Self);
        belowJaw.transform.Translate(new Vector3(0, -0.3f, 0), Space.Self);
        overJaw2.transform.Translate(new Vector3(0, -0.4f, 0), Space.Self);
        belowJaw2.transform.Translate(new Vector3(0, -0.4f, 0), Space.Self);
    }
    private IEnumerator Bite()
    {
        CloseMouth();
        yield return new WaitForSeconds(0.15f);
        OpenMouth();
    }
}
