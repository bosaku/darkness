using UnityEngine;
using System.Collections;

public enum GameStates {startmenu, transition }

public class GameBrain : MonoBehaviour {
	
	public GameObject leader;
	public bool ready = false;
	public PlayerMove playerMove;
	public GameStates gameState;
	
	public GameObject SpeechGroup;
	public UILabel SpeechLabel;
	public UISprite SpeechBG;
	
	delegate void FState();
 	FState stateMethod;
	
	public GameObject PlayerPrefab;
	
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
	
	void Start()
	{
		Debug.Log("Start");
		stateMethod = new FState(NullState);
		FadeTransition.Instance.Sprite.gameObject.SetActive(true);
		FadeTransition.Instance.ImmediateOpaque();
		
	}
	
	void FixedUpdate()
	{
		stateMethod();
		
		//Debug.Log("Fixed");
	}
	
	void NullState()
	{
		if(ready)
		{
			if(FadeTransition.Instance.ToTransparent())
			stateMethod = new FState(PlayerDrop);
		}
	}
	
	void StartMenu()
	{
		
	}
	
	
	void PlayerDrop()
	{
		//Debug.Log("DROP");
		//DROP PLAYER AND FRIENDS
		SpeechGroup.SetActive(true);
		SpeechLabel.text = "It is getting dark... lets go!";
	}
	

	#region GLOBAL REFS
	
	
	#endregion
}
