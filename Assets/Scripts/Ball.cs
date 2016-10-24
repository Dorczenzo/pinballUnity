using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    Vector3 start;

	// Use this for initialization
	void Start () {

        start = this.transform.position;
        Settings.ballOut = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * 1700);

        //Physics.gravity = new Vector3 (0, -4.21f, -9.8f);
        //Physics.gravity = new Vector3(0, 0, -4.8f);

    }
	
	// Update is called once per frame
	void Update () {
	
        if (this.transform.position.z < -20)
        {
            Settings.ballOut = true;
            Settings.ballPower = 1000;
            this.transform.position = start;
            Destroy(this.gameObject);
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * 2500);
        }

        if (Settings.ballOut == true)
        {
            this.transform.position = start;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        if (Settings.ballShoot == true)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * Settings.ballPower);
            GetComponent<Rigidbody>().AddForce(0, 0, Settings.ballPower);
            Settings.ballOut = false;
            Settings.ballShoot = false;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "wood")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
