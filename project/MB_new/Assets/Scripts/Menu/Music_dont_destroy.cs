using UnityEngine;
using System.Collections;

public class Music_dont_destroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
	
	}
}
