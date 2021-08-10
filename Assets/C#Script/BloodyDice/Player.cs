using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    const float Limit = -100.0f;
    private int HPlimit = 100;

    public GameObject EffectPlayer;
    public GameObject JumpEffect;
    public GameObject ExplosionEffect;

    public GameObject text;


    public Effekseer.EffekseerEmitter m_emitter;
    public Effekseer.EffekseerEmitter j_emitter;
    public Effekseer.EffekseerEmitter e_emitter;

    public enum PlayerState
    {
        idle,
        walk,
        run,
        attack,
        spattack,
        useItem,
        damage,
        die,
        clear,
        statenum
    }
    public struct PlayerPalam
    {
        public string Username;
        public int HP;          //耐久力
        public int MP;          //気力
        public int ChordNum;    //戦闘指数
        public int Hunger;      //飢餓ゲージ
    }

    private PlayerPalam m_plpalam;
    public PlayerState p_state;
    private void PlayerInitialize(string username, int hp, int mp, int cnum, int hunger)
    {
        p_state = PlayerState.idle;
        m_plpalam.Username = username;
        m_plpalam.HP = hp;
        m_plpalam.MP = mp;
        m_plpalam.ChordNum = cnum;
        m_plpalam.Hunger = hunger;
    }
    //hpに引数を加算
    public void DamageORHealing(int dmg)
    {
        if ((m_plpalam.HP + dmg) <= 0)
        {
            KillPlayer();
            m_plpalam.HP = 0;
        }
        else m_plpalam.HP += dmg;
    }
    public void AddMP(int mp)
    {
        m_plpalam.MP += mp;
    }
    public void EditPlayerChordNum(int num)
    {
        m_plpalam.ChordNum += num;
    }
    public void Eating(string plusnum)
    {
        m_plpalam.Hunger++;
        m_emitter.Play();
        
        //Vector3 m_vec = transform.position;
        //m_vec.z += 1;
        GetComponent<PlayerMove>().SpeedUp();

        text.GetComponent<Playertext>().SetText("[勝利]\n戦闘指数+" + plusnum
            +"\nHP上限+"+Mathf.Pow(10,plusnum.Length),Color.yellow);
        Instantiate(text, transform.position,Quaternion.LookRotation(new Vector3(0.0f,-90.0f,0.0f)));
        
    }
    public void JumpSP()
    {
        j_emitter.Play();
        gameObject.transform.localScale *=1.1f;
        GetComponent<Rigidbody>().AddForce(0.0f, 100.0f, 0.0f);
        m_plpalam.MP -= 50;
    }
    public PlayerPalam GetPlayerPalam()
    {
        return m_plpalam;
    }
    public PlayerState GetPlayerState()
    {
        return p_state;
    }
    //PLayerKill
    public void KillPlayer()
    {
        if (p_state != PlayerState.die)
        {
            e_emitter.Play();
        }
        p_state = PlayerState.die;
        
        Invoke("explosion", 2.0f);
    }
    void explosion()
    {
        GetComponent<Light>().enabled = false;
        GetComponent<MeshRenderer>().enabled =false;
    }
    public int GetHPLimit()
    {
        return HPlimit;
    }
    public void EventDisp(string tex,Color color)
    {
        Vector3 vec =transform.position;
        if(color ==Color.red)
        {
            int rand = Random.Range(2, 4);
            if(Random.Range(0,2)==0)
            {
                rand *= -1;
            }
            vec.x += rand;
        }
        text.GetComponent<Playertext>().SetText(tex, color);
        Instantiate(text,vec, Quaternion.LookRotation(new Vector3(0.0f, -90.0f, 0.0f)));

    }
    //HP上限解放
    public void LimitUp(int upnum)
    {
        HPlimit += upnum;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_emitter = EffectPlayer.GetComponent<Effekseer.EffekseerEmitter>();
        j_emitter = JumpEffect.GetComponent<Effekseer.EffekseerEmitter>();
        e_emitter = ExplosionEffect.GetComponent<Effekseer.EffekseerEmitter>();
        //コルーチンを設定
        StartCoroutine(loop());
        PlayerInitialize("SamplePlayer", 100, 100, 5, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Limit
            || m_plpalam.HP <= 0
            || m_plpalam.Hunger<=0)
        {
            GetComponent<Rigidbody>().velocity =new Vector3(1.0f,1.0f,1.0f);

            gameObject.GetComponent<PlayerMove>().enabled = false;
            KillPlayer();

        }
        if (m_plpalam.MP > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpSP();
            }
        }
        if(transform.position.y > -Limit)
        {
            p_state = PlayerState.clear;
        }

    }

    private IEnumerator loop()
    {
        // ループ
        while (true)
        {
            // 7秒毎にループします
            yield return new WaitForSeconds(7f);
            onTimer();
        }
    }
    private void onTimer()
    {
        if (p_state != PlayerState.clear 
            && p_state != PlayerState.die)
        {
            m_plpalam.Hunger--;


                if ((m_plpalam.HP + m_plpalam.ChordNum / 2) <= HPlimit)
                {
                    DamageORHealing(m_plpalam.ChordNum / 2);
                    text.GetComponent<Playertext>().SetText("[継続回復]\nHP+"+ m_plpalam.ChordNum / 2, Color.green);
                Instantiate(text, transform.position, Quaternion.LookRotation(new Vector3(0.0f, -90.0f, 0.0f)));

            }
            else m_plpalam.HP = HPlimit;
            
        }
    }
}