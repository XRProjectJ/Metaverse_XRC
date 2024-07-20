using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVirus : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private RingColorChange ring;

    private float duration = 0.2f;
    private float magnitude = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            Destroy(other.gameObject);
            Quaternion origin = cam.transform.rotation;
            StartCoroutine(Shake(origin));
            ring.ToExitColor();
            //Hit();
        }
        
    }
    private IEnumerator Shake(Quaternion origin)
    {
        float deltaTime = 0.0f;
        
        while (true)
        {
            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-1.0f, 1.0f);

            cam.transform.Rotate(new Vector3(x, y, z));
            deltaTime += Time.deltaTime;

            yield return null;
            if (deltaTime >= duration)
            {
                cam.transform.rotation = origin;
                yield break;
            }
        }
        
    }
    private void Hit()
    {
        float deltaTime = 0.0f;
        while (deltaTime < duration)
        {
            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            float z = Random.Range(-1.0f, 1.0f);

            cam.transform.Rotate(new Vector3(x, y, z));
            deltaTime += Time.deltaTime;

        }
    }
}
