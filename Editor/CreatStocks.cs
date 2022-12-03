using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using System.Text;
using Excel;
using UnityEditor;


public class CreatStocks : MonoBehaviour
{
    //public itemmanager itemmanager;

    [MenuItem("CustomEditor/CreateStocksAssset")]
    public static void creatstockassets()
    {
        string[] arrStrStocksPath = Directory.GetFiles(Application.dataPath + "/Resources/stocksPrice/", "*", SearchOption.AllDirectories);//using System.IO;
        ItemManager itemmanager = Resources.Load<ItemManager>("StockItems");
        string assetPath;
        for (int i = 0; i < itemmanager.dataArray.Length; i++)
        {
            myStock stock = ScriptableObject.CreateInstance<myStock>();
            //set names
            stock.names = itemmanager.dataArray[i].itemName;
            //set ID
            stock.ID = itemmanager.dataArray[i].itemId;
            //set price
            stock.price = itemmanager.dataArray[i].itemPrice;
            //set num
            stock.count = itemmanager.dataArray[i].itemCount;
            //set minrate
            stock.MinRate = itemmanager.dataArray[i].minRate;
            //set maxrate
            stock.MaxRate = itemmanager.dataArray[i].maxRate;
            //set Stock Price Manager
            foreach (string strStockPath in arrStrStocksPath)
            {
                string strTempPath = strStockPath.Replace(@"\", "/");
                strTempPath = strTempPath.Substring(strTempPath.IndexOf("Assets"));
                UnityEngine.Object objStock = AssetDatabase.LoadAssetAtPath(@strTempPath, typeof(UnityEngine.Object));//using UnityEditor;
                if (objStock != null && objStock.GetType().ToString() == "StockPriceManager")//当文件夹下的文件为StockPriceManager脚本创建的文件的时候
                {
                    strTempPath = strTempPath.Substring(strTempPath.IndexOf("stocksPrice/"));
                    strTempPath = strTempPath.Substring(12);
                    strTempPath = strTempPath.Substring(0, strTempPath.Length - 6);
                    Debug.Log(strTempPath);
                    if(strTempPath==stock.names)
                    {
                        stock.SPM = (StockPriceManager)objStock;
                    }
                }
            }

                assetPath = string.Format("{0}{1}.asset", "Assets/Stocks/", stock.names);//set file names
            AssetDatabase.CreateAsset(stock, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
