﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public Text[] rollTexts, frameTexts;
	

	// Use this for initialization
	void Start ()
	{
		rollTexts [0].text = "X";
		frameTexts [0].text = "0";
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void FillRollCard (List<int>rolls)
	{
		rolls [-1] = 1;
	}
}
