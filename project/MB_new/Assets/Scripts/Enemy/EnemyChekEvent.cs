using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyChekEvent : MonoBehaviour {

	//private List<Collider2D> colliderList = new List<Collider2D> ();
	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D collider) //регистрация событий при входе в зону тригера
	{


		if(collider.tag == "Item")
		{

			Destroy(collider.gameObject);

		}

		if(collider.tag == "Teleport")
		{

		}

		if (collider.tag == "Players") 
		{
			collider.GetComponent<PlayerState> ().currentHealth -= GetComponent<EnemyState> ().DamagePlayer;
			Debug.Log (GetComponent<EnemyState> ().DamagePlayer);
		}




	}

	void OnTriggerStay2D(Collider2D collider) //регистрация событий при нахождении в зоне тригера
	{
		if(collider.tag == "Walls")
		{
			collider.GetComponent<WallState> ().CurrentHealth -= GetComponent<EnemyState>().DamageWall * Time.deltaTime;
		}



		if(collider.tag == "Plate")
		{

		}


	}

	void OnTriggerExit2D(Collider2D collider) //регистрация событий при выходе из зоный пересечения тригера
	{
		if(collider.tag == "Walls")
		{

		}

		if(collider.tag == "Plate")
		{

		}

	}
}
