using UnityEngine;
using System.Collections;

public class BlipBehave : MonoBehaviour {

	Transform myTransform;
	public Transform FollowTransform;
	
	void Start()
	{
		myTransform = transform;
	}
	
	void Update()
	{
		if(FollowTransform !=null)
		{
			myTransform.localPosition = FollowTransform.position - GameBrain.Instance.leader.transform.position;
		}
		else 
		{
			gameObject.SetActive(false);
		}
	}
}
