using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    [SerializeField] private Transform destinationPos;
    [SerializeField] private GameObject spawnPosCollection;
    [SerializeField] private GameObject virus;
    private List<Transform> spawnPos = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < spawnPosCollection.transform.childCount; i++)
        {
            spawnPos.Add(spawnPosCollection.transform.GetChild(i));
        }
        
        for(int i=0; i < spawnPos.Count; i++)
        {
            spawnPos[i].LookAt(destinationPos);
        }
        InvokeRepeating("CreateVirus", 1.0f, 1.0f);

    }
    private void CreateVirus()
    {
        int idx = Random.Range(0, spawnPos.Count);
        Vector3 createPos = spawnPos[idx].transform.position;
        GameObject obj = Instantiate(virus);
        obj.transform.position = createPos;
        float speed = Random.Range(1000.0f, 1500.0f);
        obj.GetComponent<Rigidbody>().AddForce(spawnPos[idx].transform.forward*speed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
