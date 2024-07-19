using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAntiBody : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Virus_A")
        {
            Transform antibody = collision.gameObject.transform.Find("antibody");
            if (antibody != null)
            {
                antibody.gameObject.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}
