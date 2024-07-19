using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVirus : MonoBehaviour
{
    [SerializeField] private EatVirus eatVirus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            eatVirus.RemoveEatableVirus(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
