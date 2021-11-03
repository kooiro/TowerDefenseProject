using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShadow : MonoBehaviour
{
    private static bool leagalArear;//λ���Ƿ���ȷ
    private static bool isInstantiate;//�Ƿ��Ѿ�ʵ����


    Color right;
    Color err;
    //Color colorInstantiate;
 

    public static bool LeagalArear { get => leagalArear; set => leagalArear = value; }
    public static bool IsInstantiate { get => isInstantiate; set => isInstantiate = value; }



    private void Awake()
    {
        right = new Color(0, 1, 0, 0.3f);//��ʾ͸�� ��ɫ
        err = new Color(1, 0, 0, 0.3f);//��ʾ͸�� ��ɫ
        //colorInstantiate = new Color(1, 1, 1, 1);//��ɫ û����Ӱ��
    }
    private void Start()
    {
        //GetComponent<SkinnedMeshRenderer>().material.color = colorInstantiate;
    }   
    public void Shadow(bool leagalArear,bool isInstantiate)
    {
        if (!isInstantiate && leagalArear)//��ʵ������λ����ȷ
        {
            Debug.Log("��ɫ�仯����ɫ");
            GetComponent<SkinnedMeshRenderer>().material.color = right;
        }
        if (!leagalArear|| isInstantiate)//��ʵ����orλ�ô���
        {
            GetComponent<SkinnedMeshRenderer>().material.color = err;
        }
        //if (isInstantiate && leagalArear)//ʵ������λ����ȷ
        //{
        //    GetComponent<SkinnedMeshRenderer>().material.color = colorInstantiate;
        //}        
    }
    private void Update()
    {
        Shadow(leagalArear, isInstantiate);
    }
}
