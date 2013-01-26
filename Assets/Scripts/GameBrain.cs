using UnityEngine;
using System.Collections;

public class GameBrain : MonoBehaviour {
	
	public GameObject leader;
	public bool release = false;
	public PlayerMove playerMove;
	public static GameBrain Instance;
	void Awake() {
		//Debug.Log("Awake");
		if (!GameBrain.Instance) {
			Instance = this;
		} else {
			DestroyImmediate(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
	
	
	#region GLOBAL REFS
	
	
	#endregion
}
