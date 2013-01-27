using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadarSingle : MonoBehaviour {
	
	public static RadarSingle Instance;
	List<Transform> Enemies;
	List<Transform> Friends;
	List<UISprite> EnemyBlips;
	public GameObject enemyBlip;
	public GameObject friendBlip;
	public Transform RadarCluster;
	
	void Awake()
	{
		if (!RadarSingle.Instance) {
			Instance = this;
		} else {
			Destroy(gameObject);
			return;
		}
		
		Enemies = new List<Transform>();
		Friends = new List<Transform>();
		EnemyBlips = new List<UISprite>();
	}
	
	public void AddEnemy(Transform enemy)
	{
		Enemies.Add(enemy);
		
		GameObject newBlip = Instantiate(enemyBlip) as GameObject;
		Vector3 origScale = newBlip.transform.localScale;
		newBlip.transform.parent = RadarCluster.transform;
		newBlip.transform.localScale = origScale;
		newBlip.GetComponent<BlipBehave>().FollowTransform = enemy;
		newBlip.transform.rotation = new Quaternion(0,0,0,0);
		//Find a disabled blip. If there is no disabled blip, create a new blip and add to EnemyBlips
//		foreach(UISprite b in EnemyBlips)
//		{
//			if(!b.enabled)
//			{
//				
//			}
//			else {
//				GameObject newBlip = Instantiate(enemyBlip) as GameObject;
//				newBlip.GetComponent<BlipBehave>().FollowTransform = blip;
//			}
//		}
		
	}
	
	
	
	
	
	
}
