using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class confirmDeal : MonoBehaviour
{
    public GameObject confpage;//BuySellSucssFail
    public GameObject BSpage;
    public Text Event;
    public Text Status;
    public buystock buy;
    public sellstock sell;
    // Start is called before the first frame update
    void Start()
    {
        confpage = GameObject.Find("BuySellSucssFail").transform.Find("Canvas").gameObject;
        BSpage = GameObject.Find("Game").transform.Find("BuyOrSell/Canvas").gameObject;
        confpage.gameObject.SetActive(false);
     //   Event= Text(GameObject.Find("Game").transform.Find("BuySellSucssFail/Canvas/Event").gameObject);
       // Status= Text(GameObject.Find("Game").transform.Find("BuySellSucssFail/Canvas/Status").gameObject);
    }

    public void showbuyPage()
    {

        Event.text = "����";
        if(buy.isBuy == true)
        {
            Status.text = "�ɹ�";
        }
        else
        {
            Status.text = "ʧ��";
        }
        confpage.gameObject.SetActive(true);
        BSpage.gameObject.SetActive(false);
    }

    public void showsellPage()
    {

        Event.text = "����";
        if (sell.isSell == true)
        {
            Status.text = "�ɹ�";
        }
        else
        {
            Status.text = "ʧ��";
        }
        confpage.gameObject.SetActive(true);
        BSpage.gameObject.SetActive(false);
    }



    public void confirm()
    {
        confpage.gameObject.SetActive(false);
        BSpage.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
