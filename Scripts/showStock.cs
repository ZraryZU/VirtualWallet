using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showStock : MonoBehaviour
{
    public float timer = 0;
    public float delayTime;
    public myStock stok;
    public Text Name, Price, NumCnt,Rate;
    private float delta,pastPrice;
    public Timesyst Mytime;
    public int stageNum;
    public int dayNum;
    public int lastDay;
    public float deltaPrice;
    private float aimPrice;
    // Start is called before the first frame update

    public void Setstok(myStock st)
    {
        stok = st;
    }
    void Start()
    {
        lastDay = Mytime.day;
        aimPrice = stok.price *(1 + stok.SPM.PriceArray[stageNum].EarningRate);
        deltaPrice = (aimPrice - stok.price) / stok.SPM.PriceArray[stageNum].Days;
       // Debug.Log(aimPrice);
        //Debug.Log(deltaPrice);
    }

    // Update is called once per frame
    void Update()
    {//更新价格
        if(lastDay != Mytime.day)
        {
            lastDay = Mytime.day;
            dayNum++;
            pastPrice = stok.price;
            stok.price += deltaPrice+ Random.Range(-deltaPrice /*/ stok.SPM.PriceArray[stageNum].Days*/, deltaPrice /*/stok.SPM.PriceArray[stageNum].Days*/);
            if (dayNum >= stok.SPM.PriceArray[stageNum].Days)
            {
                stok.price = aimPrice;
                Debug.Log(stok.names + "---" + stok.price.ToString());
                stageNum++;
                dayNum = 0;
                if (stageNum >= stok.SPM.PriceArray.Length)
                {
                    stageNum = 0;  
                }
                aimPrice = stok.price * (1 + stok.SPM.PriceArray[stageNum].EarningRate);
                deltaPrice = (aimPrice - stok.price) / stok.SPM.PriceArray[stageNum].Days;

            }
            Debug.Log(stok.SPM.PriceArray.Length);
            
            stok.rate = (stok.price - pastPrice) / pastPrice;//计算增长率
        }
       
      
        Name.text = stok.names;
        Price.text = stok.price.ToString("f0");
        NumCnt.text = stok.count.ToString();
        Rate.text = (stok.rate * 100).ToString("f2");
    }
}
