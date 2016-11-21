using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour {

	void OnMouseDown()
	{
		SceneManager.LoadScene ("Menu");
	}
}
