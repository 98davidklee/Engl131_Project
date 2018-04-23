// GameManager prompts an user true of false questiond and examines whether an user is a true fan of soccer.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	// The total points of an user.
	private int totalPoint; 
	// The question to ask.
	public TextAsset question;
	// The answers to the question.
	public TextAsset answers;
	// The question number that keeps track of the order of the questions.
	private int number;
	// The question number displayed in the game.
	public Text questionNum;
	// The question displayed in the game.
	public Text questionText;
	// The list that keeps track of questions to ask.
	private string[] questionList;
	// The list that keeps track of answers to the questions.
	private bool[] answerList;

	/*
	* Post: Constructs the GameManager with questions and answers.
	*/
	private void Start () 
	{
		number = 0;
		totalPoint = 0;
		questionNum.text = number + 1 + " / 20";
		questionList = question.text.Split ('\n');
		string[] temp = answers.text.Split ('\n');
		answerList = new bool[temp.Length];
		for (int i = 0; i < temp.Length; i++) {
			answerList [i] = Convert.ToBoolean(temp [i]);
		}
	}

	/*
	* Post: Increments the total points by 5 points if user guesses the question correctly and then prompts next question to an user. 
	*		If an user answered all the question, the game shows an result to an user. 
	*/
	public void TrueOrFalse (bool choice)
	{
		EventSystem.current.SetSelectedGameObject (null);
		if (number == 19) {
			if (answerList[number] == choice) {
				totalPoint += 5;
			}
			GameObject.Find ("True Button").SetActive (false);
			GameObject.Find ("False Button").SetActive (false);
			questionNum.text = "\nResult:";
			questionText.text = "Your total score is: " + totalPoint + "\n\n" + gameMessage();
		} else {
			if (answerList[number] == choice) {
				totalPoint += 5;
			}
			number++;
			questionNum.text = number + 1 + " / 20";
			questionText.text = questionList [number];
		}
	}

	/*
	* Post: Returns string game message based on user's total points.
	*/
	private string gameMessage () 
	{
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
		return myMessage;
	}
}
