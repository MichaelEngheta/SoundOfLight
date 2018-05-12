using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbFollow : MonoBehaviour {

    public GameObject originalPlace;
    public playerShoot playerShoot;

	// Use this for initialization
	void Start () {
        originalPlace = GameObject.FindGameObjectWithTag("OrbPlaceholder");
        playerShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<playerShoot>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerShoot.flying == false)
        {
            transform.position = originalPlace.transform.position;
        }
	}
}
