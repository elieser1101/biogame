using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoticScript : MonoBehaviour {

    public Color color;
    public Vector3 velocity;
    [Range(0, 1)]
    public float aceleration = 1/10f;
    public float velocityMagnitudeMax = 10f;
    public bool bound = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (transform.position.x > 10f || transform.position.x < -10f)
        {
            velocity *= -1;
        }
        transform.position += velocity * Time.fixedDeltaTime;
        if (!bound)
        {
            if (velocity.magnitude < velocityMagnitudeMax)
            {
                velocity += velocity.normalized * aceleration * Time.fixedDeltaTime;
            }
            float angle = 100 * velocity.magnitude * Time.fixedDeltaTime;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.one);
        }
    }
}
