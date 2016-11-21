using UnityEngine;
using System.Collections;

public class If_android : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		#if UNITY_ANDROID
		gameObject.SetActive(true);
		#endif

		/*#if UNITY_EDITOR_WIN
		gameObject.SetActive(false);
		#endif*/


	}
	

}
