using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter()
	{
		//this.gameObject.SetActive (false);
		this.gameObject.GetComponent<Collider>().enabled = false;
		this.gameObject.GetComponent<Renderer> ().enabled = false;
	}
}
