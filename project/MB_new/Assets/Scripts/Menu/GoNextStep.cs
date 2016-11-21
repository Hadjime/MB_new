using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GoNextStep : MonoBehaviour {
	//private List <Collider2D> colliderList = new List<Collider2D>();

	void OnTriggerEnter2D(Collider2D collider)
	{


		if (collider.name == "exit")
		{
			Debug.Log("Next");
			SceneManager.LoadScene ("Map_2");
		}

	}
}
