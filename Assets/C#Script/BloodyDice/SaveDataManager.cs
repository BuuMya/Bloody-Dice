using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct SaveData
{
    public string Username;
    public int HP;          //‘Ï‹v—Í
    public int MP;          //‹C—Í
    public int ChordNum;    //í“¬w”
    public int Hunger;      //‹Q‰ìƒQ[ƒW
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
