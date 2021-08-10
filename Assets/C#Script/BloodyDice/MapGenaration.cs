using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenaration : MonoBehaviour
{
    // Start is called before the first frame update
    
     public GameObject roadPrefab;      //道
     public GameObject floorPrefab;     //床
     public GameObject wallPrefab;      //壁
    public GameObject erevatorPrefab;   //エレベーター

    public struct MapStatus
    {
        public int mapType;
        //0   wall
        //1   floor
        //2   erevator
        //3   none        
        public int eventType;
    }
    //配列の幅
    public int m_width = 10; //x軸方向
    public int m_heigt = 10; //z軸方向
    public int m_depth = 2;  //y軸方向
    private int randomMin = 0;
    private int randomMax = 2;

    

    void Start()
    {
        int mapnum =0;
        MapStatus[,,] map = new MapStatus[m_width, m_heigt,m_depth];
        for (int k = 0; k < map.GetLength(2); k++)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j,k].mapType = Random.Range(randomMin, randomMax);
                    if (i == 0 || j == 0)
                    {
                        map[i, j, k].mapType = 1;
                        GameObject m_wall = Instantiate(wallPrefab);
                        m_wall.transform.position = new Vector3(i * 20 - 15, k * 20.0f, j * 20 - 15);


                    }
                    if (i == m_width - 1 || j == m_heigt - 1)
                    {
                        map[i, j, k].mapType = 1;
                        GameObject m_wall = Instantiate(wallPrefab);
                        m_wall.transform.position = new Vector3((i - 1) * 20 - 10, k * 20.0f, (j - 1) * 20 - 10);

                    }
                    



                }
            }
        }

        
Debug.Log(map.GetLength(0)* map.GetLength(1));
        for (int k = 0; k < map.GetLength(2); k++)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    
                    //インデックスの値が1の時、floorPrefabを生成
                    if (map[i, j, k].mapType == 1)
                    {
                        int wallcount =0;
                        mapnum++;
                        
                        if (j != 0)
                        {

                            if (map[i, j - 1,k].mapType == 1|| map[i, j - 1, k].mapType == 2)
                            {
                                GameObject m_road = Instantiate(roadPrefab);
                                m_road.transform.position = new Vector3(i * 15,k*20.0f, j * 15 - 7.5f);
                            }
                            else if(map[i, j - 1, k].mapType == 0)
                            {
                                wallcount++;
                            }



                        }
                        if (j != map.GetLength(1)-1)
                        {
                            if (map[i, j + 1,k].mapType == 0)
                            {
                                wallcount++;

                            }
                        }
                        if (i != 0)
                        {
                            if (map[i - 1, j,k].mapType == 1|| map[i-1, j , k].mapType == 2)
                            {
                                GameObject m_road = Instantiate(roadPrefab);
                                m_road.transform.position = new Vector3(i * 15.0f - 7.5f, k*20.0f, j * 15);
                                m_road.transform.Rotate(new Vector3(0, 90, 0));
                            }
                            else if (map[i-1, j , k].mapType == 0)
                            {
                                wallcount++;
                            }

                        }
                        if (i != map.GetLength(0)-1)
                        {
                            if (map[i + 1, j,k].mapType == 0)
                            {
                                wallcount++;
                            }
                        }

                        if(wallcount ==3)
                        {
                            GameObject m_ere = Instantiate(erevatorPrefab);
                            m_ere.transform.position = new Vector3(i * 15, k * 20.0f, j * 15);
                            m_ere.GetComponent<elevator>().SetStageNum(k);
                           
                            map[i, j, k].mapType = 2;
                        }
                        else
                        {
                            if (k != 0)
                            {
                                if (map[i, j, k - 1].mapType != 2)
                                {
                                    int randnum = Random.Range(0, (int)Floor.eventType.eventnum);
                                    GameObject go = Instantiate(floorPrefab);
                                    go.GetComponent<Floor>().m_eve = (Floor.eventType)randnum;
                                    int floornum = k * 100 + i * 10 + j;
                                    go.name = floornum.ToString();
                                    go.transform.position = new Vector3(i * 15, k * 20.0f, j * 15);
                                }
                                else
                                {
                                    map[i, j, k].mapType = 3;
                                }
                            }
                            else
                            {
                                GameObject go = Instantiate(floorPrefab);
                                int floornum = k * 100 + i * 10 + j;
                                go.name = floornum.ToString();
                                go.transform.position = new Vector3(i * 15, k * 20.0f, j * 15);
                            }
                           
                        }

                    }
                    if (map[i, j,k].mapType == 0)
                    {
                        if (k != 0)
                        {
                            if (map[i, j, k - 1].mapType != 2)
                            {
                                GameObject m_wall = Instantiate(wallPrefab);
                                m_wall.transform.position = new Vector3(i * 15, k * 20, j * 15);
                            }
                            else
                            {
                                map[i, j, k].mapType = 3;
                            }
                        }
                        else
                        {
                            GameObject m_wall = Instantiate(wallPrefab);
                            m_wall.transform.position = new Vector3(i * 15, k * 20, j * 15);
                        }
                    }
                }
            }
        }
        Debug.Log("マップ自動生成 :" + mapnum);
        Debug.Log(map);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
