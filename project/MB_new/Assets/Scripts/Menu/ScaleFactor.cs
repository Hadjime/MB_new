using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScaleFactor : MonoBehaviour {
	public float temp2;
	public float temp1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Camera> ().orthographicSize = temp1;
	
	}
}
