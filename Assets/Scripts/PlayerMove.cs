using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	

	public NavMeshAgent navAgent;
	
	public void BeginPathfind(Vector3 point)
	{
	
		
		navAgent.SetDestination(point);
	}
	
}
