using UnityEngine;
using System.Collections;

public class GunDown : MonoBehaviour {

    KeyCode button;
    float maxPos;
    float minPos;
    public AudioSource shoot;
    public GameObject ball;
	public GameObject fence;
    Material material;
    Rigidbody ballBody;
    float gunLocalRotation;
	int rotationDirection = 1;
	bool zeroRotation = true;

    // Use this for initialization
    void Start () {
        button = Settings.ballLoad;
        maxPos = this.transform.position.z;
        minPos = this.transform.position.z - 1.5f;
        material = this.gameObject.GetComponent<Renderer>().material;

    }
	
	// Update is called once per frame
	void Update () {

        gunLocalRotation = this.transform.eulerAngles.y;
		gunLocalRotation = (gunLocalRotation > 180) ? gunLocalRotation - 360 : gunLocalRotation;

		if (Settings.ballOut == true && fence.transform.eulerAngles.y <= 90)
        {

            //make gun fully visible again
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            material.SetInt("_ZWrite", 1);
            material.DisableKeyword("_ALPHATEST_ON");
            material.DisableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = -1;
            //end



            if (Input.GetKeyDown(button) && (this.transform.position.z == maxPos))
            {
                GetComponent<AudioSource>().Play();
            }

            if (Input.GetKey(button))
            {
				if (this.transform.position.z > minPos) {
					this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
					Settings.ballPower = Settings.ballPower + 12;
				}
                //Debug.Log("Siła: " + Settings.ballPower);



				//Debug.Log (gunLocalRotation);

				//rotation_start
				if (gunLocalRotation > 5) {
					rotationDirection = -1;
				} else if (gunLocalRotation < -5) {
					rotationDirection = 1;
				}
					

				gunLocalRotation = gunLocalRotation + (0.2f * rotationDirection);

				//rotation_end
            }
            else if (Input.GetKeyUp(button) && this.transform.position.z < maxPos)
            {
                //Settings.ballShoot = true;

                if (gunLocalRotation > 8)
                {
                    Settings.gunRotation = -(360 - gunLocalRotation);
                }
                else
                {
                    Settings.gunRotation = gunLocalRotation;
                }

                //Debug.Log(Settings.gunRotation);

                Instantiate(ball, this.transform.GetChild(0).position, this.transform.GetChild(0).rotation);
                Settings.ballOut = false;

                //Other soultions
                //
                //var ball = Instantiate(ballBody, this.transform.position, this.transform.rotation) as Rigidbody;
                //ball.GetComponent<Rigidbody>().AddForce(0, 0, Settings.ballPower);
                //GameObject temporaryBall = Instantiate(ball, this.transform.position, this.transform.rotation) as GameObject;
                //temporaryBall.GetComponent<Rigidbody>().useGravity = true;
                //ball.GetComponent<Rigidbody>().AddForce(0, 0, Settings.ballPower);
                //ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * 3000);
                //ball.GetComponent<Rigidbody>().AddForce(0, 0, 80, ForceMode.Impulse);
                //
                //end

                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, maxPos);
                shoot.Play();

                StartCoroutine(Visible(0.5f));

            }

			//Debug.Log ("test");
			this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, gunLocalRotation, this.transform.eulerAngles.z);
        }
			
			
	}

    IEnumerator Visible(float time)
    {
        yield return new WaitForSeconds(time);

        //make gun transparent
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000;
        //end

		gunLocalRotation = 0;
		rotationDirection = 1;
		this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, gunLocalRotation, this.transform.eulerAngles.z);
    }
}
