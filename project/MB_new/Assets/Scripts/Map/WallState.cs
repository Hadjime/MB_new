using UnityEngine;
using System.Collections;

public class WallState : MonoBehaviour {
	public Sprite[] spriteMas; //массив спрайтов в котором хранятся спрайты стены
	public float MaxHealth; //максимальное кол-во жизней у стены
	public float CurrentHealth; //текущее кол-во жизней у стены

	private float NumberHealthToSprite; //переменная для вычисления порога переключения спрайтов стены



	// Use this for initialization
	void Start () {
		NumberHealthToSprite = (MaxHealth / spriteMas.Length); //кол-во жизней на отображение одного спрайта спрайт


	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentHealth > MaxHealth) //если текущее кол-во жизней выше максимального то уравниваем
		{
			CurrentHealth = MaxHealth; // уравниваем текущее кол-во жизней с максимальным
		}

		if (CurrentHealth < 0) //если текущее кол-во жизней меньше нуля то уравниваем и может удаляем
		{
			CurrentHealth = 0;
		}

		if (spriteMas.Length == 1) //если в массиве спрайтов spriteMas всего один спрайт то..
		{
			if (CurrentHealth <= 0)  //если текущее значение жизней у стены закончилось то удаляем обект
			{
				Destroy (gameObject);//удаление обекта
			}	
		} 
		else //если в массиве спрайтов spriteMas кол-во спрайтов больше одного то..
		{
			for (int i = 0; i < spriteMas.Length; i++) //цикл по кол-ву спрайтов в массиве spriteMas
			{
				
				if (CurrentHealth <= MaxHealth - ((MaxHealth / spriteMas.Length) * (i+1))) //зависимость кол-ва жизней и видом спрайта стены
				{
					GetComponent<SpriteRenderer> ().sprite = spriteMas [i];// устанавливаем спрайт из массива соответстующий кол-ву здоровья стеный
				}

				if (CurrentHealth <= 0) //если жизни закончились то...
				{
					Destroy (gameObject); // удаляем объект
				}
			}
		}
		/*if (Health >= MaxHealth * 0.75) 
		{
			GetComponent<SpriteRenderer> ().sprite = spriteMas[0];
		}

		if (Health <= MaxHealth * 0.75) 
		{
			GetComponent<SpriteRenderer> ().sprite =  spriteMas[1];
		}

		if (Health <= MaxHealth * 0.25) 
		{
			GetComponent<SpriteRenderer> ().sprite = spriteMas[2];
		}*/



	}
}
