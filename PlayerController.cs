using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody PlayerRB;
    private GameObject focusPoint;
    public bool hasPower = false;
    private GameObject PlayerController1;
    private float ForceImpulse = 10f;
    public GameObject GoldRing;
    private Vector3 GoldRingPosition = new Vector3(0, -0.5f ,0);
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        focusPoint = GameObject.Find("Focal Point");
        PlayerController1 = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float movingVertical = Input.GetAxis("Vertical");
        PlayerRB.AddForce(focusPoint.transform.forward * movingVertical * speed);
        GoldRing.transform.position = transform.position + GoldRingPosition;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            hasPower = true;
            GoldRing.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }   
    }
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPower = false;
        GoldRing.gameObject.SetActive(false);
                       
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Enemy") && hasPower)
        {
            Rigidbody enemyRB = col.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyFlyAway = (PlayerController1.transform.position + transform.position).normalized;
            enemyRB.AddForce(enemyFlyAway * ForceImpulse, ForceMode.Impulse);
            Debug.Log("Player collied with " + col.gameObject);
        }
       
    }
}