using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    bottle,
    allow,
    TypeNum

}

public struct Item
{
    public string[] name;
    public ItemType type;
    public int num;

}
public class ItemManager : MonoBehaviour
{
    public List<Item> items =new List<Item>();
    public Item[] tmpItem;
    
    public void InitItem()
    {
        
        for(int i =0;i<(int)ItemType.TypeNum; i++)
        {
            if (tmpItem[i].num > 0)
            {
                items.Add(tmpItem[i]);
            }
        }
    }
    public void GetItem(ItemType type,int num)
    {
        Item m_Item =items[(int)type];
        m_Item.num += num;
        items[(int)type] = m_Item;
        Debug.Log(type.ToString()+" Å~"+num+" Get!!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
