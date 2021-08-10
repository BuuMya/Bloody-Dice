using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public int stagenum = 0;
    public float speed = 1.0f;
    public bool IsMove = false;
    private Vector3 m_startPos;
    private Rigidbody m_rig;
    private Animator m_animator;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (IsMove == false)
        {
            if (transform.position.y < (stagenum + 1) * 20.0f)
            {
                if (collision.gameObject.tag == "Player")
                {
                    IsMove = true;
                    Debug.Log(name + ":PLAYER_RIDE ON!");
                    //collision.gameObject.GetComponent<Player>().EditPlayerChordNum(2);
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    m_animator.SetInteger("elevatorState", 0);
        //    Debug.Log(name + ":PLAYER_GET OUT!");
        //    Invoke("Change", 2.0f);

        //}
    }
    void Change()
    {
        IsMove = true;
    }
    public void SetStageNum(int num)
    {
        stagenum = num;
    }
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rig = GetComponent<Rigidbody>();
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMove)
        {

            transform.Translate(new Vector3(0.0f, speed, 0.0f));
            //m_rig.velocity =new Vector3(0.0f,1.0f*speed,0.0f);
            
        }
        if (transform.position.y > (stagenum + 1) * 20.0f || transform.position.y < stagenum * 20.0f)
        {
            if(transform.position.y > (stagenum + 1) * 20.0f)
            {
                IsMove = false;
                m_animator.SetInteger("elevatorState", 1);
                //Invoke("Change", 10.0f);
            }
            speed *= -1.0f;
        }
    }
}
