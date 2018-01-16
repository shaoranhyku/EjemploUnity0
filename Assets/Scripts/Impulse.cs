using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {
    public float impulse = 10;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().AddForce(Vector3.up * impulse, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
	}
}
