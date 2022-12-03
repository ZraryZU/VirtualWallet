using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using System.Text;
using Excel;
using UnityEditor;
//using Data;

public class ExcelTool : MonoBehaviour
{

    public class ExcelConfig
    {
        /// <summary>
        /// ���excel���ļ��еĵ�·��������xecel�������"Assets/Excels/"����
        /// </summary>
        public static readonly string excelsFolderPath = Application.dataPath + "/Excels/";

        /// <summary>
        /// ���Excelת��CS�ļ����ļ���·��
        /// </summary>
        public static readonly string assetPath = "Assets/Resources/";
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
        public static Item[] CreateItemArrayWithExcel(string filePath)
        {
            //��ñ�����
            int columnNum = 0, rowNum = 0;
            DataRowCollection collect = ReadExcel(filePath, ref columnNum, ref rowNum);
           
            //����excel�Ķ��壬�ڶ��п�ʼ��������
            Item[] array = new Item[rowNum - 1];
            for (int i = 1; i < rowNum; i++)
            {
                Item item = new Item();

                //����ÿ�е�����
                Debug.Log("good");
                Debug.Log("good");
                item.itemId = uint.Parse(collect[i][0].ToString());
                Debug.Log("good");
                item.itemName = collect[i][1].ToString();
                item.itemPrice = uint.Parse(collect[i][2].ToString());
                item.itemCount = uint.Parse(collect[i][3].ToString());
                item.minRate = float.Parse(collect[i][4].ToString());
                item.maxRate = float.Parse(collect[i][5].ToString());
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
     
        [MenuItem("CustomEditor/CreateItemAssset")]
        public static void CreateItemAsset()
        {
            ItemManager manager = ScriptableObject.CreateInstance<ItemManager>();
            //��ֵ
            manager.dataArray = Excel_Tool.CreateItemArrayWithExcel(ExcelConfig.excelsFolderPath + "stocks.xls");
            Debug.Log("good2");
            //ȷ���ļ��д���
            if (!Directory.Exists(ExcelConfig.assetPath))
            {
                Directory.CreateDirectory(ExcelConfig.assetPath);
            }

            //asset�ļ���·�� Ҫ��"Assets/..."��ʼ������CreateAsset�ᱨ��
            string assetPath = string.Format("{0}{1}.asset", ExcelConfig.assetPath, "StockItems");
            //����һ��Asset�ļ�
            AssetDatabase.CreateAsset(manager, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();


        }

    
    }

}