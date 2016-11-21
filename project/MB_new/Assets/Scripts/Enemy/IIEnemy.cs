using UnityEngine;
using System.Collections;

public class IIEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LeanTween.move (gameObject, new Vector2 (Random.Range(1, 68), Random.Range(1, 23)), Random.Range(2, 8)).setLoopPingPong ();
		LeanTween.scale (gameObject, new Vector3 (3, 2, 1), Random.Range(1, 3)).setLoopPingPong ();

	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
}
