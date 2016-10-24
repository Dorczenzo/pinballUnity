using UnityEngine;
using System.Collections;

public class FlipperPower : MonoBehaviour {

    KeyCode button;
    public enum Sides { left, right };
    public Sides flipperType;
    bool press;

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
	
        if (Input.GetKey(button))
        {
            press = true;
            StartCoroutine(ExecuteAfterTime(1));
        }

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("co");
            //Debug.Log(other.gameObject.tag);
            ////other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 1f);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(10, 10, 10);
            if (other.rigidbody && press == true)
            {
                other.rigidbody.AddForce(Vector3.forward * 1700);
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        press = false;
    }
}
