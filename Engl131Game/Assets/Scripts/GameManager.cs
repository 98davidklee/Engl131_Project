using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

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
	* Post: Constructs the game with the questions text file and default values.
	*/
	private void Start() {
		number = 1;
		totalPoint = 0;
		questionNum.text = number + " / 20";
		scanner = File.OpenText("questions.txt");
		question.text = scanner.ReadLine();
		answers = File.OpenText("answers.txt");
	}

	/*
	* Pre: The game has at least one more question to ask, otherwise changes to next scene.
	* Post: Increments the total points if user guesses it correctly and prompts next question.
	*/
	public void TrueOrFalse(bool choice) {
		if (number == 20) {
			questionNum.text = "";
			question.text = "Your total score is: " + totalPoint;
		} else {
			if (Convert.ToBoolean(answers.ReadLine()) == choice) {
				totalPoint += 5;
			}
			string nextLine = scanner.ReadLine();
			number++;
			questionNum.text = number + " / 20";
			question.text = nextLine;
		}
	}
}
