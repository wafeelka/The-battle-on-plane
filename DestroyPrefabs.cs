using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
    private Vector3 DestroyObstracle = new Vector3(0, -5, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObstracleMethod();
    }
    void DestroyObstracleMethod()
    {
        if(transform.position.y < DestroyObstracle.y)
        {
            Destroy(gameObject);

        }
    }
}
