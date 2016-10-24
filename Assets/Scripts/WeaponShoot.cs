using UnityEngine;
using System.Collections;

public class WeaponShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEvent(Collision other)
    {
        Debug.Log("Piła");

        if (other.gameObject.tag == "ball")
        {
            Debug.Log("Piła");
        }
    }
}
