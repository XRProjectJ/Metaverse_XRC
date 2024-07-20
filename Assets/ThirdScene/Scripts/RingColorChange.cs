using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingColorChange : MonoBehaviour
{
    [SerializeField] private Material entMaterial;
    [SerializeField] private Material extMaterial;
    [SerializeField] private GameObject ring;
    
    public void ToEnterColor()
    {
        ring.GetComponent<Renderer>().material = entMaterial;
    }
    public void ToExitColor()
    {
        ring.GetComponent<Renderer>().material = extMaterial;
    }
}
