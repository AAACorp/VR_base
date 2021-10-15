using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeCommponent : MonoBehaviour
{
    // Start is called before the first frame update
    public int Status = 2;
    public TreeManager TreeManager;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => LearnAbility());
        TreeManager = GameObject.Find("Baza_Canvas").GetComponent<TreeManager>();

        if (gameObject.transform.name == "Кираса" || gameObject.transform.name == "Ручная граната" || gameObject.transform.name == "Радио" || gameObject.transform.name == "Самозарядный пистолет" || gameObject.transform.name == "Магазинная винтовка" || gameObject.transform.name == "Помповое ружьё(дробовик)")
        {
            if (PlayerPrefs.GetInt(gameObject.GetComponentInChildren<TextMeshProUGUI>().text) != 1)
            {
                Status = 1;
            }
            else if (PlayerPrefs.GetInt(gameObject.GetComponentInChildren<TextMeshProUGUI>().text) == 1)
            {
                Status = 3;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt(gameObject.GetComponentInChildren<TextMeshProUGUI>().text) == 1)
            {
                Status = 3;
            }
            else
            {
                Status = 2;
            }
        }
        CheckStatus();
    }
    public void LearnAbility()
    {
        Status = 3;
        PlayerPrefs.SetInt(gameObject.GetComponentInChildren<TextMeshProUGUI>().text, 1);
        CheckStatus();
        TreeManager.CheckAllComponnets();
    }
    public void CheckStatus()
    {
        switch (Status)
        {
            case 1:
                gameObject.GetComponent<Button>().interactable = true;
                gameObject.GetComponent<Image>().color = Color.white;
                break;
            case 2:
                gameObject.GetComponent<Button>().interactable = false;
                gameObject.GetComponent<Image>().color = Color.red;
                break;
            case 3:
                gameObject.GetComponent<Button>().interactable = false;
                gameObject.GetComponent<Image>().color = Color.green;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
