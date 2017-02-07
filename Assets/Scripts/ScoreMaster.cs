using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
	//returns a list of cumulative scores, like a normal scorecard
	public static List<int> ScoreCumulative (List<int>rolls)
	{
		List<int> cumulativeScores = new List<int> ();

		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}


	//returns a list of indiv frame scores. NOT cumulative
	public static List<int> ScoreFrames (List<int>rolls)
	{
		List<int> frames = new List<int> ();


		//Index i points to second bowl of frame
		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {
				break;//prevents eleventh frame score
			}
			if (rolls [i - 1] + rolls [i] < 10) {	//Normal "open" frame - sum is less than 10	
				frames.Add (rolls [i - 1] + rolls [i]);
			}
			if (rolls.Count - i <= 1) {   //Insufficient look-ahead
				break;
			}
			if (rolls [i - 1] == 10) {	//STRIKE
				i--; //STRIKE frame has just one bowl
				frames.Add (10 + rolls [i + 1] + rolls [i + 2]);
			} else if (rolls [i - 1] + rolls [i] == 10) {	//calculate spare bonus	
				frames.Add (10 + rolls [i + 1]);
			}
		}



		return frames;
	}






}
