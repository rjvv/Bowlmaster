using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour
{

	public Text standingDisplay;

	private bool ballEnteredBox = false;
	
	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		standingDisplay.text = CountStanding ().ToString ();
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
