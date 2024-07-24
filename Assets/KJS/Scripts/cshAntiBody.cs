using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAntiBody : MonoBehaviour
{

    private List<GameObject> antibodies;
    public string SpeareTag;
    public string AntibodyTag;

    // Start is called before the first frame update
    void Start()
    {
        antibodies = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.tag == AntibodyTag)
            {
                antibodies.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("attacked");
        if (collision.gameObject.tag == "Virus_A")
        {
            
            List<GameObject> inactiveAntibodies = antibodies.FindAll(antibody => !antibody.activeSelf);
            for (int i = 0; i < 2 && inactiveAntibodies.Count > 0; i++)
            {
                int randomIndex = Random.Range(0, inactiveAntibodies.Count);
                inactiveAntibodies[randomIndex].SetActive(true);
                inactiveAntibodies.RemoveAt(randomIndex);
            }

            //Destroy(gameObject);
        }
    }
}
