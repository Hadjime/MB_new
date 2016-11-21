using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {
	public GameObject Player;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, Player.transform.position, Time.deltaTime * speed);
		Debug.Log (gameObject.GetComponent<Rigidbody2D> ().GetPointVelocity (new Vector2(0, 0)));
	
	}
}
