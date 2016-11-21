using UnityEngine;
using System.Collections;

public class GanerateMap : MonoBehaviour {

	public int width;
	public int heigth;
	public string seed;
	public bool UseRandomSeed;

	[Range(0,100)]
	public int RandomFillPercent;

	private int[,] map;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GanMap()
	{
		map = new int[width,heigth];
	}

	void RandomFillMap()
	{
		if (UseRandomSeed == true) 
		{
			seed = Time.time.ToString ();//заносим время и сразу переводим в строку
		}

		System.Random pseudoRandom = new System.Random (seed.GetHashCode ()); //извлекая из переменной seed его хэшкод

		for (int x = 0; x < width; x++) 
		{
			for (int y = 0; y < heigth; y++) 
			{
				if ((x == 0) || (x == width - 1) || (y == 0) || (y == heigth - 1)) 
				{
					map [x, y] = 1;
				} 
				else 
				{
						if (pseudoRandom.Next(0,100) < RandomFillPercent)
						{
							map[x,y] = 1;
						}
						else
						{
							map[x,y] = 0;
						}
				}
			}
		}
			
	}
}
