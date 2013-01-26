using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {

public Transform playerTransform;
public bool faceForward  = false;		// Match forward vector?
private Transform thisTransform ;
	
public Vector3 offset;
	

void Start ()
	{
		
		// Cache component lookup at startup instead of doing this every frame
		thisTransform = transform;
		playerTransform = GameBrain.Instance.leader.transform;
	}

void Update ()
	{
		thisTransform.position = new Vector3(
			playerTransform.position.x + offset.x, 
			playerTransform.position.y + offset.y, 
			playerTransform.position.z + offset.z);
	
		if (faceForward)
			thisTransform.forward = playerTransform.forward;
			
	}
}
