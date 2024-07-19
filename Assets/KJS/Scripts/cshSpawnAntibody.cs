using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnAntibody : MonoBehaviour
{
    public Transform Bullet;
    public float fireTime = 1.0f;
    public float firePassTime = 0.0f;
    public Transform BulletFirePos;

    // Update is called once per frame
    void Update()
    {
        if (firePassTime >= fireTime)
        {
            Instantiate(Bullet, BulletFirePos.position, BulletFirePos.rotation);
            firePassTime = 0.0f;
        }
        else
        {
            firePassTime += Time.deltaTime;
        }
    }

}
