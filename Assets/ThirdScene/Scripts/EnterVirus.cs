using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVirus : MonoBehaviour
{
    [SerializeField] private EatVirus eatVirus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            eatVirus.AddEatableVirus(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
