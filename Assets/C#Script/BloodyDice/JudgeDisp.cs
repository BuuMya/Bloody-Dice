using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JudgeDisp : MonoBehaviour
{
    Text m_text;
    public const string gameOvertemplate = "Game Over...";
    public void SetTextPalam(string text,Color color)
    {
        m_text.text = text;
        m_text.color = color;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
