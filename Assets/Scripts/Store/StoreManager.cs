using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    Animator myAnimator;
    public int Count = 1;
    private int ChildCount = 0;
    private string on = "on";
    private string off = "off";
    private Animator Error;
    public Image StoreItem;
    public Image StoreItemPrev;
    public Image StoreItemNext;
    public Sprite[] Items = new Sprite[5];
    UiController UiController;

    // Start is called before the first frame update
    void Start()
    {
        UiController = GameObject.Find("Baza_Canvas").GetComponent<UiController>();
        StoreItem = GameObject.Find("StoreItem").GetComponent<Image>();
        StoreItemPrev = GameObject.Find("StoreItemPrev").GetComponent<Image>();
        StoreItemNext = GameObject.Find("StoreItemNext").GetComponent<Image>();
        //Error = GameObject.Find("Error").GetComponent<Animator>();
        myAnimator = gameObject.GetComponent<Animator>();
        ChildCount = gameObject.transform.childCount;
    }
    public void ChangeNext()
    {
        if (Count > 0)
        {
            myAnimator.SetTrigger(Count.ToString() + off);
        }
        if (Count < ChildCount)
        {
            Count++;
        }
        else if (Count == ChildCount)
        {
            Count = 1;
        }
        StartCoroutine(On());
    }
    public void ChangeItem_Next()
    {
        if (Count < Items.Length - 1)
        {
            Count++;
        }
        else if (Count == Items.Length - 1)
        {
            Count = 0;
        }
        ChangeImage();
    }
    public void ChangeItem_Prev()
    {
        if (Count < Items.Length && Count > 0)
        {
            Count--;
        }
        else if (Count == 0)
        {
            Count = Items.Length - 1;
        }
        ChangeImage();
    }
    public void ChangeImage()
    {
        if ((Count - 1) < 0)
        {
            StoreItemPrev.sprite = Items[Items.Length - 1];
        }
        else
        {
            StoreItemPrev.sprite = Items[Count - 1];
        }
        StoreItem.sprite = Items[Count];
        if ((Count + 1) == Items.Length)
        {
            StoreItemNext.sprite = Items[0];
        }
        else
        {
            StoreItemNext.sprite = Items[Count + 1];
        }
    }
    public void Buy()
    {
        switch (Count)
        {
            case 0:
                //UiController.HaventResourcesForBuyItemPanelOn();      // Если не хватает ресурсов
                Debug.Log("Вы купили Армор, проверяйте");
                //Армор
                break;
            case 1:
                //Граната
                Debug.Log("Вы купили Гранату, проверяйте");
                break;
            case 2:
                //Патроны 1
                Debug.Log("Вы купили Патроны 1, проверяйте");
                break;
            case 3:
                //МедАптечка
                Debug.Log("Вы купили МедАптечку, проверяйте");
                break;
            case 4:
                //Ракета
                Debug.Log("Вы купили Ракету, проверяйте");
                break;
            case 5:
                //Патроны 2
                Debug.Log("Вы купили Патроны 2, проверяйте");
                break;
            case 6:
                //Патроны 3
                Debug.Log("Вы купили Патроны 3, проверяйте");
                break;

        }

    }
    public void ErrorOn()
    {
        Error.SetTrigger("on");
    }
    IEnumerator On()
    {
        yield return new WaitForSeconds(0.6f);
        myAnimator.SetTrigger(Count.ToString() + on);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            ChangeNext();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            Buy();
            ErrorOn();
        }
    }
}
