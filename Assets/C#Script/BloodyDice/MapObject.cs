using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer render;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position,transform.position)<14.0f)
        {
            render.enabled = false;
        }
        else render.enabled = true;
    }
}
