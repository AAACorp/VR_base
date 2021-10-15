using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SupremumStudio
{
    public class Answer : MonoBehaviour
    {
        public Quiz Quiz;
        public UiController UiController;
        private void Start()
        {
            UiController = GameObject.Find("Baza_Canvas").GetComponent<UiController>();
            Quiz = GameObject.Find("QuizManager").GetComponent<Quiz>();
            gameObject.GetComponent<Button>().onClick.AddListener(() => CheckQuestion());
        }
        public void CheckQuestion()
        {
            if (GetComponentInChildren<TextMeshProUGUI>().text == Quiz.currentAnswer) //TODO: переосмыслить
            {
                Quiz.NextQuestion();
            }
            else
            {
                Quiz.TimeForPlay = Quiz.TimeForWrongAnswer;
                Quiz.CanPlay = false;
                UiController.QuizWrongAnswerOn();
            }
        }
        // Start is called before the first frame update
        //private void OnTriggerExit(Collider other)
        //{
        //    if (GetComponentInChildren<TextMeshProUGUI>().text == Quiz.currentAnswer) //TODO: переосмыслить
        //    {
        //        //AnimationOff();
        //        print("Правильно");
        //        Quiz.NextQuestion();
        //    }
        //    else
        //    {
        //        print("Неправильно");
        //    }
        //}
    }
}
