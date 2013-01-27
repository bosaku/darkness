using UnityEngine;
using System.Collections;

public class RandomlyCreatedObject : MonoBehaviour {
	public bool grounded = false;
	Transform myTransform;
	void Start()
	{
		myTransform = transform;
	}
	
	public Randomize creator;
	void OnCollisionEnter()
	{
		//renderer.material.color = Color.red;
	}
	
	float t = 0;
	void Update()
	{
		if(myTransform.position.y < -2 && t <= 2 ) //They get 3 chances
		{
			creator.ReRandomize(gameObject);
			t++;
		}
		else if(t > 2)
			Destroy(gameObject);
			//Add To pool
//		
//		t += Time.deltaTime * 1;
//		Debug.Log(t);
//		
//		if(t >= 3)
//		{
//			//Destroy(gameObject);
//		}
		
	}
	
	void OnCollisionExit(Collision c)
	{
		if(c.gameObject.layer == 8)
		{
			grounded = false;
		}
	}
	
	void OnCollisionStay(Collision c)
	{
		//Debug.Log(" collided with : " + c.gameObject.layer.ToString());
		
		if( c.gameObject.layer == 8)
		{
			grounded = true;
		}
		//Debug.Log(c.gameObject.layer.ToString());
		if( c.gameObject.layer == 11)
		Destroy(gameObject);
		
		if(c.gameObject.name == "Player")
		{
			Destroy(gameObject);
		}
	}
}
