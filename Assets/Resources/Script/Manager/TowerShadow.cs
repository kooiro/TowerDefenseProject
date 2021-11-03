using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShadow : MonoBehaviour
{
    private static bool leagalArear;//位置是否正确
    private static bool isInstantiate;//是否已经实例化


    Color right;
    Color err;
    //Color colorInstantiate;
 

    public static bool LeagalArear { get => leagalArear; set => leagalArear = value; }
    public static bool IsInstantiate { get => isInstantiate; set => isInstantiate = value; }



    private void Awake()
    {
        right = new Color(0, 1, 0, 0.3f);//显示透明 绿色
        err = new Color(1, 0, 0, 0.3f);//显示透明 红色
        //colorInstantiate = new Color(1, 1, 1, 1);//白色 没有虚影子
    }
    private void Start()
    {
        //GetComponent<SkinnedMeshRenderer>().material.color = colorInstantiate;
    }   
    public void Shadow(bool leagalArear,bool isInstantiate)
    {
        if (!isInstantiate && leagalArear)//无实例化且位置正确
        {
            Debug.Log("颜色变化：绿色");
            GetComponent<SkinnedMeshRenderer>().material.color = right;
        }
        if (!leagalArear|| isInstantiate)//无实例化or位置错误
        {
            GetComponent<SkinnedMeshRenderer>().material.color = err;
        }
        //if (isInstantiate && leagalArear)//实例化且位置正确
        //{
        //    GetComponent<SkinnedMeshRenderer>().material.color = colorInstantiate;
        //}        
    }
    private void Update()
    {
        Shadow(leagalArear, isInstantiate);
    }
}
