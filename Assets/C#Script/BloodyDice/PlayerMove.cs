using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float inputHorizontal;
    public float inputVertical;
    Rigidbody rb;
    Vector3 vec;
    bool speedupflag =false;
    float moveSpeed = 15f;
    Effekseer.EffekseerEmitter m_emitter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public float GetPalam(string name)
    {
        switch (name)
        {
            case "inputHorizontal":
                return inputHorizontal;

            case "inputVertical":
                return inputVertical;
            
            default:
                return 0f;
               //break;
        }

    }
    public void Resetspeed()
    {
        moveSpeed /= 1.5f;
    }
    public void SpeedUp()
    {
        speedupflag = true;
        moveSpeed *= 1.5f;
    }
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(speedupflag)
        {
            Invoke("Resetspeed", 2.0f);
            speedupflag = false;

        }
        
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        //Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 0)).normalized;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        
            
            // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
       
        // �L�����N�^�[�̌�����i�s������
        if (moveForward != Vector3.zero)
        {
            vec = moveForward;
            vec.y =0.0f;
            transform.rotation = Quaternion.LookRotation(vec);
        }
    }

}
