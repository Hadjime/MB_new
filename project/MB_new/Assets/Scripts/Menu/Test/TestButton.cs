using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {
	public Button Button;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() =>

			Debug.Log("Click on Button " + gameObject.name)


		);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
