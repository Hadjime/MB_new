using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour {

	public int currentHealth; //текущее здоровье игрока
	public int maxHealth; // максимальное здоровье игрока

	public int DamagePlayer; //урон NPC, применяется только к стенам но не к противникам
	public int DamageWall; //урон NPC, применяется только к стенам но не к противникам



	// Use this for initialization
	void Start () {
		currentHealth = maxHealth; //вначале у персонажа кол-во жизней максимально

	}

	// Update is called once per frame
	void Update () {
		if (currentHealth >= maxHealth) //если кол-во здоровья больше максимального то уравниваем до максимального 
		{
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0) //если кол-во здоровья меньше нуля то уравнивам до нуля
		{
			currentHealth = 0;
			Destroy (gameObject);
			//SceneManager.LoadScene ("Map_1");
		}



	}
}
