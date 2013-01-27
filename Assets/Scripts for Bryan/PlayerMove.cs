using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	

	public NavMeshAgent navAgent;
	float speed;
	public CharacterController characterController;
	Transform myTransform;
	public float SecondsWaitTilResume = .5f;
	public LayerMask ignoreTheseColliders;
	public LayerMask slideAgainstTheseColliders;
	public LayerMask winWithTheseColliders;

	public Vector3 lastClick = new Vector3(0.0f,0.0f,0.0f);
	
	void Start()
	{
		myTransform = transform;
		speed = navAgent.speed;
		characterController = GetComponent<CharacterController>();
	}
	
	public void BeginPathfind(Vector3 point)
	{	
		navAgent.SetDestination(point);
		if( Vector3.Distance(transform.position, point) < 3){
			Debug.Log("last click :" + Vector3.Distance(lastClick,point));
			Darkness.expand();
			
		}

		else {
			Debug.Log ("moving");
			Darkness.contract();
		}
		
		lastClick = point;
		
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
		{   
			Debug.Log(hits.Length);
			if(c.gameObject.layer == winWithTheseColliders)
			{
				Debug.Log("WIN WIN WIN");
				GameBrain.Instance.playerGoal = true;
			}
			if(c.gameObject.layer == slideAgainstTheseColliders)
			{
				Debug.Log("SLIDE");
			}
			if(c.gameObject.layer != slideAgainstTheseColliders && c.gameObject.layer != winWithTheseColliders)
			{
				i++;
				if(i >= 1 && c.name != "Player" ) //Add a cut off to diminish the times when hitting the rock at slow speed. If slow, don't lerp back, just slide. 
					LerpBack(c);
			}
			//if slow
			//Slide 
			if(Darkness.darkConsume){
				Debug.Log("You Lose");
			}
			
		}
		
		
	}
	
	void LerpBack(Collider c)
	{
		Vector3 newPos = c.transform.position - myTransform.position;
		Vector3 secondPos = Vector3.forward - newPos;
		characterController.Move(secondPos);
		//iTween.MoveTo(gameObject, secondPos, .3f);
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
