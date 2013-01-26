using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour {
	
	public static Brain Instance;
	void Awake() {
		//Debug.Log("Awake");
		if (!Brain.Instance) {
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
