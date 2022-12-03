using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowBuying : MonoBehaviour
{

    public myStock stok;
    public Text Name, Price, NumCnt,price,allNum,DoingCunt;
    private float midnum;
    // Start is called before the first frame update
    void Start()
    {
        //Name.text = stok.names;
        //Price.text = stok.price.ToString();
        //price.text = stok.price.ToString();
        //NumCnt.text = stok.count.ToString();
    }
    public void SetStock(myStock stk)
    {
      
        stok=stk;
    }
    // Update is called once per frame
    void Update()
    {
        Name.text = stok.names;
        Price.text = stok.price.ToString();
        price.text = stok.price.ToString();
        NumCnt.text = stok.count.ToString();
        midnum = (float)(int.Parse(DoingCunt.text));
        allNum.text = (midnum * stok.price).ToString(); //System.Int32.Parse(DoingCunt.text
 
         
    }
}
