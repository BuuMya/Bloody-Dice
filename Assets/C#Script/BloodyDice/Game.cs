using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private GameObject player;
    public GameObject text;
    int localtimer = 0;
    string m_reasontext;
    public void SetReason(string reason)
    {
        m_reasontext = reason;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //DontDestroyOnLoad(this);

        
    }

    // Update is called once per frame
    void Update()
    {
       if( player.GetComponent<Player>().GetPlayerState()==Player.PlayerState.die)
       {
            text.GetComponent<Text>().enabled = true;
            text.GetComponent<JudgeDisp>().SetTextPalam("Game Over...\n\n"+m_reasontext, Color.red);

            localtimer++;
            if (localtimer > 80)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                localtimer = 0;
            }

       }
       else if(player.GetComponent<Player>().GetPlayerState() == Player.PlayerState.clear)
        {
            text.GetComponent<JudgeDisp>().SetTextPalam("GAME CLEAR!", Color.yellow);
            text.GetComponent<Text>().enabled = true;
        }
    }
}
