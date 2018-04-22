// GameManager prompts an user true of false questions and examines whether an user is a true fan of soccer.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	// the total point of an user.
	private int totalPoint; 
	// the text file that has questions.
	private StreamReader scanner;
	// the question to be displayed in the game.
	public Text question;
	// the answers to the questions.
	private StreamReader answers;
	// the question number that keeps track of the order of the questions.
	private int number;
	// The question number to be displayed in the game.
	public Text questionNum;

	/*
	* Post: Constructs the game with the questions and answers text files
	*/
	private void Start () 
	{
		number = 1;
		totalPoint = 0;
		questionNum.text = number + " / 20";
		scanner = File.OpenText ("questions.txt");
		question.text = scanner.ReadLine ();
		answers = File.OpenText ("answers.txt");
	}

	/*
	* Post: Increments the total points by 5 points if user guesses the question correctly and prompts next question to an user. If an user answered 
	*		all the questions, the game shows the result to an user. 
	*/
	public void TrueOrFalse (bool choice)
	{
		EventSystem.current.SetSelectedGameObject (null);
		if (number == 20) {
			GameObject.Find ("True Button").SetActive (false);
			GameObject.Find ("False Button").SetActive (false);
			questionNum.text = "";
			String myMessage;
			if (totalPoint >= 90) {
				myMessage = "You are undoubtedly a true fan of soccer!!";
			} else if (totalPoint >= 80) {
				myMessage = "You might be considered as a true fan of soccer!!";
			} else if (totalPoint >= 70) {
				myMessage = "You are not a true fan of soccer, but you can be!"; 
			} else if (totalPoint >= 60) {
				myMessage = "You are not a true fan of soccer :/"; 
			} else if (totalPoint >= 50) {
				myMessage = "You are merely interested in soccer.";
			} else {
				myMessage = "You are not interested in soccer, aren't you?";
			}
			question.text = "Your total score is: " + totalPoint + "\n\n" + myMessage;
		} else {
			if (Convert.ToBoolean (answers.ReadLine ()) == choice) {
				totalPoint += 5;
			}
			string nextLine = scanner.ReadLine ();
			number++;
			questionNum.text = number + " / 20";
			question.text = nextLine;
		}
	}
}
