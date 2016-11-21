using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public Vector3[] point ;
	[SerializeField]
	private Vector3 PositionDestination;
	private int i = 0;
	private Vector3 Direction;
	// Use this for initialization
	void Start () {
		


		
	}

	// Update is called once per frame
	void Update () 
	{
		//if (Input.GetKey (KeyCode.Space)) 
		//{
		//transform.Translate (0, 0.1f, 0);	
		//transform.Translate(Vector3.Normalize(new_poz)*1 );
		PositionDestination = point[i];
		Direction = Vector3.Normalize (PositionDestination - transform.position);
		//transform.LookAt (PositionDestination);
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), 1 * Time.deltaTime); 
		//this.transform.eulerAngles = PositionDestination - transform.position;
		//Debug.Log( Vector3.Normalize(PositionDestination-transform.position));
		//Debug.Log (this.transform.rotation.eulerAngles);

		float distance = Vector3.Distance (PositionDestination, transform.position);
		//Debug.Log( distance);
		if (distance <= 0.01f) 
		{
			if (i < point.Length - 1) {
				i++;
			}
			else 
			{
				//this.GetComponent<Rigidbody2D> ().velocity = new Vector3(0,0,0); //остановка в конечной точке
				i=0;//запускаем заново хождение по точкам
			}
		} 
		else 
		{
			//кое как завращал обект но как то каряво получается, обект застревает при повороте
			/*Vector3 moveDirection = PositionDestination - transform.position; 
			if (moveDirection != Vector3.zero) 
			{
				float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}*/

			this.GetComponent<Rigidbody2D> ().velocity = Vector3.Normalize(PositionDestination-transform.position)*2;


		}
	}

		//}
		
	
}
