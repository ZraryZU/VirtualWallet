using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimePrizes : MonoBehaviour
{
    public myData data;
    private GameObject stock;
    //public ExcelTool tool;
    private GameObject mn;//主页按键
    private GameObject iv;//投资按键
    private GameObject sts;//股票页面

    public void AddMoney(Text moneyText)
    {
        data.CurrtAccount += int.Parse(moneyText.text);
        shutdown();


    }

    public void AddStock(Text StockName)
    {
        stock = GameObject.Find("Btn_Step_2");
        stock.GetComponent<showStock>().stok.price *=2.0f;
        stock.GetComponent<showStock>().stok.names = "SSR-Games_1";
        Debug.Log("---------nnn");
        shutdown();
    }

    public void AddRate(Text Rate)
    {

        stock = GameObject.Find("Btn_Step_0");
        stock.GetComponent<showStock>().stok.price *= (1 + float.Parse(Rate.text));
        shutdown();
        //   stock.price *= (1 + float.Parse(Rate.text));
        //float timer = 0;
        //while(timer <= 5)
        //{
        //    timer += Time.deltaTime;
        //    Debug.Log(Time.deltaTime.ToString());
        //}
        //    Debug.Log("Timeout"+timer.ToString());
    }
    private void ENable()
    {
        mn.GetComponent<Button>().enabled = true;
        foreach (Transform child in sts.transform)
        {
            child.GetComponent<Button>().enabled = true;
        }
    }
    public void shutdown()
    {
        GameObject gmoj;
        gmoj = GameObject.Find("Rouglike");
        gmoj.gameObject.SetActive(false);
        ENable();
      //  iv.GetComponent<Button>().enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        mn = GameObject.Find("MainpageButtun");
        iv = GameObject.Find("InvestButton");
        sts = GameObject.Find("investpage").transform.Find("InvestPage/Scroll View/Viewport/stocks").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
