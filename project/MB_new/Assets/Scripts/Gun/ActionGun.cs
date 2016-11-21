using UnityEngine;
using System.Collections;

public class ActionGun : MonoBehaviour {
	public GameObject Particle_System;
	public int Damage;
	public float Time;



	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndDestroy());

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitAndDestroy()
	{
		yield return new WaitForSeconds (4); //ждем сколько-то секунд

		Collider2D[] _col = Physics2D.OverlapCircleAll(gameObject.transform.position, 3); //получаем списо коллайдеров в определенном радиусе от объекта
		GameObject newParticle = Instantiate (Particle_System);
		newParticle.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		foreach (var col in _col) //пробегаемся по этим коллайдерам 
		{
			if (col.tag == "Walls") //если коллайдер стена то наносим урон
			{
				col.GetComponent<WallState> ().CurrentHealth -= Damage; //наносим урон стене
				Destroy (gameObject);//удаляем обект со сцены
			}
			if (col.tag == "Players") //если коллайдер стена то наносим урон
			{
				col.GetComponent<PlayerState> ().currentHealth -= Damage; //наносим урон стене
				Destroy (gameObject);//удаляем обект со сцены
			}
			if (col.tag == "Item") //если коллайдер стена то наносим урон
			{
				Destroy (gameObject);//удаляем обект со сцены
				Destroy(col.gameObject);
			}
			if (col.tag == "Enemys") //если коллайдер стена то наносим урон
			{
				col.GetComponent<EnemyState> ().currentHealth -= Damage; //наносим урон стене
				Destroy (gameObject);//удаляем обект со сцены
				Destroy(col.gameObject);
			}
		}


	}
}
