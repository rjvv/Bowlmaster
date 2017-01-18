﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Vector3 launchVelocity;
	private Rigidbody rigidBody;
	public bool inPlay = false;

	private Vector3 ballStartPos;

	private AudioSource audioSource;


	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();

		rigidBody.useGravity = false;

		ballStartPos = transform.position;


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

	public void Reset ()
	{
		Debug.Log ("Resetting Ball");
		inPlay = false;
		transform.position = ballStartPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}

	void Update ()
	{
		
	}
}
