﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour
{

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	private Ball ball;

	void Start ()
	{
		ball = GetComponent<Ball> ();
	}

	public void DragStart ()
	{
		if (!ball.inPlay) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd ()
	{
		if (!ball.inPlay) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0f, launchSpeedZ);
			ball.Launch (launchVelocity);
		}
	}

	public void MoveStart (float amount)
	{
		if (!ball.inPlay) {
			float xPos = Mathf.Clamp (ball.transform.position.x + amount, -50f, 50f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = (new Vector3 (xPos, yPos, zPos));
		}

	}

}
