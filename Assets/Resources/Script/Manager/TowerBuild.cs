using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    //塔
    public GameObject[] tower;
    private string[] towerName = { "Tower_Crossbow", "Tower_Mortar" };
    //限定的位置
    private Transform pos1;
    private Transform pos2;
    //塔的影子
    private GameObject[] towerShadow;
    private GameObject[] towerShadowInstant;
    private string[] towerShadowName = { "Tower_Crossbow_shadow", "Tower_Mortar_shadow" };
    //数组索引
    private int index=0; 
    void Start()
    {
        
        pos1 = transform.Find("Pos1");
        pos2 = transform.Find("Pos2");
        //将Resources文件夹下的阴影存入数组
        towerShadow = new GameObject[towerShadowName.Length];
        for (int i = 0; i < towerShadow.Length; i++)
        {
            towerShadow[i]= Resources.Load<GameObject>("Prefabs/Tower/" + towerShadowName[i]);
        }
        towerShadowInstant = new GameObject[towerShadow.Length];
        //创建阴影设置默认不可见
        for (int i = 0; i < towerShadowInstant.Length; i++)
        {
            towerShadowInstant[i] = Instantiate(towerShadow[i]);
            towerShadowInstant[i].SetActive(false);
        }
        //将Resources文件夹下的塔存入数组
        tower = new GameObject[towerName.Length];
        for (int i = 0; i < tower.Length; i++)
        {
            tower[i] = Resources.Load<GameObject>("Prefabs/Tower/" + towerName[i]);
        }

    }
    //创建射线
    Ray ray;
    RaycastHit hit;
    public LayerMask layerMask;
    void Update()
    {             
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
         {
            //显示阴影
            towerShadowInstant[index].SetActive(true);           
            towerShadowInstant[index].transform.position = new Vector3(hit.point.x, 0f, hit.point.z);//锁定阴影的transform.position.y 为0    
            if (IsBuild(hit.point)&&hit.transform.tag != "Tower")//范围允许且位置没有塔
            {
                //Debug.Log("right");
                TowerShadow.LeagalArear = true;
                TowerShadow.IsInstantiate = false;
                    
                if (Input.GetMouseButtonDown(0))
                {                       
                  TowerShadow.LeagalArear = true;
                  TowerShadow.IsInstantiate = true;
                  Instantiate(tower[index], hit.point, Quaternion.identity);
                 }
            }
            if (!IsBuild(hit.point) || hit.transform.tag == "Tower")//范围不允许或位置有塔
            {
                //Debug.Log("err");
                TowerShadow.LeagalArear = false;
            }
        }
    }
    /// <summary>
    /// 判断位置是否在规定的建造范围内
    /// </summary>
    /// <param name="point">位置</param>
    /// <returns>是否在允许建造范围内</returns>
    protected bool IsBuild(Vector3 point)
    {
        if (hit.point.x >= pos1.position.x && hit.point.x <= pos2.position.x && hit.point.z >= pos2.position.z && hit.point.z <= pos1.position.z)
            return true;
        else
            return false;
    }
    
}
