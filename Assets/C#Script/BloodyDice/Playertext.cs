using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playertext : MonoBehaviour
{
    TextMesh m_text;
    string textinfo;
    public void SetText(string text,Color color)
    {
        GetComponent<TextMesh>().text = text;
        GetComponent<TextMesh>().color = color;


    }
    // Start is called before the first frame update
    void Start()
    {
        //m_text = GetComponent<TextMesh>();

        //m_text.text = textinfo;
         //textinfo;
        //transform.LookAt(Camera.main.transform);
        //transform.Translate(0.0f, 0.0f, 1.0f);
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, 0.03f,0.0f);
        //GetComponent<TextMesh>().text = textinfo;
        Invoke("Death", 10.0f);
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
