using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Load_Map_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Time.time >=1)
		{
			SceneManager.LoadScene ("Map_1");
		}
	}
}
