using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Settings.ballOut == true) {
			StartCoroutine (WaitOpen (1f));
		} else if (Settings.ballOut == false){
			StartCoroutine (WaitClose(1f));
		}
	}

	void Close () {
		if (this.transform.eulerAngles.y < 120) {
			this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, this.transform.eulerAngles.y + 1, this.transform.eulerAngles.z);
		}
	}

	void Open () {
		if (this.transform.eulerAngles.y > 90) {
			this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, this.transform.eulerAngles.y - 1, this.transform.eulerAngles.z);
		}
	}

	IEnumerator WaitClose (float time){
		yield return new WaitForSeconds (time);
		Close ();
	}

	IEnumerator WaitOpen (float time){
		yield return new WaitForSeconds (time);
		Open ();
	}
}
