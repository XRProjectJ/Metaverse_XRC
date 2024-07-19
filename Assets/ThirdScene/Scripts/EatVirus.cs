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
        // 임계구역을 설정 ()안에는 object 타입의 객체가 잠금을 위해 들어감
        // (readonly object를 추천-객체가 변하면 잠금이 어떻게 될지 예상하기 힘들기 때문)
        // 임계구역으로 설정된 범위를 빠져나오면 자동으로 잠금이 해제됨
        lock(listLock)
        {
            // 역순으로 해야 Destroy 해도 인덱스가 어긋나지 않음
            for (int i = eatableVirus.Count-1; i >= 0; i--)
            {
                GameObject obj = eatableVirus[i];
                eatableVirus.RemoveAt(i);
                // Destroy는 즉시 파괴시키는 것이 아닌 다음 프레임에 파괴시킬 것을 예약함
                // -> 배열에서 먼저 제거하는 것이 코드의 안정성 측면에서 더 좋다
                Destroy(obj);
                count++;
                Debug.Log(count);
            }
            //eatableVirus.Clear();
        }
        // 여러 잠금을 객체를 사용할 때는 잠금 순서를 통일해야 데드락의 가능성을 낮출 수 있고
        // 임계구역은 작게 하는 것이 데드락과 성능 저하의 가능성을 낮춤

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
