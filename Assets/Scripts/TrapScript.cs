using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {

    GameObject ball;
    bool trapped = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trapped)
        {
            ball.transform.position = this.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //Debug.Log("trap");
        }
	}

    void OnCollisionEnter(Collision other)
    {
        ball = other.gameObject;
        trapped = true;
        StartCoroutine(trapWait(3));
        
    }

    IEnumerator trapWait(int time)
    {
        //Debug.Log("jest");
        yield return new WaitForSeconds(time);
        trapped = false;
        ball.GetComponent<Rigidbody>().AddForce(Random.Range(0, 1000), 0, Settings.ballPower);
    }
}
