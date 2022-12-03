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

    public static List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//���ڴ�ų������к�� �ļ����µ��ļ�����

    public static List<myStock> stocksItems = new List<myStock>();//���ڴ�ų������к�� �ļ����µ��ļ�����
                                                     // public GameObject Step_Panel;
                                                     // Start is called before the first frame update

    [MenuItem("CustomEditor/GetStocks")]
    public static void GetStocks()
    {
        string[] arrStrStocksPath = Directory.GetFiles(Application.dataPath + "/Stocks/", "*", SearchOption.AllDirectories);//using System.IO;
        FileInfo file;
        foreach (string strStockPath in arrStrStocksPath)
        {
            //�滻·���еķ�б��Ϊ��б��       
            string strTempPath = strStockPath.Replace(@"\", "/");
          //  Debug.Log(strStockPath);
            //��ȡ������Ҫ��·��
            strTempPath = strTempPath.Substring(strTempPath.IndexOf("Assets"));
           // Debug.Log(strTempPath);
            //����·��������Դ
            UnityEngine.Object objStock = AssetDatabase.LoadAssetAtPath(@strTempPath, typeof(UnityEngine.Object));//using UnityEditor;
            if(objStock != null)
            {
              //  Debug.Log("  objName: " + objStock.GetType() + "-------"+ strTempPath);//��� Ŀ���ļ� ����������
                objects.Add(objStock);
            }
            if (objStock != null&& objStock.GetType().ToString() == "myStock")//���ļ����µ��ļ�ΪItem�ű��������ļ���ʱ��
            {
                stocksItems.Add((myStock)objStock);//ǿ������ת�������� Item�����С�

                Type type = objStock.GetType();//��Ϊusing UnityEngine;��using System;����Object�Ķ��壬���ʹ��UnityEngine.Object����������
                FieldInfo[] fil = type.GetFields();

                foreach (FieldInfo var in fil)//���ܻ�ȡ��c�ֶΣ����c=2��
                {
                    Debug.Log("FieldInfo: " + var.Name + "=" + var.GetValue(objStock));
                    //Debug.Log("FieldInfo: " + var.Name + "=" + var.GetValue(father_));
                    if (var.Name == "name")//�ҵ� Item.asset�е� Int��������Ϊname�ı���
                    {
                        
                     //   Debug.Log("ItemName:   " + var.GetValue(objStock));//���Item���͵�.asset�ļ���name����
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
            //���أ�ʵ����Ԥ����
            GameObject BtnX = Instantiate(Resources.Load<GameObject>("stoke (1)"));
            //�Լ��س����İ�ť������
            BtnX.name = $"Btn_Step_{i}";
            //�԰�ť������ı������޸�
            //BtnX.GetComponentInChildren<Text>().text = i.ToString();
            BtnX.transform.Find("Name").GetComponent<Text>().text = stk.names;
            //�踸��ϵ���Զ����е�������
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