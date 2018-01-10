using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    //Variable pública para tener una referencia al jugador
    public GameObject player;
    //Variable para almacenar la distancia entre la cámara y el jugador
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
