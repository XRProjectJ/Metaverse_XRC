using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitVirus : MonoBehaviour
{
    [SerializeField] private EatVirus eatVirus;
    [SerializeField] private RingColorChange ring;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            eatVirus.RemoveEatableVirus(other.gameObject);
            ring.ToExitColor();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
