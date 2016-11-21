using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrigerEnemysOn : MonoBehaviour {

	//private List <Collider2D> colliderList = new List<Collider2D>();
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D collider)
	{


		if (collider.tag == "Enemys")
		{
			if (!LeanTween.isTweening (gameObject)) { //проверка чтобы линтвин не запускался несколько раз
				LeanTween.scale (gameObject, new Vector2 (1, 3), 0.1f).setLoopPingPong (2);
			}


		}

	}
}
