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
    public static List<UnityEngine.Object> objects = new List<UnityEngine.Object>();//���ڴ�ų������к�� �ļ����µ��ļ�����

    public static List<myStock> stocksItems = new List<myStock>();//���ڴ�ų������к�� �ļ����µ��ļ�����
                                                                  // public GameObject Step_Panel;
                                                                  // Start is called before the first frame update
    void Start()
    {
        
        ////Step_Panel = GameObject.FindWithTag("stocks");
        //for (int i = 0; i < 13; i++)
        //{
        //    //���أ�ʵ����Ԥ����
        //    GameObject BtnX = Instantiate(stk);
        //    //�Լ��س����İ�ť������
        //    BtnX.name = $"Btn_Step_{i}";
        //    //�԰�ť������ı������޸�
        // //   BtnX.GetComponentInChildren<Text>().text = i.ToString();
        //    //�踸��ϵ���Զ����е�������
        //    BtnX.transform.SetParent(Step_Panel.transform);
        //    BtnX.transform.localScale = new Vector3(1, 1, 1);
        //}


    }

    // Update is called once per frame
    void Update()
    {

    }
}
