using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System.IO;
using System;//Type
using System.Reflection;//FieldInfo

public class creatbuttons : MonoBehaviour
{
    public static List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//用于存放场景运行后的 文件夹下的文件物体

    public static List<myStock> stocksItems = new List<myStock>();//用于存放场景运行后的 文件夹下的文件物体
                                                                  // public GameObject Step_Panel;
                                                                  // Start is called before the first frame update
    void Start()
    {
        
        ////Step_Panel = GameObject.FindWithTag("stocks");
        //for (int i = 0; i < 13; i++)
        //{
        //    //加载，实例化预制体
        //    GameObject BtnX = Instantiate(stk);
        //    //对加载出来的按钮重命名
        //    BtnX.name = $"Btn_Step_{i}";
        //    //对按钮里面的文本进行修改
        // //   BtnX.GetComponentInChildren<Text>().text = i.ToString();
        //    //设父关系，自动排列到滑动栏
        //    BtnX.transform.SetParent(Step_Panel.transform);
        //    BtnX.transform.localScale = new Vector3(1, 1, 1);
        //}


    }

    // Update is called once per frame
    void Update()
    {

    }
}
