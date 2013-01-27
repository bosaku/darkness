using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	

	public NavMeshAgent navAgent;
	float speed;
	public CharacterController characterController;
	Transform myTransform;
	public float SecondsWaitTilResume = .5f;
	public LayerMask ignoreTheseColliders;
	
	void Start()
	{
		myTransform = transform;
		speed = navAgent.speed;
		characterController = GetComponent<CharacterController>();
	}
	
	public void BeginPathfind(Vector3 point)
	{	
		navAgent.SetDestination(point);
		
	}
	
	void Update()
	{
//		if(Physics.CapsuleCast(transform.position, transform.position, characterController.radius , transform.forward, characterController.radius))
//		{
//			navAgent.Stop();	
//		}
		Collider[] hits = Physics.OverlapSphere(transform.position, characterController.radius, ignoreTheseColliders);
		int i = 0;
		foreach(Collider c in hits)
		{   i++;
			if(i >= 1 && c.name != "Player")
			LerpBack(c);
			
		}
		
		
	}
	
	void LerpBack(Collider c)
	{
		Vector3 newPos = c.transform.position - myTransform.position;
		characterController.Move(Vector3.forward - newPos);
		navAgent.Stop(true);
		
		StartCoroutine(Resume());
//		Vector3 newPos = Vector3.zero;
//		newPos = newPos - myTransform.forward;
//		
//		Debug.Log("This transform : " + myTransform.position + "new transform : " + newPos);
	}
	
	IEnumerator Resume()
	{
		yield return new WaitForSeconds(SecondsWaitTilResume);
		navAgent.SetDestination(myTransform.position);
		navAgent.Resume();
	}
	
}
