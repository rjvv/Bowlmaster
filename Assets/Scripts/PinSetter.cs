using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour
{

	public Text standingDisplay;
	public int lastStandingCount = -1;

	private Ball ball;
	private bool ballEnteredBox = false;
	private float lastChangeTime;



	// Use this for initialization
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
		
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


	void OnTriggerExit (Collider other)
	{

		if (other.attachedRigidbody.GetComponent<Pin> ()) {
			Destroy (other.attachedRigidbody.gameObject);
		}

		//if (other.transform.parent.tag == "Pin") {
		//	Destroy (other.transform.parent.gameObject);
		//}

		
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
