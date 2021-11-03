using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    //��
    public GameObject[] tower;
    private string[] towerName = { "Tower_Crossbow", "Tower_Mortar" };
    //�޶���λ��
    private Transform pos1;
    private Transform pos2;
    //����Ӱ��
    private GameObject[] towerShadow;
    private GameObject[] towerShadowInstant;
    private string[] towerShadowName = { "Tower_Crossbow_shadow", "Tower_Mortar_shadow" };
    //��������
    private int index=0; 
    void Start()
    {
        
        pos1 = transform.Find("Pos1");
        pos2 = transform.Find("Pos2");
        //��Resources�ļ����µ���Ӱ��������
        towerShadow = new GameObject[towerShadowName.Length];
        for (int i = 0; i < towerShadow.Length; i++)
        {
            towerShadow[i]= Resources.Load<GameObject>("Prefabs/Tower/" + towerShadowName[i]);
        }
        towerShadowInstant = new GameObject[towerShadow.Length];
        //������Ӱ����Ĭ�ϲ��ɼ�
        for (int i = 0; i < towerShadowInstant.Length; i++)
        {
            towerShadowInstant[i] = Instantiate(towerShadow[i]);
            towerShadowInstant[i].SetActive(false);
        }
        //��Resources�ļ����µ�����������
        tower = new GameObject[towerName.Length];
        for (int i = 0; i < tower.Length; i++)
        {
            tower[i] = Resources.Load<GameObject>("Prefabs/Tower/" + towerName[i]);
        }

    }
    //��������
    Ray ray;
    RaycastHit hit;
    public LayerMask layerMask;
    void Update()
    {             
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
         {
            //��ʾ��Ӱ
            towerShadowInstant[index].SetActive(true);           
            towerShadowInstant[index].transform.position = new Vector3(hit.point.x, 0f, hit.point.z);//������Ӱ��transform.position.y Ϊ0    
            if (IsBuild(hit.point)&&hit.transform.tag != "Tower")//��Χ������λ��û����
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
            if (!IsBuild(hit.point) || hit.transform.tag == "Tower")//��Χ�������λ������
            {
                //Debug.Log("err");
                TowerShadow.LeagalArear = false;
            }
        }
    }
    /// <summary>
    /// �ж�λ���Ƿ��ڹ涨�Ľ��췶Χ��
    /// </summary>
    /// <param name="point">λ��</param>
    /// <returns>�Ƿ��������췶Χ��</returns>
    protected bool IsBuild(Vector3 point)
    {
        if (hit.point.x >= pos1.position.x && hit.point.x <= pos2.position.x && hit.point.z >= pos2.position.z && hit.point.z <= pos1.position.z)
            return true;
        else
            return false;
    }
    
}
