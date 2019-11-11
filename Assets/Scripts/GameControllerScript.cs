using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public float speed = 2.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Change for drag
        float h = speed * Input.GetAxis("Mouse X");
        transform.Rotate(0, 0, h);
        if (Input.GetMouseButtonDown(0)) // Click
        {
            // rollOut
        }
        else
        {
            // rollUp
        }
    }
}
