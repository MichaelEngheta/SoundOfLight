using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

    public GameObject magicOrb;
    public float magicOrbSpeed;
    public bool thrown;
    public GameObject magicOrbPlaceholder;
    public bool isFacingRight;

	// Use this for initialization
	void Start () {
        magicOrb = GameObject.FindGameObjectWithTag("Orb");
        magicOrbPlaceholder = GameObject.FindGameObjectWithTag("OrbPlaceholder");
        magicOrbSpeed = 0.25f;
        thrown = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        isFacingRight = GetComponent<playerMovement>().isFacingRight;

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
        }
	}

    void ShootRight()
    {
        if (Input.GetKey(KeyCode.LeftShift) && thrown == false)
        {
            magicOrb.transform.position = new Vector3(magicOrb.transform.position.x + magicOrbSpeed,
                magicOrb.transform.position.y, magicOrb.transform.position.z);
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
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            thrown = !thrown;
        }
    }
}
