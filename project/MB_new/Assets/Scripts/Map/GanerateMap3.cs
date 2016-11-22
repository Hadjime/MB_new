using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GanerateMap3 : MonoBehaviour {
	public enum EnumGenerationMap
	{
		Static_Generation = 0,
		Procedure_Generation = 1,
	}
	public EnumGenerationMap SetGenerationMap;
	private GameObject map_object;

	//public List<GameObject> arr= new List<GameObject>();
	public GameObject[] arr_prefab_tiles;

	public int width;
	public int height;
	public float spacing;
	float startX = 0;
	float startY = 0;

	int [,] arr_map;//просто создаем массив не указывая размер

	// Use this for initialization
	void Start () 
	{
		if (SetGenerationMap == EnumGenerationMap.Procedure_Generation) //если в выпадающем меню выбрано процедурная генерация
		{
			ProcedureGenerationMap ();
		} 
		else //если в выпадающем меню выбрано статическая генерация
		{
			StaticGenerationMap();
		}


		BuildMap (); //строим карту в соответствии с матрицей
		GameObject.Find ("Player_red").transform.position = new Vector2 (25, 1);//ставим персоннажа в угол
		GameObject.Find ("Player_blue").transform.position = new Vector2 (1, 23);//ставим персоннажа в угол	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void StaticGenerationMap()
	{
		arr_map = new int[,]
		{
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
			{1,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,4,4,4,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,4,0,4,0,5,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,1,},
			{1,0,4,4,4,0,5,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,1,},
			{1,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,10,9,8,7,0,5,4,3,1,},
			{1,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,1,},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,5,6,5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,5,0,6,5,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,14,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,13,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,12,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,11,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,10,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,8,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,6,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,12,2,4,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
		};
	}

	void ProcedureGenerationMap()
	{
		arr_map = new int[height, width]; //теперь уже указываем размерность массива в самой программе но не при инициализации
		//генерация массива
		for (int i = 0; i < height; i++) 
		{
			for (int j = 0; j < width; j++) 
			{
				if ((i == 0) || (i == height - 1) || (j == 0) || (j == width - 1)) {
					arr_map [i, j] = 1;

				} 
				else 
				{
					arr_map [i, j] = Random.Range(3,14); //Random.Range(0,10)
				}

				if (((i == 1) && (j == 1)) || ((i == 1) && (j == 2)) || ((i == 1) && (j == 3)) || ((i == 1) && (j == 4)) || ((i == 1) && (j == 5)) || //левый нижний угол строка
					((i == 1) && (j == 1)) || ((i == 2) && (j == 1)) || ((i == 3) && (j == 1)) || ((i == 4) && (j == 1)) || ((i == 5) && (j == 1)) || //левый нижний угол столбик
					((i == height - 2) && (j == 1)) || ((i == height - 2) && (j == 2)) || ((i == height - 2) && (j == 3)) || ((i == height - 2) && (j == 4)) || ((i == height - 2) && (j == 5)) || //левый врехний угол строка
					((i == height - 2) && (j == 1)) || ((i == height - 3) && (j == 1)) || ((i == height - 4) && (j == 1)) || ((i == height - 5) && (j == 1)) || ((i == height - 6) && (j == 1)) || //левый врехний угол столбик
					((i == height - 2) && (j == width - 2)) || ((i == height - 2) && (j == width - 3)) || ((i == height - 2) && (j == width - 4)) || ((i == height - 2) && (j == width - 5)) || ((i == height - 2) && (j == width - 6)) || //правый верхний угол строка
					((i == height - 2) && (j == width - 2)) || ((i == height - 3) && (j == width - 2)) || ((i == height - 4) && (j == width - 2)) || ((i == height - 5) && (j == width - 2)) || ((i == height - 6) && (j == width - 2)) || //правый верхний угол столбик
					((i == 1) && (j == width - 2)) || ((i == 1) && (j == width - 3)) || ((i == 1) && (j == width - 4)) || ((i == 1) && (j == width - 5)) || ((i == 1) && (j == width - 6)) || //правый нижний угол строка
					((i == 2) && (j == width - 2)) || ((i == 3) && (j == width - 2)) || ((i == 4) && (j == width - 2)) || ((i == 5) && (j == width - 2)) || ((i == 6) && (j == width - 2))  //правый нижний угол столбик
				) 
				{
					arr_map [i, j] = 0;
				}



			}
		}
	}

	void BuildMap()
	{
		

		//создание обектво в соответствии с картой массивом
		for (int i = 0; i < height; i++) 
		{
			for (int j = 0; j < width; j++) 
			{
				float x = startX + j * spacing;
				float y = startY + i * spacing;


				Vector3 newPos = new Vector3 ((int)x, (int)y, 0);

				/*if (arr_map [i, j] == 0) 
				{
					GameObject object_land =  Instantiate (arr_prefab_tiles[0]);
					object_land.transform.name = "land" + i + j;
					object_land.transform.position = newPos;
					object_land.transform.parent = GameObject.Find("Land").transform;
				}
				if (arr_map [i, j] == 1) 
				{
					GameObject object_board =  Instantiate (arr_prefab_tiles[1]);
					object_board.transform.name = "Plate" + i + j;
					object_board.transform.position = newPos;
					object_board.transform.parent = GameObject.Find("Plate").transform;
				}
				if (arr_map [i, j] == 2) 
				{
					GameObject object_blood =  Instantiate (arr_prefab_tiles[2]);
					object_blood.transform.name = "blood_" + i + j;
					object_blood.transform.position = newPos;
					object_blood.transform.parent = GameObject.Find("Land").transform;
				}
				if (arr_map [i, j] == 3) 
				{
					GameObject object_rock =  Instantiate (arr_prefab_tiles[3]);
					object_rock.transform.name = "rock1_" + i + j;
					object_rock.transform.position = newPos;
					object_rock.transform.parent = GameObject.Find("Wall").transform;
				}*/

				//---------------arr_map [i, j] - это номер на карте
				GameObject object_element_maps =  Instantiate (arr_prefab_tiles[arr_map [i, j]]); //создаем обект из префаба с номером соответствующим номеру на карте
				object_element_maps.transform.name = arr_prefab_tiles[arr_map [i, j]].name + "_" + i + j; //присваиваем обекту имя состоящее из имени префаба и координат x и y
				object_element_maps.transform.position = newPos;//перемещаем префаб в соответствующее карте место
				if (arr_map [i, j] == 1) // если один то это не разрушаемые плиты
				{
					object_element_maps.transform.parent = GameObject.Find("Plate").transform;//делаем объект дочерним
				}
				if (arr_map [i, j] == 0 || arr_map [i, j] == 2) // если два или ноль то это типа земля или кровь на земле
				{
					object_element_maps.transform.parent = GameObject.Find("Land").transform;//делаем объект дочерним
				}
				if (arr_map [i, j] >= 3 && arr_map [i, j] <= 14) // если с 3 по 11 то это различные варианты стен
				{
					object_element_maps.transform.parent = GameObject.Find("Wall").transform;//делаем объект карты дочерним
					GameObject object_element_land =  Instantiate (arr_prefab_tiles[0]); //создаем обект земли из префаба который находится на всех участках карты(даже под стенами) с номером соответствующим номеру на карте
					object_element_land.transform.name = arr_prefab_tiles[0].name + "_" + i + j; //присваиваем обекту имя состоящее из имени префаба и координат x и y
					object_element_land.transform.position = newPos;//перемещаем префаб в соответствующее карте место
					object_element_land.transform.parent = GameObject.Find("Land").transform;//делаем объект карты дочерним
				}

					//строим пока в одном родителе
					/*GameObject map_object =  Instantiate (arr_prefab_tiles[arr_map [i, j]]);
					map_object.transform.name = "rock1_" + i + j;
					map_object.transform.position = newPos;
					map_object.transform.parent = GameObject.Find("Wall").transform;*/
					//board.transform.parent = Map.transform;


			}
		}
	}
}
