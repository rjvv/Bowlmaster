using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour
{

	public Text standingDisplay;
	public int lastStandingCount = -1;

	public GameObject pinSet;

	private Ball ball;
	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private ActionMaster actionMaster = new ActionMaster ();
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
		
	}

	// Update is called once per frame
	void Update ()
	{
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
		}

	}


	void CheckStanding ()
	{
		//update the lastStandingCount
		//call new method called PinsHaveSettled
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; //How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) { //if last change > 3s ago
			PinsHaveSettled ();
		}
			
	}

	void PinsHaveSettled ()
	{

		int standing = CountStanding ();
		
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log ("Pinfall:" + pinFall + "___Action:" + action);


		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Dont KNOW HOW TO HANDLE END GAME YET!");
		}


		ball.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding ()
	{
		int standing = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}
		return standing;
	}

	public void RaisePins ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins ()
	{

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower ();
		}

	}

	public void RenewPins ()
	{

		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, 0, 0);
	}



	void OnTriggerEnter (Collider collider)
	{
		GameObject thingHit = collider.gameObject;
		//Ball enters playbox
		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}

	}
}
