using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SupremumStudio;
using TMPro;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator MainPanel;
    private Animator StorePanel;
    private Animator TreePanel;
    private Animator QuizPanel;
    private Animator DefencePanel;
    private Animator Non_MainEquipmentPanel;
    private Animator MainEquipmentPanel;
    private Animator QuizWithAnswersPanel;
    private Animator QuizWrongAnswer;
    private Animator TimeForPlayPanel;
    private Animator HaventResourcesForBuyItemPanel;
    public Quiz Quiz;
    private TextMeshProUGUI TextForTimeToPlay;
    private void Start()
    {
        HaventResourcesForBuyItemPanel = GameObject.Find("HaventResourcesForBuyItemPanel").GetComponent<Animator>();
        TextForTimeToPlay = GameObject.Find("TextForTimeToPlay").GetComponent<TextMeshProUGUI>();
        Quiz = GameObject.Find("QuizManager").GetComponent<Quiz>();
        TimeForPlayPanel = GameObject.Find("TimeForPlayPanel").GetComponent<Animator>();
        QuizWrongAnswer = GameObject.Find("QuizWrongAnswer").GetComponent<Animator>();
        MainPanel = GameObject.Find("MainPanel").GetComponent<Animator>();
        StorePanel = GameObject.Find("StorePanel").GetComponent<Animator>();
        TreePanel = GameObject.Find("TreePanel").GetComponent<Animator>();
        QuizPanel = GameObject.Find("QuizPanel").GetComponent<Animator>();
        DefencePanel = GameObject.Find("DefencePanel").GetComponent<Animator>();
        Non_MainEquipmentPanel = GameObject.Find("Non_MainEquipmentPanel").GetComponent<Animator>();
        MainEquipmentPanel = GameObject.Find("MainEquipmentPanel").GetComponent<Animator>();
        QuizWithAnswersPanel = GameObject.Find("QuizWithAnswersPanel").GetComponent<Animator>();
    }
    public void MainEquipmentPanelOn()
    {
        MainEquipmentPanel.SetTrigger("MainEquipmentPanelOn");
    }
    public void MainEquipmentPanelOff()
    {
        MainEquipmentPanel.SetTrigger("MainEquipmentPanelOff");
    }
    public void Non_MainEquipmentPanelOn()
    {
        Non_MainEquipmentPanel.SetTrigger("Non_MainEquipmentPanelOn");
    }
    public void Non_MainEquipmentPanelOff()
    {
        Non_MainEquipmentPanel.SetTrigger("Non_MainEquipmentPanelOff");
    }
    public void DefencePanelOn()
    {
        DefencePanel.SetTrigger("DefencePanelOn");
    }
    public void DefencePanelOff()
    {
        DefencePanel.SetTrigger("DefencePanelOff");
    }
    public void QuizPanelOn()
    {
        QuizPanel.SetTrigger("QuizPanelOn");
    }
    public void QuizPanelOff()
    {
        QuizPanel.SetTrigger("QuizPanelOff");
    }
    public void TreePanelOn()
    {
        TreePanel.SetTrigger("TreePanelOn");
    }
    public void TreePanelOff()
    {
        TreePanel.SetTrigger("TreePanelOff");
    }
    public void StorePanelOn()
    {
        StorePanel.SetTrigger("StorePanelOn");
    }
    public void StorePanelOff()
    {
        StorePanel.SetTrigger("StorePanelOff");
    }
    public void MainPanelOn()
    {
        MainPanel.SetTrigger("MainPanelOn");
    }
    public void MainPanelOff()
    {
        MainPanel.SetTrigger("MainPanelOff");
    }
    public void QuizWithAnswersPanelOn()
    {
        QuizWithAnswersPanel.SetTrigger("QuizWithAnswersPanelOn");
    }
    public void QuizWithAnswersPanelOff()
    {
        QuizWithAnswersPanel.SetTrigger("QuizWithAnswersPanelOff");
    }
    public void ToStore()
    {
        MainPanelOff();
        StorePanelOn();
    }
    public void FromStore()
    {
        MainPanelOn();
        StorePanelOff();
    }
    public void ToTree()
    {
        MainPanelOff();
        TreePanelOn();
    }
    public void FromTree()
    {
        MainPanelOn();
        TreePanelOff();
    }
    public void ToQuiz()
    {
        MainPanelOff();
        QuizPanelOn();
    }
    public void FromQuiz()
    {
        MainPanelOn();
        QuizPanelOff();
    }
    public void ToDefence()
    {
        TreePanelOff();
        DefencePanelOn();
    }
    public void FromDefence()
    {
        TreePanelOn();
        DefencePanelOff();
    }
    public void ToMainEquipmentPanel()
    {
        TreePanelOff();
        MainEquipmentPanelOn();
    }
    public void FromMainEquipmentPanel()
    {
        TreePanelOn();
        MainEquipmentPanelOff();
    }
    public void ToNon_MainEquipmentPanel()
    {
        TreePanelOff();
        Non_MainEquipmentPanelOn();
    }
    public void FromNon_MainEquipmentPanel()
    {
        TreePanelOn();
        Non_MainEquipmentPanelOff();
    }
    public void ToQuizWithAnswersPanel()
    {
        if (Quiz.CanPlay)
        {
            QuizWithAnswersPanelOn();
            QuizPanelOff();
        }
        else
        {
            TimeForPlayPanelOn();
        }
    }
    public void FromQuizWithAnswersPanel()
    {
        QuizWithAnswersPanelOff();
        QuizPanelOn();
    }
    public void QuizWrongAnswerOn()
    {
        QuizWrongAnswer.SetTrigger("QuizWrongAnswerOn");
    }
    public void QuizWrongAnswerOff()
    {
        QuizWrongAnswer.SetTrigger("QuizWrongAnswerOff");
    }
    public void TimeForPlayPanelOn()
    {
        TimeForPlayPanel.SetTrigger("TimeForPlayPanelOn");
    }
    public void TimeForPlayPanelOff()
    {
        TimeForPlayPanel.SetTrigger("TimeForPlayPanelOff");
    }
    public void HaventResourcesForBuyItemPanelOn()
    {
        HaventResourcesForBuyItemPanel.SetTrigger("HaventResourcesForBuyItemPanelOn");
    }
    public void HaventResourcesForBuyItemPanelOff()
    {
        HaventResourcesForBuyItemPanel.SetTrigger("HaventResourcesForBuyItemPanelOff");
    }
    private void Update()
    {        
        if (!Quiz.CanPlay)
        {
            TextForTimeToPlay.text = "До доступа к викторина осталось " + (int)Quiz.TimeForPlay + " секунд";
        }

    }
}
