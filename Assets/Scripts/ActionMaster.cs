using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

	public enum Action
	{
		Tidy,
		Reset,
		EndTurn,
		EndGame}

	;

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction (List<int> pinFalls)
	{
		ActionMaster am = new ActionMaster ();
		Action currentAction = new Action ();

		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl (pinFall);
		}
		return currentAction;
	}
	//TODO: make Bowl private
	public Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Not sure what action to return!");
		}

		if (bowl == 21) {
			return Action.EndGame;
		}

		bowls [bowl - 1] = pins;

		//special case
		if (bowl >= 19 && pins == 10) {
			bowl++;
			return Action.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (bowls [19 - 1] == 10 && bowls [20 - 1] == 0) {
				return Action.Tidy;
			}
			if (TwoStrikesLastFrame ()) {
				return Action.Reset;
			} else if (Bowl21Awarded ()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}

		if (bowl % 2 != 0) { //first bowl of frame 
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			} else {
				bowl += 1;
				return Action.Tidy;
			}

		} else if (bowl % 2 == 0) { //second bowl of frame
			bowl += 1;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return!");
	}

	private bool TwoStrikesLastFrame ()
	{
		return ((bowls [19 - 1] + bowls [20 - 1]) == 10);
	}

	private bool Bowl21Awarded ()
	{
		//Remember that arrays start counting at 0
		return (bowls [19 - 1] + bowls [20 - 1] >= 10);
	}
}
