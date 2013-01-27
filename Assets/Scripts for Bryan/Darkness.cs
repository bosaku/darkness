using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour {
		
	public static State currentState;
	Vector3 MAX;
	Vector3 MIN;
	static Vector3 v;
	public static Vector3 scale;
	public static bool darkConsume;
	
	public Vector3 oldPosition, currentPosition;
	
	// Use this for initialization
	public void Start () {
		MAX = new Vector3(20.0f,0.0f,20.0f);
		MIN = new Vector3(1.0f,1.0f,1.0f);
		currentState = State.DECREASE;
		v = new Vector3(0.5f,0.0f,0.5f);
		darkConsume = false;
	
	}
	
	void FixedUpdate(){
		
		currentPosition = transform.position;
		
		if(currentPosition == oldPosition)
			Darkness.expand();
			
			switch(currentState){
			case State.INCREASE:
					//vector3(x,y,z)
			if(transform.localScale.x < MAX.x)
					transform.localScale += v;
					break;
			case State.DECREASE:
				if(transform.localScale.x > MIN.x)
					transform.localScale -= v;
					break;
			case State.STABLE:
					break;
			}
		
		if(transform.localScale.x <= MIN.x);
			darkConsume = true;
		
		oldPosition = transform.position;
		scale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {

	}
	public static void expand(){
		currentState = State.DECREASE;
	}
	
	public static void contract(){
		currentState = State.INCREASE;
	}
	
	public static void stable(){
		currentState = State.STABLE;
	}
	
	public static void setRate(float newRate){
		v.x = newRate;
		v.y = newRate;
		v.z = newRate;
	}
	
	public static void setRateX(float newRate){
		v.x = newRate;
	}
	
	public static void setRateY(float newRate){
		v.y = newRate;
	}
	
	public static void setRateZ(float newRate){
		v.z = newRate;
	}
	
	public static Vector3 getScale(){
		return scale;
	}



}
