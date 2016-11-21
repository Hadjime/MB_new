using UnityEngine;
using System.Collections;

public class Destroy_Particles : MonoBehaviour {
	public float timeOut;
	private float time = 0;
	// Use this for initialization
	void Start () {
		//time = timeOut;
	}
	
	// Update is called once per frame
	void Update () {
		if(time == timeOut){
			Destroy (gameObject);
			time = 0;
		}
		if(time < timeOut){
			time += 1; //Time.deltaTime;
		}
	
	}
}
