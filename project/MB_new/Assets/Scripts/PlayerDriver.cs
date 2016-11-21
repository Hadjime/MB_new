using UnityEngine;
using System.Collections;



public class PlayerDriver : MonoBehaviour {

	//переменная для установки макс. скорости персонажа
	public float maxSpeed = 10f; 
	//переменная для определения направления персонажа вправо/влево
	private bool isFacingRight = true;

	//ссылка на компонент анимаций
	//private Animator anim;
	
	// Update is called once per frame
	void Update () {
		//используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
		//при стандартных настройках проекта 
		//-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
		//1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		
		//используем Input.GetAxis для оси Y. метод возвращает значение оси в пределах от -1 до 1.
		//при стандартных настройках проекта 
		//-1 возвращается при нажатии на клавиатуре стрелки вверх (или клавиши W),
		//1 возвращается при нажатии на клавиатуре стрелки вниз (или клавиши S)
		float moveVertical = Input.GetAxisRaw("Vertical");
		
		//в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
		//приэтом нам нужен модуль значения
		//anim.SetFloat("Speed", Mathf.Abs(move));
		if (moveHorizontal > 0 || moveHorizontal < 0) {
			//обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
			//равную значению оси Х умноженное на значение макс. скорости
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveHorizontal * maxSpeed * Time.deltaTime, 0);
		} else {
			//обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
			//равную значению оси Х умноженное на значение макс. скорости
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, moveVertical * maxSpeed * Time.deltaTime);
		}
		//если нажали клавишу для перемещения вправо, а персонаж направлен влево
		/*if(moveHorizontal > 0 && !isFacingRight)
			//отражаем персонажа вправо
			Flip();
		//обратная ситуация. отражаем персонажа влево
		else if (moveHorizontal < 0 && isFacingRight)
			Flip();*/
		
	}
	
	private void Flip()
	{
		//меняем направление движения персонажа
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector3 theScale = transform.localScale;
		//зеркально отражаем персонажа по оси Х
		theScale.x *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		transform.localScale = theScale;
		
	}
	
	
}
