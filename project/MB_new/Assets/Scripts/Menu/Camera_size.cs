using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Camera_size : MonoBehaviour {
	public GameObject PlayerPosition;
	public Slider slider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Camera> ().orthographicSize += slider.value;
		gameObject.GetComponent<Camera> ().transform.position = new Vector3( PlayerPosition.transform.position.x, PlayerPosition.transform.position.y, -10);

	}

	public void ValueChangeCheck()
	{
		gameObject.GetComponent<Camera> ().orthographicSize = (float)(15.6 * slider.value);
		gameObject.GetComponent<Camera> ().transform.position = GameObject.Find ("Player_blue").transform.position;
	}
}
