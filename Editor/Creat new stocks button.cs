using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Data;
using System.IO;
using System;//Type
using System.Reflection;//FieldInfo

using UnityEngine.Events;
using UnityEditor.Events;

public class Creatnewstocksbutton : MonoBehaviour
{

    public static List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//用于存放场景运行后的 文件夹下的文件物体

    public static List<myStock> stocksItems = new List<myStock>();//用于存放场景运行后的 文件夹下的文件物体
                                                     // public GameObject Step_Panel;
                                                     // Start is called before the first frame update

    [MenuItem("CustomEditor/GetStocks")]
    public static void GetStocks()
    {
        string[] arrStrStocksPath = Directory.GetFiles(Application.dataPath + "/Stocks/", "*", SearchOption.AllDirectories);//using System.IO;
        FileInfo file;
        foreach (string strStockPath in arrStrStocksPath)
        {
            //替换路径中的反斜杠为正斜杠       
            string strTempPath = strStockPath.Replace(@"\", "/");
          //  Debug.Log(strStockPath);
            //截取我们需要的路径
            strTempPath = strTempPath.Substring(strTempPath.IndexOf("Assets"));
           // Debug.Log(strTempPath);
            //根据路径加载资源
            UnityEngine.Object objStock = AssetDatabase.LoadAssetAtPath(@strTempPath, typeof(UnityEngine.Object));//using UnityEditor;
            if(objStock != null)
            {
              //  Debug.Log("  objName: " + objStock.GetType() + "-------"+ strTempPath);//获得 目标文件 的物体类型
                objects.Add(objStock);
            }
            if (objStock != null&& objStock.GetType().ToString() == "myStock")//当文件夹下的文件为Item脚本创建的文件的时候
            {
                stocksItems.Add((myStock)objStock);//强制类型转换，放入 Item数组中。

                Type type = objStock.GetType();//因为using UnityEngine;和using System;都有Object的定义，因此使用UnityEngine.Object来进行区分
                FieldInfo[] fil = type.GetFields();

                foreach (FieldInfo var in fil)//仅能获取到c字段（输出c=2）
                {
                    Debug.Log("FieldInfo: " + var.Name + "=" + var.GetValue(objStock));
                    //Debug.Log("FieldInfo: " + var.Name + "=" + var.GetValue(father_));
                    if (var.Name == "name")//找到 Item.asset中的 Int类型名字为name的变量
                    {
                        
                     //   Debug.Log("ItemName:   " + var.GetValue(objStock));//获得Item类型的.asset文件的name变量
                    }
                }
            }
        }
        foreach (myStock stk in stocksItems)
        {
            Debug.Log("------- ------  "  + stk.name);
        }
    }
    
    [MenuItem("CustomEditor/CreateButtonsAssset")]
    public static void CreatButtonsAsset()
    {
       // GetStocks();
       GameObject Step_Panel = GameObject.Find("investpage").transform.Find("InvestPage/Scroll View/Viewport/stocks").gameObject;
    
        int i = -1;
        foreach (myStock stk in stocksItems)
        {
            i++;
            //加载，实例化预制体
            GameObject BtnX = Instantiate(Resources.Load<GameObject>("stoke (1)"));
            //对加载出来的按钮重命名
            BtnX.name = $"Btn_Step_{i}";
            //对按钮里面的文本进行修改
            //BtnX.GetComponentInChildren<Text>().text = i.ToString();
            BtnX.transform.Find("Name").GetComponent<Text>().text = stk.names;
            //设父关系，自动排列到滑动栏
            BtnX.transform.SetParent(Step_Panel.transform);
            BtnX.transform.localScale = new Vector3(1, 1, 1);
            BtnX.GetComponent<showStock>().stok = stk;
            BtnX.GetComponent<showStock>().Mytime = GameObject.Find("EventSystem").GetComponent<Timesyst>();
            GameObject Bos = GameObject.Find("Game").transform.Find("BuyOrSell").gameObject;
            GameObject Man = GameObject.Find("mainpage").transform.Find("Mainpage").gameObject;
            GameObject Ins = GameObject.Find("investpage").transform.Find("InvestPage").gameObject;

           // ShowBuying sby=
            UnityEventTools.AddBoolPersistentListener(BtnX.GetComponent<Button>().onClick, Bos.gameObject.SetActive, true);
            UnityEventTools.AddBoolPersistentListener(BtnX.GetComponent<Button>().onClick, Man.gameObject.SetActive, false);
            UnityEventTools.AddBoolPersistentListener(BtnX.GetComponent<Button>().onClick, Ins.gameObject.SetActive, false);
            UnityEventTools.AddObjectPersistentListener(BtnX.GetComponent<Button>().onClick, Bos.GetComponent<ShowBuying>().SetStock, stk);

            //BtnX.GetComponent<Button>().onClick.AddListener
            //    (
            //    () =>
            //    {
            //        GameObject bos = GameObject.Find("BuyOrSell");
            //        bos.SetActive(true);
            //        Click();
            //    }
            //    );
        }
    }

    static void Click()
    {
        Debug.Log("good****** **************");
    }
    // Update is called once per frame
    void Update()
    {

    }
}