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
		//playerTransform = GameBrain.Instance.leader.transform;
	}

void Update ()
	{
		if(GameBrain.Instance.leader)
		{
			thisTransform.position = new Vector3(
				GameBrain.Instance.leader.transform.position.x + offset.x, 
				GameBrain.Instance.leader.transform.position.y + offset.y, 
				GameBrain.Instance.leader.transform.position.z + offset.z);
			
			if (faceForward)
				thisTransform.forward = GameBrain.Instance.leader.transform.forward;
		}
		
			
	}
}
