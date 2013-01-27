using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {

	float lastRecordedTime;
	Vector3 scale, reset;
	// Use this for initialization
	void Start () {
		lastRecordedTime = Time.timeSinceLevelLoad;
		scale = new Vector3(2.0f,0.0f,2.0f);
		reset = new Vector3(0.0f,0.0f,0.0f);
	}
	
	void FixedUpdate(){
		float currentTime = Mathf.Floor(Time.timeSinceLevelLoad);
		if(currentTime%1 == 0 && currentTime != lastRecordedTime){
			lastRecordedTime = currentTime;
			transform.localScale =  reset;
			GetComponent<Light>().range = reset.x;
		}
		else {
			transform.localScale += scale;
			GetComponent<Light>().range +=scale.x;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
