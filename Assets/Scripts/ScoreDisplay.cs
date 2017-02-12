using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	public Text[] rollTexts, frameTexts;



	public void FillRolls (List<int>rolls)
	{
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		}
	}

	public void FillFrames (List<int> frames)
	{
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	public static string FormatRolls (List<int> rolls)
	{
		string output = "";
		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1; //Score box 1-21

			if (rolls [i] == 0) {
				output += "-";//always enter 0 as dash
			} else if ((box % 2 == 0 || box == 21) && rolls [i - 1] + rolls [i] == 10) {//SPARE anywhere
				output += "/"; 

			} else if (box >= 19 && rolls [i] == 10) { //Strike in frame 10
				output += "X";
			} else if (rolls [i] == 10) {//STRIKE in frames 1-9
				output += "X ";
			} else {

				output += rolls [i].ToString (); //Normal 1-9 bowl
			}
		}
		return output;
	}
}
