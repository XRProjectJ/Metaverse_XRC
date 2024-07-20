using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterVirus : MonoBehaviour
{
    [SerializeField] private EatVirus eatVirus;
    [SerializeField] private RingColorChange ring;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Virus"))
        {
            eatVirus.AddEatableVirus(other.gameObject);
            ring.ToEnterColor();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
