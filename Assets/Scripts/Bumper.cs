using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    public float force;
    public float radius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter()
    {
        foreach(Collider col in Physics.OverlapSphere(transform.position, radius))
        {
            if(col.GetComponent<Rigidbody>())
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);	
                GetComponent<AudioSource>().Play();
                //transform.localScale = new Vector3(Mathf.PingPong(Time.time, 2), transform.position.y, transform.position.z);
            }
        }
    }
}
