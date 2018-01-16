using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : MonoBehaviour {
    public GameObject prefab;
    public float fireRate = 0.2f;

	// Use this for initialization
	void Start () {
        StartCoroutine(ThrowObject());
	}

    private IEnumerator ThrowObject()
    {
        yield return new WaitForSeconds(fireRate);

        while (true)
        {
            GameObject objeto = Instantiate(prefab, transform.position, UnityEngine.Random.rotation);
            objeto.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value));
            objeto.GetComponent<Transform>().localScale = new Vector3(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 3));

            yield return new WaitForSeconds(fireRate);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
