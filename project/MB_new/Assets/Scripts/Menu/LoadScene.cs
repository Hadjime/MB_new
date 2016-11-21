using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public int Level;
	
	// Update is called once per frame
	void Update () {
		_LoadSceneLocal ();
	}

	public void _LoadSceneGlobal()
	{
			SceneManager.LoadScene(Level);
	}

	public void _Quit_to_game()
	{
		Application.Quit ();
	}

	void _LoadSceneLocal()
	{
		if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
		{
			SceneManager.LoadScene(Level);
		}
	}
}
