using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTime : MonoBehaviour
{
    public Timesyst TMsys;
    public myData data;
    public Text TimeText;
    public double HiddenAge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HiddenAge = data.MaxAge * 0.8;
        if (TMsys.age >= HiddenAge)
        {
            TimeText.text = TMsys.age.ToString() + "/" + data.MaxAge.ToString();
        }
        else
        {
            TimeText.text = TMsys.age.ToString() + "/??";
        }
    }
}
