using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using System.Text;
using Excel;
using UnityEditor;
public class Creatprice : MonoBehaviour
{
    public class ExcelConfig
    {
        /// <summary>
        /// 存放excel表文件夹的的路径，本例xecel表放在了"Assets/Excels/"当中
        /// </summary>
        public static readonly string excelsFolderPath = Application.dataPath + "/Excels/PriceExcels/";

        /// <summary>
        /// 存放Excel转化CS文件的文件夹路径
        /// </summary>
        public static readonly string assetPath = "Assets/Resources/stocksPrice/";
    }

    public class Excel_Tool
    {
        static DataRowCollection ReadExcel(string filePath, ref int columnNum, ref int rowNum)
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            DataSet result = excelReader.AsDataSet();
            //Tables[0] 下标0表示excel文件中第一张表的数据
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }
        /// <summary>
        /// 读取表数据，生成对应的数组
        /// </summary>
        /// <param name="filePath">excel文件全路径</param>
        /// <returns>Item数组</returns>
        public static StockPrice[] CreateItemArrayWithExcel(string filePath)
        {
            //获得表数据
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

            //根据excel的定义，第二行开始才是数据
            StockPrice[] array = new StockPrice[rowNum - 1];
            for (int i = 1; i < rowNum; i++)
            {
                StockPrice item = new StockPrice();

                //解析每列的数据
                Debug.Log("good");
                Debug.Log("good");
                item.Stage = int.Parse(collect[i][0].ToString());
               
                item.Days = int.Parse(collect[i][1].ToString());
               
                item.EarningRate = float.Parse(collect[i][2].ToString());
                Debug.Log("good");
                Debug.Log(item.Stage);
                Debug.Log(item.Days);
                Debug.Log(item.EarningRate);
                array[i - 1] = item;
            }

            return array;
        }

        /// <summary>
        /// 读取excel文件内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="columnNum">行数</param>
        /// <param name="rowNum">列数</param>
        /// <returns></returns>

    }
    public class ExcelBuild : Editor
    {

        [MenuItem("CustomEditor/CreateStockPriceAssset")]
        public static void CreateStockPriceAsset()
        {
            string[] arrStrStocksPath = Directory.GetFiles(Application.dataPath + "/Excels/PriceExcels/", "*", SearchOption.AllDirectories);//using System.IO;
            FileInfo file;
            foreach (string strStockPath in arrStrStocksPath)
            {
                if(strStockPath.Substring(strStockPath.Length-3,3)=="xls")
                {
                    string strTempPath = strStockPath.Replace(@"\", "/");

                    strTempPath = strTempPath.Substring(strTempPath.IndexOf("PriceExcels/"));
                    //Debug.Log(strTempPath);
                    strTempPath = strTempPath.Substring(12);
                    //  Debug.Log(strTempPath);
                    // Debug.Log(strTempPath.Length);
                    //  Debug.Log(strTempPath.IndexOf("xls"));
                    strTempPath = strTempPath.Substring(0, strTempPath.Length - 4);
                  //  Debug.Log(strTempPath);
                    ////
                    ////
                    StockPriceManager manager = ScriptableObject.CreateInstance<StockPriceManager>();
                    //赋值
                    manager.PriceArray = Excel_Tool.CreateItemArrayWithExcel(strStockPath);
                   // Debug.Log("good2");
                    //确保文件夹存在
                    if (!Directory.Exists(ExcelConfig.assetPath))
                    {
                        Directory.CreateDirectory(ExcelConfig.assetPath);
                    }
                    //  Debug.Log(manager.PriceArray[1].Stage);
                    //   Debug.Log(manager.PriceArray[1].Days);
                    //  Debug.Log(manager.PriceArray[1].EarningRate);
                    //asset文件的路径 要以"Assets/..."开始，否则CreateAsset会报错
                    string assetPath = string.Format("{0}{1}.asset", ExcelConfig.assetPath, strTempPath);
                    //生成一个Asset文件
                    AssetDatabase.CreateAsset(manager, assetPath);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    ////
                    ////
                }


            }
         


        }


    }
}
