using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoadObjects : MonoBehaviour
{


	public float speed = 100f; //cube
	public float speed1 = 100f; //sphere
	public float speed2 = 100f; //cylinder

	public PhysicMaterial bounceMat;




	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown("space"))
		{
			LoadOBJS();
		}
	
	}



	void LoadOBJS()
	{
		int i = Random.Range(1, 4); //in random range :max is exluded ,practically we'll get results from 1 to 3
		switch (i)
		{
			case 1:
				makeSphere();
				break;
			case 2:
				makeCube();
				break;
			case 3:
				makeCylinder();
				break;
		}
	}


	void makeSphere()
	{
		int i = Random.Range(1, 11); //random size between 1 and 10
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3(i, i, i);
		sphere.transform.position = new Vector3(i + 2f, i + 2f, i + 2f);
		sphere.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); //random color 

		SphereCollider SC = sphere.AddComponent<SphereCollider>();
		Rigidbody rb1 = sphere.AddComponent<Rigidbody>();
		rb1.GetComponent<Rigidbody>().useGravity = false;
		float vx1 = Random.Range(0.1f, 0.9f);
		float vy1 = Random.Range(0.1f, 0.9f);
		float  vz1 = Random.Range(0.1f, 0.9f);

		if(i==1 || i==2){
			rb1.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
		Vector3 direction1 = new Vector3(vx1, vy1, vz1);

		rb1.AddForce(direction1 * speed1, ForceMode.Impulse);

		GetComponent<Collider>().material = bounceMat;

	}



	void makeCylinder()
	{
		int j = Random.Range(1, 11);
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.localScale = new Vector3(j, j, j);
		cylinder.transform.position = new Vector3(j + 2f, j + 2f, j + 2f);
		cylinder.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

		CapsuleCollider CC = cylinder.AddComponent<CapsuleCollider>();
		Rigidbody rb2 = cylinder.AddComponent<Rigidbody>();
		rb2.GetComponent<Rigidbody>().useGravity = false;

		float vx2 = Random.Range(0.1f, 0.9f);
		float vy2 = Random.Range(0.1f, 0.9f);
		float vz2 = Random.Range(0.1f, 0.9f);


		if(j==1 || j==2){
			rb2.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
		Vector3 direction2 = new Vector3(vx2, vy2, vz2);

		rb2.AddForce(direction2 * speed2, ForceMode.Impulse);

		GetComponent<Collider>().material = bounceMat;

	}
	void makeCube()
	{

		int k = Random.Range(1, 11);
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3(k, k, k);
		cube.transform.position = new Vector3(k + 2f, k + 2f, k + 2f);
		cube.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


		BoxCollider BC = cube.AddComponent<BoxCollider>();
		Rigidbody rb = cube.AddComponent<Rigidbody>();
		rb.GetComponent<Rigidbody>().useGravity = false;
		float vx = Random.Range(0.1f, 0.9f);
		float vy = Random.Range(0.1f, 0.9f);
		float vz = Random.Range(0.1f, 0.9f);
		 
		if(k==1 || k==2){
			rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
		}
		Vector3 direction = new Vector3(vx, vy, vz);
		rb.AddForce(direction * speed, ForceMode.Impulse);

		//bounce with other objects(bonus iii)
		GetComponent<Collider>().material = bounceMat;

	}


/*
	void OnCollisionEnter(Collision collision)
	{
		//COLLISION ANGLE
		var orthogonalVector = collision.contacts[0].point - transform.position;
		float collisionAngle = Vector3.Angle(orthogonalVector, rb.velocity);


	}
*/



}

