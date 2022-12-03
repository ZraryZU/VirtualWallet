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
        /// ���excel���ļ��еĵ�·��������xecel�������"Assets/Excels/"����
        /// </summary>
        public static readonly string excelsFolderPath = Application.dataPath + "/Excels/PriceExcels/";

        /// <summary>
        /// ���Excelת��CS�ļ����ļ���·��
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
            //Tables[0] �±�0��ʾexcel�ļ��е�һ�ű������
            columnNum = result.Tables[0].Columns.Count;
            rowNum = result.Tables[0].Rows.Count;
            return result.Tables[0].Rows;
        }
        /// <summary>
        /// ��ȡ�����ݣ����ɶ�Ӧ������
        /// </summary>
        /// <param name="filePath">excel�ļ�ȫ·��</param>
        /// <returns>Item����</returns>
        public static StockPrice[] CreateItemArrayWithExcel(string filePath)
        {
            //��ñ�����
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);

            //����excel�Ķ��壬�ڶ��п�ʼ��������
            StockPrice[] array = new StockPrice[rowNum - 1];
            for (int i = 1; i < rowNum; i++)
            {
                StockPrice item = new StockPrice();

                //����ÿ�е�����
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
        /// ��ȡexcel�ļ�����
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <param name="columnNum">����</param>
        /// <param name="rowNum">����</param>
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
                    //��ֵ
                    manager.PriceArray = Excel_Tool.CreateItemArrayWithExcel(strStockPath);
                   // Debug.Log("good2");
                    //ȷ���ļ��д���
                    if (!Directory.Exists(ExcelConfig.assetPath))
                    {
                        Directory.CreateDirectory(ExcelConfig.assetPath);
                    }
                    //  Debug.Log(manager.PriceArray[1].Stage);
                    //   Debug.Log(manager.PriceArray[1].Days);
                    //  Debug.Log(manager.PriceArray[1].EarningRate);
                    //asset�ļ���·�� Ҫ��"Assets/..."��ʼ������CreateAsset�ᱨ��
                    string assetPath = string.Format("{0}{1}.asset", ExcelConfig.assetPath, strTempPath);
                    //����һ��Asset�ļ�
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
