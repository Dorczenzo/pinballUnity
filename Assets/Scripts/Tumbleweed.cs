using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbleweed : MonoBehaviour {

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {


        this.transform.Rotate(100 * Time.deltaTime, 0, 0);
        this.transform.position = new Vector3(this.transform.position.x + 4 * Time.deltaTime, this.transform.position.y, this.transform.position.z + 4 * Time.deltaTime);

        if (this.transform.position.x > 30)
        {
            this.transform.position = startPos;
        }
    }
}
