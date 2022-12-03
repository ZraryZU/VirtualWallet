using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sellstock : MonoBehaviour
{
    public myData data;
    public Text money;
    public bool isSell;
    // Start is called before the first frame update
    void Start()
    {
        isSell = true;
    }
    public void sell()
    {
        if(data.Invest >= (int)float.Parse(money.text))
        {
            data.Invest -= (int)float.Parse(money.text);
            data.CurrtAccount += (int)float.Parse(money.text);
            isSell = true;
        }
        else
        {
            isSell = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
