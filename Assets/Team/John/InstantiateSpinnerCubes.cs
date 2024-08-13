using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpinnerCubes : MonoBehaviour
{
    public GameObject objectToSpawn;
    public List<GameObject> SpinnerCubesActive;
    public float spawnTimer;
    public AudioPeer audioPeer;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSpinners());
    }

    IEnumerator SpawnSpinners()
    {
        while (true)
        {
            GameObject newInstanceOfObjectToSpawn = Instantiate(objectToSpawn, transform.position, objectToSpawn.transform.rotation);
            SpinnerCubesActive.Add(newInstanceOfObjectToSpawn);
            
            SpectrumDataConsumer consumer = newInstanceOfObjectToSpawn.GetComponentInChildren<SpectrumDataConsumer>();
            if (consumer != null)
            {
                consumer.audioPeer = audioPeer;
                consumer.StartCoroutine("TransformChangesCoroutine");
            }
            
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
