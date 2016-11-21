using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class GanerateMap2 : MonoBehaviour {
	public int size_x;
	public int size_y;

	public float tileSize = 1.0f; //размер одной ячейки на карте

	public Texture2D terrainTiles;
	public int tileRezolution;

	public GameObject mpg;



	// Use this for initialization
	void Start () 
	{
		//BuildMesh ();
		//BuildTexture ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*BuildMesh ()
	{
		int vsize_x = size_x+1;//кол-во вертексов по x всегда больше на один
		int vsize_y = size_y+1;//кол-во вертексов по y всегда больше на один
		int numVerts = vsize_x * vsize_y;// кол-во вертексов соответствует vx * vy
		int numTiles = size_x * size_y;//кол-во тайлов соответствует размеру карты x*y
		int numTris = numTiles * 2;//кол-во треугольниоков которых всегда в 2 раза больше чем тайлов, т.к. в одном тайле 2 треугольника

		//генерация мэш дата
		Vector3[] Vertices = new Vector3[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		Vector3[] uv = new Vector3[numVerts];

		int [] triangles = new int[numTris * 3];
		int x,z;

		for(z=0; z<vsize_z; z++)
		{
			for (x=0; x<vsize_x; x++)
			{
				
			}
		}


		//создание мэша
		Mesh mesh = new Mesh();
		Mesh.vertices = vertices;
		Mesh.triangles = triangles;
		Mesh.normals = normals;
		Mesh.uv = uv;



		//Обявление рендера, фильтра и коллайдера
		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
		MeshCollider mesh_collider = GetComponent<MeshCollider>();

		mesh_filter.mesh = mesh;
			
	}*/


}
