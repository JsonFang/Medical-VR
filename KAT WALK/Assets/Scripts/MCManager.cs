﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCManager : MonoBehaviour {
    public Button continueButton;
    public List<Button> MCButtons;
    public Text questionText;
    public Text status;

    private Text buttonText;
    private string[] questions = new string[3] {"1. What is 1+1?", "2. What is 9*8?", "3. What is 12^2?"};
    private string[,] choices = new string[3,4] {{"1","2","3","4"}, {"no","yes","72","0"}, {"144","idk","infinity","undefined"}};
    private int[] answers = new int[3] {1, 2, 0};
    private int questionNumber = 0;

    private void Awake() {
        //continueButton.GetComponent<Renderer>().enabled = false;
        continueButton.enabled = false;
        buttonText = continueButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        nextQuestion();
    }

    public void rightAnswer() {
        status.text = "Correct!";
        buttonText.text = "Next Question";
        //continueButton.GetComponent<Renderer>().enabled = true;
        continueButton.enabled = true;
        disableMCButtons();
    }

    public void wrongAnswer() {
        status.text = "Incorrect!";
        buttonText.text = "Next Question";
        //continueButton.GetComponent<Renderer>().enabled = true;
        continueButton.enabled = true;
        disableMCButtons();
    }

    private void disableMCButtons() {
        foreach (Button b in MCButtons) {
            b.enabled = false;
        }
    }

    public void enableMCButtons() {
        foreach (Button b in MCButtons) {
            b.enabled = true;
        }
    }

    public void nextQuestion() {
        if (questionNumber > questions.Length) {
            return;
        }
        // Assign question
        questionText.text = questions[questionNumber];
        // Assign choices
        for (int i=0; i<3; i++) {
            MCButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = choices[questionNumber, i];
            // Assign which choices are correct/wrong
            MCButtons[i].GetComponent<ButtonTransitioner>().isCorrect = (i==answers[questionNumber]);
        }
        questionNumber++;
    }
}
