using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct SaveData
{
    public string Username;
    public int HP;          //�ϋv��
    public int MP;          //�C��
    public int ChordNum;    //�퓬�w��
    public int Hunger;      //�Q��Q�[�W
    public string SceneName;
    public Item[] m_Item;


}


public class SaveDataManager : MonoBehaviour
{
    [SerializeField]
    public SaveData m_savedata;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
