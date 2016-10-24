using UnityEngine;
using System.Collections;

public class BallNew : MonoBehaviour
{

    Vector3 start;



    // Use this for initialization
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(Settings.gunRotation * 100, 0, Settings.ballPower);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < -15)
        {
			Settings.ballCount = Settings.ballCount - 1;
            Settings.ballPower = 1000;
            Settings.totalScore = Settings.totalScore + Settings.score;
            Settings.score = 0;
            Settings.comboCount = 10;

            if (Settings.ballCount > 0) {
				Settings.ballOut = true;
			} else {
                //dodać label Game Over, ciemne tło i press space to restart
				Debug.Log("Game Over");
			}

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "wood")
        {
			//Settings.score = Settings.score + (10*Settings.combo);
            GetComponent<AudioSource>().Play();

			//Settings.comboCount = Settings.comboCount + 1;
        }
        else if (other.gameObject.tag == "score")
        {
            Settings.score = Settings.score + (10 * Settings.combo);
            Settings.comboCount = Settings.comboCount + 1;
        }
        else if (other.gameObject.tag == "score2")
        {
            Settings.score = Settings.score + (20 * Settings.combo);
            Settings.comboCount = Settings.comboCount + 2;
        }
    }
}
