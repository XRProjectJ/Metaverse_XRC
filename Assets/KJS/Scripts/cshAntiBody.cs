using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshAntiBody : MonoBehaviour
{
    private List<GameObject> antibodies;
    public string SpeareTag;
    public string AntibodyTag;
    public int HPAntibody;
    private cshVirusMove virusMove;
    private float OriginSpeed;

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

        virusMove = GetComponent<cshVirusMove>();
        OriginSpeed = virusMove.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // active된 antibody의 수에 따라 속도를 조절
        int activeAntibodies = antibodies.FindAll(antibody => antibody.activeSelf).Count;
        virusMove.speed = (OriginSpeed / (activeAntibodies + 1)) + 0.01f;


        if (activeAntibodies >= HPAntibody)
        {
            virusMove.speed = 0;
            Destroy(gameObject, 3f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == SpeareTag)
        {
            List<GameObject> inactiveAntibodies = antibodies.FindAll(antibody => !antibody.activeSelf);
            for (int i = 0; i < 2 && inactiveAntibodies.Count > 0; i++)
            {
                int randomIndex = Random.Range(0, inactiveAntibodies.Count);
                inactiveAntibodies[randomIndex].SetActive(true);
                inactiveAntibodies.RemoveAt(randomIndex);
            }
        }
    }
}
