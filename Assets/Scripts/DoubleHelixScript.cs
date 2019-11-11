using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleHelixScript : MonoBehaviour {

    public GameObject myPrefab;
    public int length = 10;
    public float radius = 0.5f;
    public float step = 0.1f;
    public int numberOfObjectsPerRevolution = 16;
    public Color[] nucleoticColor = new Color[4] {new Color(99/255f, 88/255f, 46/255f, 1),  new Color(26/255f, 60/255f, 43/255f, 1), new Color(24/255f, 76/255f, 97/255f, 1), new Color(97/255f, 17/255f, 36/255f, 1)};
    public bool activateColor = false;

    private class HelixPoint {
        public Vector3 pos;
        public Quaternion rot;
    }

    // Use this for initialization
    void Start () {
        createDoubleHelix(length);       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void createDoubleHelix(int length)
    {
        float b = 3/4f;
        createHelix(length, new Vector3(0, 0, 0), 1);
        createHelix(length, new Vector3(0, 0, b * radius), -1);
    }

    private void createHelix(int length, Vector3 center, int gyro) {
        GameObject go;

        for (int i = -length; i < length; i++) {
            HelixPoint point = getHelixPoint(i, radius * gyro);
            go = Instantiate(myPrefab, center + point.pos, point.rot) as GameObject;
            if (activateColor)
            {
                go.GetComponent<Renderer>().material.color = (Color)nucleoticColor[Random.Range(0, 4)];
            }
            go.transform.parent = transform;
        }
    }

    private HelixPoint getHelixPoint(int i, float _radius)
    {
        HelixPoint point = new HelixPoint();
        float angle = i * Mathf.PI * 2 / numberOfObjectsPerRevolution;
        float x = Mathf.Cos(angle) * _radius;
        float y = Mathf.Sin(angle) * _radius;
        float z = i * step;
        point.pos = transform.position + new Vector3(x, y, z);
        float angleDegrees = -angle * Mathf.Rad2Deg;
        point.rot = Quaternion.Euler(0, 0, angleDegrees);
        return point;
    }
}
