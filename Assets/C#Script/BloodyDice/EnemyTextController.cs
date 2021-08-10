using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTextController : MonoBehaviour
{
	void Start()
	{
		transform.localScale = new Vector3(-1, 1, 1);
	}

	void Update()
	{
		//if (Vector3.Distance(Camera.main.transform.position, transform.position) > 14.0f)
		//{
		//	gameObject.GetComponent<TextMesh>().transform.localScale = Vector3.zero;
		//}
		//else gameObject.GetComponent<TextMesh>().transform.localScale =new Vector3(0.5f,0.5f,0.5f);
		transform.LookAt(Camera.main.transform);
	}
}
