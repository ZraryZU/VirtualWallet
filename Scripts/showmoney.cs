using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showmoney : MonoBehaviour
{
    //  public Canvas canvas;
    // public characterstat cha;
    // Start is called before the first frame update
    public myData data;
    public Text AllMoney,Invest,CurrtAccount,Debt;
    void Start()
    {
        AllMoney.text = data.currentMoney.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        AllMoney.text = data.currentMoney.ToString();
        Invest.text = data.Invest.ToString();
        CurrtAccount.text = data.CurrtAccount.ToString();
        Debt.text = data.Debt.ToString();
    }
}
