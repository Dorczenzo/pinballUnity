using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Settings : MonoBehaviour {

    public KeyCode leftFlipperButton;
    public static KeyCode leftFlipper;
    public KeyCode rightFlipperButton;
    public static KeyCode rightFlipper;
    public KeyCode ballLoadButton;
    public static KeyCode ballLoad;
    public static bool flippersLocked = true;
    public float ballSpeed;
    public static bool ballOut;
    public static bool ballShoot;
    public static float ballPower;
    public static float gunRotation;
	public static int ballCount;

	public static int score;
	public static int totalScore;
	public static int combo;
	public static int comboCount;

	public GameObject ball;
    public GameObject startScreen;
    public GameObject endScreen;

	public Text gScore;
	public Text gTotalScore;
	public Text gCombo;
	public Text ballLabel;
    public Text finalScore;
	public Text fasterBallText;

    public bool starting = true;

    // Use this for initialization
    void Awake () {

		ball.GetComponent<Rigidbody> ().mass = 1.0f;

        leftFlipper = leftFlipperButton;
        rightFlipper = rightFlipperButton;
        ballLoad = ballLoadButton;
        ballShoot = false;
        ballPower = 1000;
        gunRotation = 0;
        ballCount = 3;

        score = 0;
		totalScore = 0;
		combo = 1;
		comboCount = 10;


        if (starting == true)
        {
            startScreen.SetActive(true);
        }





	}
	
	// Update is called once per frame
	void Update () {
	
		combo = comboCount / 10;
			
		gScore.GetComponent<Text> ().text = score.ToString();
		gTotalScore.GetComponent<Text> ().text = totalScore.ToString ();
		gCombo.GetComponent<Text> ().text = "x" + combo.ToString ();
		ballLabel.GetComponent<Text> ().text = ballCount.ToString ();

        if (ballCount == 0)
        {
            flippersLocked = true;
            endScreen.SetActive(true);
            finalScore.GetComponent<Text>().text = totalScore.ToString();

            if (Input.GetKeyDown("return"))
            {
                endScreen.SetActive(false);
                Application.LoadLevel(Application.loadedLevelName);
            }
        }

        if (starting == true && Input.GetKeyDown("return"))
        {
            startScreen.SetActive(false);
            starting = false;
            ballOut = true;
        }

		if (starting == true && Input.GetKeyDown(KeyCode.F))
		{
			ball.GetComponent<Rigidbody> ().mass = 0.5f;
			fasterBallText.GetComponent<Text> ().text = "Ok, it's done!";
		}
    }
}
