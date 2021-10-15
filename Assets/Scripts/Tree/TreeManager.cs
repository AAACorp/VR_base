using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Commponents = new GameObject[25];
    void Start()
    {
        Commponents[0] = GameObject.Find("Кираса");
        Commponents[1] = GameObject.Find("Бронежилет с шелковым напылитилем");
        Commponents[2] = GameObject.Find("Бронежилет с нейлоновым наполнителем");
        Commponents[3] = GameObject.Find("Композитный бронежилет");
        Commponents[4] = GameObject.Find("Бронежилет с кевларовым напылителем");
        Commponents[5] = GameObject.Find("Ручная граната");
        Commponents[6] = GameObject.Find("Ракетный двигатель");
        Commponents[7] = GameObject.Find("Ручной противотанковый гранатомёт");
        Commponents[8] = GameObject.Find("Спутниковая система навигации");
        Commponents[9] = GameObject.Find("Вызов БПЛА (удар с воздуха)");
        Commponents[10] = GameObject.Find("Радио");
        Commponents[11] = GameObject.Find("Радар I");
        Commponents[12] = GameObject.Find("Искусственный спутник");
        Commponents[13] = GameObject.Find("Передающая телевизионная цифровая камера");
        Commponents[14] = GameObject.Find("Камеры видеонаблюдений");
        Commponents[15] = GameObject.Find("Радар II");
        Commponents[16] = GameObject.Find("Самозарядный пистолет");
        Commponents[17] = GameObject.Find("Пистолет-пулемёт");
        Commponents[18] = GameObject.Find("Автомат(штурмовая винтовка)");
        Commponents[19] = GameObject.Find("Магазинная винтовка");
        Commponents[20] = GameObject.Find("Самозарядная винтовка");
        Commponents[21] = GameObject.Find("Крупнокалиберная снайперская винтовка");
        Commponents[22] = GameObject.Find("Помповое ружьё(дробовик)");
        Commponents[23] = GameObject.Find("Полуавтоматическое ружьё(дробовик)");
        Commponents[24] = GameObject.Find("Автоматическое ружьё(дробовик)");
        CheckAllComponnets();
    }
    public void CheckAllComponnets()
    {
        if (PlayerPrefs.GetInt("Кираса") == 1)
        {
            Commponents[0].GetComponent<TreeCommponent>().Status = 3;
            Commponents[1].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Бронежилет с шелковым напылитилем") == 1)
        {
            Commponents[1].GetComponent<TreeCommponent>().Status = 3;
            Commponents[2].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Бронежилет с нейлоновым наполнителем") == 1)
        {
            Commponents[2].GetComponent<TreeCommponent>().Status = 3;
            Commponents[3].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Композитный бронежилет") == 1)
        {
            Commponents[3].GetComponent<TreeCommponent>().Status = 3;
            Commponents[4].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Бронежилет с кевларовым напылителем") == 1)
        {
            Commponents[4].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Ручная граната") == 1)
        {
            Commponents[5].GetComponent<TreeCommponent>().Status = 3;
            Commponents[6].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Ракетный двигатель") == 1)
        {
            Commponents[6].GetComponent<TreeCommponent>().Status = 3;
            Commponents[7].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Ручной противотанковый гранатомёт") == 1)
        {
            Commponents[7].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Радио") == 1)
        {
            Commponents[10].GetComponent<TreeCommponent>().Status = 3;
            Commponents[11].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Радар I") == 1)
        {
            Commponents[11].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Ракетный двигатель") == 1 && PlayerPrefs.GetInt("Радар I") == 1)
        {
            Commponents[12].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Искусственный спутник") == 1)
        {
            Commponents[12].GetComponent<TreeCommponent>().Status = 3;
            Commponents[8].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Спутниковая система навигации") == 1)
        {
            Commponents[8].GetComponent<TreeCommponent>().Status = 3;
            Commponents[15].GetComponent<TreeCommponent>().Status = 1;
            Commponents[13].GetComponent<TreeCommponent>().Status = 1;
            Commponents[9].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Вызов БПЛА (удар с воздуха)") == 1)
        {
            Commponents[9].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Передающая телевизионная цифровая камера") == 1)
        {
            Commponents[13].GetComponent<TreeCommponent>().Status = 3;
            Commponents[14].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Камеры видеонаблюдений") == 1)
        {
            Commponents[14].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Радар II") == 1)
        {
            Commponents[15].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Самозарядный пистолет") == 1)
        {
            Commponents[16].GetComponent<TreeCommponent>().Status = 3;
            Commponents[17].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Пистолет-пулемёт") == 1)
        {
            Commponents[17].GetComponent<TreeCommponent>().Status = 3;
            Commponents[18].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Автомат(штурмовая винтовка)") == 1)
        {
            Commponents[18].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Магазинная винтовка") == 1)
        {
            Commponents[19].GetComponent<TreeCommponent>().Status = 3;
            Commponents[20].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Самозарядная винтовка") == 1)
        {
            Commponents[20].GetComponent<TreeCommponent>().Status = 3;
            Commponents[21].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Крупнокалиберная снайперская винтовка") == 1)
        {
            Commponents[21].GetComponent<TreeCommponent>().Status = 3;
        }
        if (PlayerPrefs.GetInt("Помповое ружьё(дробовик)") == 1)
        {
            Commponents[22].GetComponent<TreeCommponent>().Status = 3;
            Commponents[23].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Полуавтоматическое ружьё(дробовик)") == 1)
        {
            Commponents[23].GetComponent<TreeCommponent>().Status = 3;
            Commponents[24].GetComponent<TreeCommponent>().Status = 1;
        }
        if (PlayerPrefs.GetInt("Автоматическое ружьё(дробовик)") == 1)
        {
            Commponents[24].GetComponent<TreeCommponent>().Status = 3;
        }
        for (int i = 0; i < Commponents.Length; i++)
        {
            Commponents[i].GetComponent<TreeCommponent>().CheckStatus();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
