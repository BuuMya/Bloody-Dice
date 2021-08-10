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
        
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        //Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 0)).normalized;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        
            
            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
       
        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            vec = moveForward;
            vec.y =0.0f;
            transform.rotation = Quaternion.LookRotation(vec);
        }
    }

}
