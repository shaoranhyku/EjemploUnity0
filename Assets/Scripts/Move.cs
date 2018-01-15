using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    
    public float forceValue;
    public float jumpValue;
    public GameObject prefab;
    private Rigidbody rb;
    private AudioSource audiosource;
    private GameObject capsules;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        capsules = GameObject.Find("Capsules");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
            audiosource.Play();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * forceValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            print("Colisión con cubo");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Capsule"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color *= 2f;
            collision.gameObject.GetComponent<AudioSource>().Play();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Capsule"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color /= 2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (Transform child in capsules.GetComponentInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("Capsule"))
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
                child.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        Instantiate(prefab, new Vector3(Random.Range(-15f, 15f), 4f, Random.Range(-15f, 15f)), Quaternion.identity);
    }

}
