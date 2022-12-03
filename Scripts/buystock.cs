using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buystock : MonoBehaviour
{

    public myData data;
    public Text money;
    public bool isBuy;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public  void buy()
    {
        if(data.CurrtAccount >= (int)float.Parse(money.text))
        {
            data.Invest += (int)float.Parse(money.text);
            data.CurrtAccount -= (int)float.Parse(money.text);
            isBuy = true;
        }
        else
        {
            isBuy = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
