using UnityEngine;
using System.Collections;

public class Enemy_corutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (wait ());

	}

	IEnumerator wait()
	{
		
		yield return new WaitForSeconds(5f);

	}

}
