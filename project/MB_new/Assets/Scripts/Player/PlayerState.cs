using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour {

	public int currentHealth; //текущее здоровье игрока
	public int maxHealth; // максимальное здоровье игрока
	public Image healthBar; // канвас изображение которое будит уменьшатся в соответствии с текущим здоровьем

	public int money; //кол-во денег собранные персонажем
	public int DamageWall; //урон героя, применяется только к стенам но не к противникам



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

		healthBar.fillAmount = (float)currentHealth / maxHealth; //меняем размера healthBar в соответствии с текущим здоровьем
	
	}
}
