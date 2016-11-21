using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	public OPTIONS Button_Control;//выпадающий список делается вот как-то так
	public enum OPTIONS 
	{
		WASD = 0,
		Arrow = 1,	
	}
		
	public float speed = 2; //скорость передвижения игрока

	private float direction_x, direction_y; //направление по оси x  и по оси y для передвижения в рахных направлениях
	private Rigidbody2D rb2d; //переменная для доступа к параметрам твердого тела
	private Animator _animator; //переменная для доступа к параметрам аниматора
	private float offset = 0.1f;//смещение относительно центра клетки в диапазоне которого проверяется нажатие клавиш управления
	private Vector3 DestinationVector;
	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> (); // в переменную записываем обращение к компоненту Аниматор
		rb2d = GetComponent<Rigidbody2D> (); //в переменную записываем обращение к компоненту твердое тело
		direction_x = 0; //направления пока выставляем в ноль
		direction_y = 0; //направления пока выставляем в ноль


	}



	// Update is called once per frame
	void FixedUpdate () {
		

		if (Button_Control == OPTIONS.Arrow) //Если в выпадающем меню выбрано Arrow то управление будит стрелками
		{
			if (!Input.GetKey (KeyCode.LeftArrow) && 
				!Input.GetKey (KeyCode.RightArrow) && 
				!Input.GetKey (KeyCode.DownArrow) && 
				!Input.GetKey (KeyCode.UpArrow)) //если не нажата клавиша передвижения
			{
				NoKeyDown (); //применяем скорость в том направлении в котором были после последнего изменения направления движения
			}
				
			if (Input.GetKey (KeyCode.RightArrow) ) //если нажали стрелку в право 
			{
				//Debug.Log (rb2d.velocity.y);
				OnKeyRight(); //повернули в право

			}

			if (Input.GetKey (KeyCode.LeftArrow) ) //если нажали стрелку в лево
			{
				//Debug.Log ("Left");
				OnKeyLeft(); //повернули в лево
			}

			if (Input.GetKey (KeyCode.UpArrow) ) //если нажали стрелку в верх
			{
				//Debug.Log("UP");
				OnKeyUp(); //повернули в верх
			}

			if (Input.GetKey(KeyCode.DownArrow) ) //если нажали стрелку в низ
			{
				//Debug.Log ("DOWN");
				OnKeyDown();//повернули в низ
			}
		}

		if (Button_Control == OPTIONS.WASD) //Если в выпадающем меню выбрано управления WASD то управление будит буквами WASD
		{
			if (!Input.GetKey (KeyCode.A) && 
				!Input.GetKey (KeyCode.D) && 
				!Input.GetKey (KeyCode.S) && 
				!Input.GetKey (KeyCode.W)) //если не нажата клавиша передвижения
			{
				NoKeyDown (); //применяем скорость в том направлении в котором были после последнего изменения направления движения
			}
				
			if (Input.GetKey (KeyCode.D) )  //если нажали букву D
			{
					//Debug.Log ("Rigth");
					OnKeyRight(); //повернули в право

			}

			if (Input.GetKey (KeyCode.A) ) //если нажали букву A
			{
					//Debug.Log ("Left");
					OnKeyLeft(); //повернули в лево
			}

			if (Input.GetKey (KeyCode.W) ) //если нажали букву W
			{
					//Debug.Log("UP");
					OnKeyUp(); //повернули в верх
			}

			if (Input.GetKey(KeyCode.S) ) //если нажали букву S
			{
					//Debug.Log ("DOWN");
					OnKeyDown(); //повернули в низ
			}

		}




	}

	public void OnKeyRight() //метод передвижения персонажа на право
	{
		if ((this.transform.position.y >= Mathf.Round(this.transform.position.y) - offset && this.transform.position.y <= Mathf.Round(this.transform.position.y) )) //поворачиваем только когда находимся около целого значения сетки
		{
			if (this.transform.rotation.eulerAngles.z != 0) //проверяем если персонаж повернут в том же направлении куда поворачиваем то ничего не делаем
			{
				direction_x = 1; //направление в право
				if(this.transform.rotation.eulerAngles.z != 180)//если мы развернулись на 180 градусов то не делаем перемещение к целой части сетки перемещения, иначе будут телепортации
				{
					DestinationVector = new Vector3 (Mathf.Round (this.transform.position.x), Mathf.Round (this.transform.position.y), 0.5f);
					//this.transform.position = Vector3.Lerp (this.transform.position, DestinationVector, 0);//округляем позицию игрока до целых
					this.transform.position = DestinationVector;
				}
				this.transform.rotation = Quaternion.Euler (0, 0, 0); //варащение при помощи кватерниона
				//gameObject.transform.eulerAngles = new Vector3(0, 0, 0)//вращение как углы эйлера
				rb2d.velocity = new Vector2 (speed * direction_x, 0); // rb2d.velocity.y = 0 т.к. движение прямолинейно и не изменяется направление по y
			}
		}
	}

	public void OnKeyLeft() //метод передвижения персонажа на лево
	{
		if (this.transform.position.y >= Mathf.Round(this.transform.position.y) - offset && this.transform.position.y <= Mathf.Round(this.transform.position.y) )//поворачиваем только когда находимся около целого значения сетки
		{
			if (this.transform.rotation.eulerAngles.z != 180) //проверяем если персонаж повернут в том же направлении куда поворачиваем то ничего не делаем
			{
				direction_x = -1; //направление в лево
				if(this.transform.rotation.eulerAngles.z != 0)//если мы развернулись на 180 градусов то не делаем перемещение к целой части сетки перемещения, иначе будут телепортации
				{
					DestinationVector = new Vector3 (Mathf.Round (this.transform.position.x), Mathf.Round (this.transform.position.y), 0.5f);
					//this.transform.position = Vector3.Lerp (this.transform.position, DestinationVector, 0);//округляем позицию игрока до целых
					this.transform.position = DestinationVector;
				}
				this.transform.rotation = Quaternion.Euler (0, 0, 180); //варащение при помощи кватерниона
				//gameObject.transform.eulerAngles = new Vector3(0, 0, 180);//вращение как углы эйлера
				rb2d.velocity = new Vector2 (speed * direction_x, 0); // rb2d.velocity.y = 0 т.к. движение прямолинейно и не изменяется направление по y
			}
		}
	}

	public void OnKeyUp() //метод передвижения персонажа вверх
	{
		if (this.transform.position.x >= Mathf.Round(this.transform.position.x) - offset && this.transform.position.x <= Mathf.Round(this.transform.position.x) )//поворачиваем только когда находимся около целого значения сетки
		{
			if (this.transform.rotation.eulerAngles.z != 90) //проверяем если персонаж повернут в том же направлении куда поворачиваем то ничего не делаем
			{
				direction_y = 1; //направление в верх
				if(this.transform.rotation.eulerAngles.z != 270)//если мы развернулись на 180 градусов то не делаем перемещение к целой части сетки перемещения, иначе будут телепортации
				{
					DestinationVector = new Vector3 (Mathf.Round (this.transform.position.x), Mathf.Round (this.transform.position.y), 0.5f);
					//this.transform.position = Vector3.Lerp (this.transform.position, DestinationVector, 0);//округляем позицию игрока до целых
					this.transform.position = DestinationVector;
				}
				this.transform.rotation = Quaternion.Euler (0, 0, 90); //варащение при помощи кватерниона
				//gameObject.transform.eulerAngles = new Vector3 (0, 0, 90);//вращение как углы эйлера
				rb2d.velocity = new Vector2(0, speed * direction_y); // rb2d.velocity.x = 0 т.к. движение прямолинейно и не изменяется направление по x
			}
		}
	}

	public void OnKeyDown() //метод передвижения персонажа в низ
	{
		if (this.transform.position.x >= Mathf.Round(this.transform.position.x) - offset && this.transform.position.x <= Mathf.Round(this.transform.position.x) )//поворачиваем только когда находимся около целого значения сетки
		{
			if (this.transform.rotation.eulerAngles.z != 270) //проверяем если персонаж повернут в том же направлении куда поворачиваем то ничего не делаем
			{
				direction_y = -1; //направление в низ
				if(this.transform.rotation.eulerAngles.z != 90)//если мы развернулись на 180 градусов то не делаем перемещение к целой части сетки перемещения, иначе будут телепортации
				{
					DestinationVector = new Vector3 (Mathf.Round (this.transform.position.x), Mathf.Round (this.transform.position.y), 0.5f);
					//this.transform.position = Vector3.Lerp (this.transform.position, DestinationVector, 0);//округляем позицию игрока до целых
					this.transform.position = DestinationVector;
				}
				this.transform.rotation = Quaternion.Euler (0, 0, 270); //варащение при помощи кватерниона
				//gameObject.transform.eulerAngles = new Vector3 (0, 0, 270);//вращение как углы эйлера
				rb2d.velocity = new Vector2 (0, speed * direction_y); // rb2d.velocity.x = 0 т.к. движение прямолинейно и не изменяется направление по x
			}
		}


	}

	void OnKeyNotTarget() 
	{
		//_animator.SetBool ("Run", false);
	}

	void NoKeyDown() //метод в котором скорость поддерживается в одном направлении
	{ 
		/*if (rb2d.velocity.x == 0 & rb2d.velocity.y == 0) {
			animator.SetBool ("run", false);
			return;
		}*/
		//rb2d.velocity = new Vector2 (0, 0);
		//this.transform.rotation = Quaternion.Euler (0, 0, this.transform.rotation.eulerAngles.z); //варащение при помощи кватерниона
		if (this.transform.rotation.eulerAngles.z == 0) //если повернуты в право то...
		{
			direction_x = 1;
			rb2d.velocity = new Vector2(speed * direction_x, 0);//движемся по оси X
		}

		if (this.transform.rotation.eulerAngles.z == 180) //если повернуты в лево то...
		{
			direction_x = -1;
			rb2d.velocity = new Vector2(speed * direction_x, 0);//движемся по оси -X
		}

		if (this.transform.rotation.eulerAngles.z == 90) //если повернуты в вверх то...
		{
			direction_y = 1;
			rb2d.velocity = new Vector2(0, speed * direction_y);//движемся по оси Y
		}

		if (this.transform.rotation.eulerAngles.z == 270) //если повернуты в вниз то...
		{
			direction_y = -1;
			rb2d.velocity = new Vector2(0, speed * direction_y);//движемся по оси -Y
		}

	}
}
