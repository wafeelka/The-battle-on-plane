using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 10.0f;
    private Rigidbody enemyRB;
    private GameObject playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
        Vector3 vectorEnemy = (playerController.transform.position - transform.position).normalized;
        enemyRB.AddForce(vectorEnemy* speed);
    }
    
}
