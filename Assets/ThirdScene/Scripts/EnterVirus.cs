using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVirus : MonoBehaviour
{
    [SerializeField] private EatVirus eatVirus;
    [SerializeField] private Material entMaterial;
    [SerializeField] private GameObject ring;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            eatVirus.AddEatableVirus(other.gameObject);
            ring.GetComponent<Renderer>().material = entMaterial;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
