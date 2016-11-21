using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerChekEvent : MonoBehaviour {

	private GameObject map_object;
	private PlayerControl player;
	private int tempScore; //переменная для хранения промежуточного результата количества денег у игрока
	//private List<Collider2D> colliderList = new List<Collider2D> ();
	// Use this for initialization
	void Start () 
	{
		//player = GameObject.Find ("Player_red").GetComponent<PlayerControl> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D collider) //регистрация событий при входе в зону тригера
	{


		if(collider.tag == "Item")
		{
			tempScore = PlayerPrefs.GetInt ("Score") + 1;
			PlayerPrefs.SetInt("Score", tempScore);
			Destroy(collider.gameObject);
			Debug.Log (PlayerPrefs.GetInt ("Score"));
			GameObject.Find ("Money_player_blue").GetComponent<Text> ().text = tempScore.ToString();
			//player.OnKeyLeft();
		}

		if(collider.tag == "Teleport")
		{
			SceneManager.LoadScene ("Map_2");
		}




	}

	void OnTriggerStay2D(Collider2D collider) //регистрация событий при нахождении в зоне тригера
	{
		if(collider.tag == "Walls")
		{
			GetComponent<Animator> ().SetBool ("Run", false);
			//GetComponent<Animator> ().SetBool ("Brake_start", true);
			collider.GetComponent<WallState> ().CurrentHealth -= GetComponent<PlayerState>().DamageWall * Time.deltaTime;
		}

		if(collider.tag == "Plate")
		{
			GetComponent<Animator> ().SetBool ("Run", false);
			//GetComponent<Animator> ().SetBool ("idle", true);
		}
			

	}

	void OnTriggerExit2D(Collider2D collider) //регистрация событий при выходе из зоный пересечения тригера
	{
		if(collider.tag == "Walls")
		{
			//GetComponent<Animator> ().SetBool ("Brake_start", false);
			GetComponent<Animator> ().SetBool ("Run", true);
		}

		if(collider.tag == "Plate")
		{
			//GetComponent<Animator> ().SetBool ("idle", false);
			//GetComponent<Animator> ().SetBool ("Brake_start", false);
			GetComponent<Animator> ().SetBool ("Run", true);

		}

	}
}
