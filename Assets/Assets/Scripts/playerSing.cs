using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSing : playerMovement {

    public Light orb;
    public Rigidbody2D rb2d;

    public int maxLightRadius;
    public int minLightRadius;
    public float lightRangeIncrementor;
    public float lightRangeDecrementor;


	// Use this for initialization
	void Start () {
        orb = GameObject.FindGameObjectWithTag("Orb").GetComponent<Light>();
        maxLightRadius = 5;
        minLightRadius = 3;
        lightRangeDecrementor = .10f;
        lightRangeIncrementor = .10f;
        rb2d = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {

        //if Lyte is not moving and 
        //the player presses Z, the light range is increased
        //until it reaches the peak
        if (Input.GetKey(KeyCode.Z) && rb2d.velocity.x == 0 && rb2d.velocity.y == 0)
        {
            if (orb.range <= maxLightRadius)
                orb.range += lightRangeIncrementor;
        }
        else if(orb.range >= minLightRadius)
        {
            orb.range -= lightRangeDecrementor;
        }

    }
}
