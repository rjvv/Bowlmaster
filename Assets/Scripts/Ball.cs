using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Vector3 launchVelocity;
	private Rigidbody rigidBody;
	public bool inPlay = false;

	private AudioSource audioSource;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();

		rigidBody.useGravity = false;

		//Launch (launchVelocity);

	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();

	}


	void Update ()
	{
		
	}
}
