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
		if (Vector3.Distance(Camera.main.transform.position, transform.position) > 30.0f)
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
		else gameObject.GetComponent<MeshRenderer>().enabled = true;
		transform.LookAt(Camera.main.transform);
	}
}
