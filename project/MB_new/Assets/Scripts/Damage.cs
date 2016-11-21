using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour {
	public int _Damage;

	//private List <Collider2D> colliderList = new List<Collider2D>();
	// Use this for initialization
	void Start () {
		
	
	}


	void OnTriggerEnter2D(Collider2D collider)
	{


		if (collider.tag == "Walls" || collider.tag == "Plate")
		{
			Destroy (gameObject);


		}
		if (collider.tag == "Enemys")
		{

			Destroy (gameObject);
			Destroy (collider.gameObject);

		}
		if (collider.tag == "Players")
		{
			collider.GetComponent<PlayerState> ().currentHealth -= _Damage;
			Destroy (gameObject);


		}
	}

	void OnCollisionEnter(Collider2D collider)
	{


		if (collider.tag == "Walls" || collider.tag == "Plate")
		{
			Destroy (gameObject);


		}
		if (collider.tag == "Enemys")
		{

			Destroy (gameObject);
			Destroy (collider.gameObject);

		}
		if (collider.tag == "Players")
		{
			collider.GetComponent<PlayerState> ().currentHealth -= _Damage;
			Destroy (gameObject);


		}
	}


}


