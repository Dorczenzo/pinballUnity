using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

    public float force;
    public Vector3 forceDirection = Vector3.forward;
    KeyCode button;
    public enum Sides { left, right };
    public Sides flipperType;

    // Use this for initialization
    void Start () {
        if (flipperType == Sides.left)
        {
            button = Settings.leftFlipper;
        }
        else if (flipperType == Sides.right)
        {
            button = Settings.rightFlipper;
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(button))
        {
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(button))
        {
			GetComponent<Rigidbody> ().AddForceAtPosition (forceDirection.normalized * force, transform.position);
        }
        else
        {
			GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * -force, transform.position);
        }

	}
}
