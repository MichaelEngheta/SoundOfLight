using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : playerMovement {

    public GameObject magicOrb;
    public float magicOrbSpeed;
    public bool thrown;
    public GameObject magicOrbPlaceholder;
    public bool flying;

	// Use this for initialization
	void Start () {
        magicOrb = GameObject.FindGameObjectWithTag("Orb");
        magicOrbPlaceholder = GameObject.FindGameObjectWithTag("OrbPlaceholder");
        magicOrbSpeed = 0.25f;
        thrown = false;
        isFacingRight = true;
	}
	
	// Update is called once per frame
	void Update () {

        determineDirection();

        if (isFacingRight == true)
        {
            ShootRight();
        }else if(isFacingRight == false)
        {
            ShootLeft();
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && thrown == true )
        {
            magicOrb.transform.position = magicOrbPlaceholder.transform.position;
            flying = false;
        }
	}

    void ShootRight()
    {
        if (Input.GetKey(KeyCode.LeftShift) && thrown == false)
        {
            magicOrb.transform.position = new Vector3(magicOrb.transform.position.x + magicOrbSpeed,
                magicOrb.transform.position.y, magicOrb.transform.position.z);
            flying = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrown = !thrown;
        }
    }

    void ShootLeft()
    {
        if (Input.GetKey(KeyCode.LeftShift) && thrown == false)
        {
            magicOrb.transform.position = new Vector3(magicOrb.transform.position.x - magicOrbSpeed,
                magicOrb.transform.position.y, magicOrb.transform.position.z);
            flying = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrown = !thrown;
        }
    }
}
