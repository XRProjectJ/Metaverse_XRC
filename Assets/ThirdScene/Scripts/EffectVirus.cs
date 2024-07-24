using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectVirus : MonoBehaviour
{
    private float dtime = 0;
    private int[] directions = new int[2];
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        directions[0] = -1;
        directions[1] = 1;
        direction = directions[Random.Range(0, 1)];
    }

    // Update is called once per frame
    void Update()
    {
        dtime += Time.deltaTime;

        if (dtime < 0.3f)
        {
            this.transform.Translate(new Vector3(3.0f*direction, 0.0f, 0.0f) * Time.deltaTime, Space.Self);
        }
        else 
        {
            dtime = 0.0f;
            direction = -direction;
        }
    }
}
