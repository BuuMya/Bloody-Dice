using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public bool upflag;
    public int wallcount = 0;
    public int stagenum = 0;
    public float speed = 0.1f;
    public GameObject normalEnemy;
    public GameObject Item;

    public enum eventType
    { 
        enemy,
        item,
        eventnum
    }
    public eventType m_eve;
    public void SetStageNum(int num)
    {
        stagenum = num;
    }
    public void SetUpFlag(bool flag)
    {
        upflag = flag;
    }
    // Start is called before the first frame update
    void Start()
    {
        int floornum = int.Parse(gameObject.name);
        int rand = Random.Range(1, floornum + 1);
        int layernum = (floornum / 100) + 1;
        int enemypower = (floornum - rand * 2) * layernum;

        Vector3 pos = transform.position;
        pos.y += 2.0f;


        switch (m_eve)
        {
            case eventType.enemy:
                
                if (floornum != 0)
                {
                    if (enemypower >= 1)
                    {    
                        Instantiate(normalEnemy, pos, Quaternion.identity);
                        if(layernum>3)
                        {
                            enemypower *= 100;
                        }
                        normalEnemy.GetComponent<Enemy_00>().SetPower(enemypower);
                        normalEnemy.GetComponent<Enemy_00>().SetLayerNum(layernum);
                    }
                }
                break;

            case eventType.item:
                if (floornum != 0)
                {
                    if (enemypower >= 1)
                    {
                        Instantiate(normalEnemy, pos, Quaternion.identity);
                        normalEnemy.GetComponent<Enemy_00>().SetPower(enemypower);
                        normalEnemy.GetComponent<Enemy_00>().SetLayerNum(layernum);
                    }
                }




                break;
            default:
                break;
        }
        if (m_eve == eventType.enemy)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
