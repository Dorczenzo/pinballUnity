using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

    KeyCode button;
    public enum Sides { left, right };
    public Sides flipperType;

    float downAngle;
    float upAngle;
    bool flipperWork = false;


    // Use this for initialization
    void Start () {

        Debug.Log(Physics.gravity);

        downAngle = this.transform.rotation.eulerAngles.y;

        if (flipperType == Sides.left)
        {
            upAngle = downAngle - (downAngle * 3);
            button = Settings.leftFlipper;
        }
        else if (flipperType == Sides.right)
        {
            upAngle = downAngle + (180 - downAngle * 3);
            button = Settings.rightFlipper;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(button))
        {
            Debug.Log("Flipper z przyciskiem " + button);

            var flipperState = transform.localRotation;
            var targetFlipperState = Quaternion.Euler(0, upAngle, 0);
            var smooth = Time.deltaTime * 20.0f;
            transform.localRotation = Quaternion.Slerp(flipperState, targetFlipperState, smooth);
            flipperWork = true;

        }
        else
        {
            //Debug.Log("Puszczone");
            var flipperState = transform.localRotation;
            var targetFlipperState = Quaternion.Euler(0, downAngle, 0);
            var smooth = Time.deltaTime * 20.0f;
            transform.localRotation = Quaternion.Slerp(flipperState, targetFlipperState, smooth);
            flipperWork = false;
        }

        

    }


}
