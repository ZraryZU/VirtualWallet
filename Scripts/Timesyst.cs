using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timesyst : MonoBehaviour
{
    public float timer = 0;
    public float Daydelay;
    public float Mondelay;
    public float Yerdelay;
    public int day;
    public int month;
    public int year;
    public int age;
    public int allDays;
    // Start is called before the first frame update
    void Start()
    {
        age = 25;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= Daydelay)
        {
            timer = 0;
            day++;
            allDays++;
        }
        if(day >= Mondelay)
        {
            day = 0;
            month++;
        }
        if(month >= Yerdelay)
        {
            month = 0;
            year++;
            age++;
        }

    }
}
