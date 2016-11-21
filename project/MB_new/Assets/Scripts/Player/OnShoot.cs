using UnityEngine;
using System.Collections;

public class OnShoot : MonoBehaviour {
	public enum OPTIONS
	{
		LeftControl = 0,
		RightControl = 1,	
	}
	public OPTIONS Button_Fire;

	public GameObject Particle_System;
	public GameObject target;
	public GameObject bullet;

	public int speed_bullet;
	public float Time;

	private float offset = 0.1f;
	private int direction;
	private GameObject [] gos;//массив обектов для поиска созданного оружия на карте
	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update ()
	{
		/*gos = GameObject.FindGameObjectsWithTag ("Gun");
		foreach (GameObject tr in gos)//Для каждого объекта в массиве gos (к объекту будем обращаться как tr).
		{	
			//Debug.Log (tr.transform.rotation.z + 10);
			tr.transform.rotation = Quaternion.Euler(0, 0,  tr.transform.rotation.z += 10);;
		}*/
		if (Button_Fire == OPTIONS.RightControl) 
		{
			if (Input.GetKeyDown(KeyCode.RightControl))
			{

				OnKeyContrl ();
			}
		}

		if (Button_Fire == OPTIONS.LeftControl) 
		{
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{

				OnKeyContrl ();
			}
		}

	}

	public void OnKeyContrl()
	{


		if (bullet.name == "Axe") 
		{
			if (this.GetComponent<Rigidbody2D> ().transform.rotation.eulerAngles.z == 0) {
				GameObject newBullet = Instantiate (bullet);
				newBullet.transform.position = new Vector2 (target.transform.position.x + 0.2f, target.transform.position.y);
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed_bullet, 0);

				GameObject newParticle = Instantiate (Particle_System);
				newParticle.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				Destroy (newParticle, Time);
				//Debug.Log(transform.localPosition.y);
			}
			if (this.GetComponent<Rigidbody2D> ().transform.eulerAngles.z == 180) {
				GameObject newBullet = Instantiate (bullet);
				newBullet.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed_bullet * (-1), 0);

				GameObject newParticle = Instantiate (Particle_System);
				newParticle.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				Destroy (newParticle, Time);
				//Debug.Log("Popali v uslovie");
			}
			if (this.GetComponent<Rigidbody2D> ().transform.eulerAngles.z == 90) {
				Debug.Log (gameObject.name);
				GameObject newBullet = Instantiate (bullet);
				newBullet.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed_bullet);

				GameObject newParticle = Instantiate (Particle_System);
				newParticle.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				Destroy (newParticle, Time);
				//Debug.Log("Popali v uslovie");
			}
			if (this.GetComponent<Rigidbody2D> ().transform.eulerAngles.z == 270) {
				GameObject newBullet = Instantiate (bullet);
				newBullet.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				newBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed_bullet * (-1));

				GameObject newParticle = Instantiate (Particle_System);
				newParticle.transform.position = new Vector2 (target.transform.position.x, target.transform.position.y);
				Destroy (newParticle, Time);
				//newParticle.GetComponent<Renderer> ().sortingLayerName = "Default";
				//newParticle.GetComponent<Renderer> ().sortingOrder = 1;
				//Debug.Log(target.transform.position.x);
			}
		}
		if (bullet.name == "Dynamit") 
		{
			
				GameObject newBullet = Instantiate (bullet);
				newBullet.transform.position = new Vector2 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y));
				
		}
		//Debug.Log (target.transform.position.y);

	}
}
