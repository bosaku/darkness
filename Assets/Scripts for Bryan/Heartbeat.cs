using UnityEngine;
using System.Collections;

// Heartbeat
// Resting rate - when light is at minimum light option
// Pulse rate - when the 

[RequireComponent(typeof(AudioSource))]

public class Heartbeat : MonoBehaviour {

	
	// Light values
	float intensityMax;
	float intensityMin;
	float intensityDelta;
	float ambientLightMax;
	float ambientLightMin;
	float ambientLightDelta;
	
	
	//Timing Values

	float SLOWEST_RATE_DELAY;
	float FASTEST_RATE_DELAY;
	float currentRateDelay;
	float timeSinceLastBeat;
	
	static State myState;
	
	// Use this for initialization
	public void Start () {
		
		audio.pitch = 1.4f;
		
		intensityMax = 8f;
		intensityMin = 0f;
		intensityDelta = 1.5f;
		ambientLightMax = 255;
		ambientLightMin = 0;
		ambientLightDelta = 5;
		
		
		//Timing Values
		
		SLOWEST_RATE_DELAY = 10.0f;
		FASTEST_RATE_DELAY = 0.80f;
		currentRateDelay = 2.00f;
		timeSinceLastBeat = 0;
		
		//RenderSettings.ambientLight = Color.red;	
		
		// For testing purposes, start lighting at the max
		GetComponent<Light>().intensity = intensityMax;
		//RenderSettings.ambientLight = new Color(ambientLightMax, 0, 0);
		
		myState = Darkness.currentState;
	}
	
	// Update is called once per frame
	
	void FixedUpdate(){
		myState = Darkness.currentState;
		GetComponent<Light>().range =  Darkness.getScale().x;

		if (timeSinceLastBeat >= currentRateDelay && myState == State.INCREASE) {
		//	Debug.Log ("THA-THUMP!!!!");
			Pulse (true);
			timeSinceLastBeat = 0.0f;
		}
		else
		{
			Pulse (false);
			timeSinceLastBeat += 0.1f;
		}

		if (timeSinceLastBeat >= currentRateDelay && myState == State.DECREASE) {
		//	Debug.Log ("THA-THUMP!!!!");
			Pulse (true);
			timeSinceLastBeat = 0.0f;
		}
		else
		{
			Pulse (false);
			timeSinceLastBeat += 0.1f;
		}
		

		

		
			switch (myState) {
				case State.INCREASE:
		    	currentRateDelay -= 0.1f;
		//	Debug.Log("In Increase: " + currentRateDelay);
				break;
		
		// if player is moving slower
				case State.DECREASE:
		//	Debug.Log("In Decrease: " + currentRateDelay);
				currentRateDelay += 0.1f;
				break;
			
		// if player is moving at a constant speed
				case State.STABLE:
				break;
			}
		if (currentRateDelay > SLOWEST_RATE_DELAY) {
			currentRateDelay = SLOWEST_RATE_DELAY; 
		}
		if (currentRateDelay < FASTEST_RATE_DELAY) {
			currentRateDelay = FASTEST_RATE_DELAY;
		} 
		
		
/*		if ( blah == 0 ) {
			Pulse(true);
			blah = 30;
		}
		else {
			blah--;
			Pulse (false);
		}*/	
	
	}
	void Update () {

	}
	
	// If singal for beat is received, intensify the light
	void Pulse(bool beat) {
		if (beat) {
			// Adjust the intensity of the light (brighter)
			//if ( GetComponent<Light>().intensity < intensityMax + intensityDelta) {
			//	GetComponent<Light>().intensity += intensityDelta;
			//}
			GetComponent<Light>().intensity = intensityMax;
			
			// Adjust the ambient light
			//float ambientLightCur = RenderSettings.ambientLight.r;
			//if (ambientLightCur < ambientLightMax + ambientLightDelta ) {
			//	RenderSettings.ambientLight = new Color(ambientLightCur+ambientLightDelta, 0, 0);
			//}
		//	RenderSettings.ambientLight = new Color(ambientLightMax, 0, 0);
			
			audio.Play();

		}
		// No signal for heartbeat, so gradually decrease light intensity
		else {
			// Adjust the intensity of the light (darker)
			float intensityCur = GetComponent<Light>().intensity;
			if ( intensityCur - intensityDelta  > intensityMin ) {
				GetComponent<Light>().intensity -= intensityDelta;
			}
			
			// Adjust the ambient light
		/*	float ambientLightCur = RenderSettings.ambientLight.r;
			Debug.Log ("In pulse false: " + ambientLightCur + " and ambientMin: " + ambientLightMin);
			if (ambientLightCur - ambientLightDelta > ambientLightMin  ) {
				Debug.Log ("Ambient Delta:" + (ambientLightDelta-ambientLightCur));
			//	RenderSettings.ambientLight = new Color(ambientLightCur-ambientLightDelta, 0, 0);
				
			
			}*/
		}
	}
	
	public void reset(){

	}
	
	
}