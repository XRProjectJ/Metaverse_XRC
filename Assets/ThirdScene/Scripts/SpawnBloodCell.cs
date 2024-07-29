using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBloodCell : MonoBehaviour
{
    [SerializeField] private GameObject bloodCell;
    private float deltaTime = 0.0f;
    private float repeatTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        repeatTime = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tmp;
        if (deltaTime >= repeatTime)
        {
            deltaTime = 0.0f;
            tmp = Instantiate(bloodCell);
            tmp.transform.position = this.gameObject.transform.position;

        }
        deltaTime += Time.deltaTime;
    }
}
