using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GiveABonus : MonoBehaviour
{
    public Timesyst Mytime;
    private GameObject GOJ;//����ҳ��
    private GameObject mn;//��ҳ����
    private GameObject iv;//Ͷ�ʰ���
    bool doornot;

    private GameObject sts;//��Ʊҳ��
    // Start is called before the first frame update
    void Start()
    {
        doornot = false;
        GOJ = GameObject.Find("Game").transform.Find("Rouglike").gameObject;
        GOJ.gameObject.SetActive(false);
        mn = GameObject.Find("MainpageButtun");
        iv = GameObject.Find("InvestButton");
        sts = GameObject.Find("investpage").transform.Find("InvestPage/Scroll View/Viewport/stocks").gameObject;
        
    }
    private void Unenable()
    {
        mn.GetComponent<Button>().enabled = false;
        foreach(Transform child in sts.transform)
        {
            child.GetComponent<Button>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Mytime.day != 0)
        {
            doornot = false;
        }
            if (Mytime.day == 0 && doornot == false)
        {
            GOJ.gameObject.SetActive(true);
            Unenable();
            doornot = true;
            Debug.Log("falseButton");
           // iv.GetComponent<Button>().enabled=false;
        }
    }
}
