using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;
    private bool isInFloor = false;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("space") && isInFloor)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 2500, 0));
        } 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0 , Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("Suelo"))
        {
            isInFloor = true;
        }
        
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("Suelo"))
        {
            isInFloor = false;
        }
    }
}
