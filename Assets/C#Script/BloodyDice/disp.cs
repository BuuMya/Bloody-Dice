using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class disp : MonoBehaviour
{
    Text m_text;
    public GameObject player;
    public Player.PlayerPalam m_palam;
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_palam = player.GetComponent<Player>().GetPlayerPalam();

        m_text.text = "PlayerName\n" + m_palam.Username
            + "\n~~~~~~~~~~~~\n"
            + "HP " + m_palam.HP.ToString()
            +"/"+player.GetComponent<Player>().GetHPLimit().ToString()
            + "\nMP " + m_palam.MP.ToString()
            + "\nêÌì¨éwêî " + m_palam.ChordNum.ToString()
            + "\nãQâÏìx"+ m_palam.Hunger.ToString();


    }
}
