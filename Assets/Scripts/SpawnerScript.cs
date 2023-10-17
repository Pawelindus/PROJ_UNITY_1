using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField] private GameObject spike;
    [SerializeField] private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform;
            StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawn()
    {
        float rDouble = float.Parse((new Random().NextDouble() * 2 + 2).ToString());
        yield return new WaitForSeconds(rDouble);

        var dropPos = new Vector3(pos.position.x, pos.position.y - 0.1f, pos.position.z);
        
        Instantiate(spike, dropPos, Quaternion.identity);
        
           yield return StartCoroutine(Spawn());
       
    }
}
