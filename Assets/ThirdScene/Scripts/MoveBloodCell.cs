using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBloodCell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = new Vector3(Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f), Random.Range(-360.0f, 360.0f));
        this.gameObject.transform.rotation = Quaternion.Euler(rot);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, 0, Random.Range(100.0f, 200.0f)*Time.deltaTime), Space.World);
    }
}
