using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_00 : MonoBehaviour
{
    public float angle=0.1f;
    public int power,HP =0;
    GameObject nextfloor;
    List<string> noneLookfloorname;
    public GameObject m_text;
    int localmovetimer = 0;
    int layernum = 0;
    private Player pl;
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "Player")
            {
            
            pl = collision.gameObject.GetComponent<Player>();
            pl.DamageORHealing(-power);
            pl.EventDisp("[戦闘]\nHP-" + power.ToString(), Color.red);
            Debug.Log(name + "：　接触");
            if (pl.GetPlayerPalam().ChordNum >power)
            {
                pl.Eating(power.ToString());
                pl.AddMP(10);
                pl.EditPlayerChordNum(power);
                float a = Mathf.Pow(10, (power == 0) ? 1 : ((int)Mathf.Log10(power) + 1));
                pl.LimitUp((int)a);
                Destroy(gameObject);
            }
            else
            {
                HP -= pl.GetPlayerPalam().ChordNum;
            
            }

            }

        
    }
    public void SetPower(int num)
    {
        power = num;
    }
    public void SetLayerNum(int lnum)
    {
        layernum = lnum;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_text.GetComponent<TextMesh>().text = "敵コード\n" + power.ToString();
        name = "プロトコード" + power.ToString();
        HP = power;

    }



    // Update is called once per frame
    void Update()
    {
        localmovetimer++;
        if (localmovetimer ==100)
        {

            localmovetimer = 0;
        }
        if(HP<0)
        {
            pl.Eating(power.ToString());

            pl.EditPlayerChordNum(power);
            float a = Mathf.Pow(10, (power == 0) ? 1 : ((int)Mathf.Log10(power) + 1));
            pl.LimitUp((int)a);
            Destroy(gameObject);
        }
    }
        //if (vec != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(vec);
        //}
    }


