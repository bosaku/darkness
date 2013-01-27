using UnityEngine;
using System.Collections;


public class GameBrain : MonoBehaviour {
	
	public GameObject leader;
	public GameObject PlayerPrefab;
	public bool ready = false;
	public bool playerGoal = false;
	public bool playerButtonClick = false;
	public PlayerMove playerMove;
	
	public GameObject SpeechGroup;
	public UILabel SpeechLabel;
	public UISprite SpeechBG;
	
	public GameObject StartMenu;
	public GameObject LevelMenu; //between scenes
	public GameObject EndGameMenu;
	public GameObject DeathMenu;
	
	GameObject Torch;
	public GameObject TorchPrefab;
	
	delegate void FState();
 	FState stateMethod;
	
	FadeTransition fade;
	
	public int SceneNumber = 0;
	
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
	
	
	void PlayButtonClick()
	{
		Debug.Log("Click");
		playerButtonClick = true;
		//yield return new WaitForEndOfFrame();
		
	}
	
	void Start()
	{
		fade = gameObject.GetComponent<FadeTransition>();
		Debug.Log("Start");
		stateMethod = new FState(WaitForPlayButton);
		fade.Sprite.gameObject.SetActive(true);
		fade.ImmediateOpaque();
		
		stateMethod = new FState(WaitForPlayButton);
		DisplayStartMenu();
		
	}
	
	void Start2()
	{
		stateMethod = new FState(WaitForPlayButton);
		DisplayLevelMenu();
	}
	
	void FixedUpdate()
	{
		stateMethod();
		
		//Debug.Log("Fixed");
	}
	
	void NullState()
	{
		
	}
	
	void DisplayLevelMenu()
	{
		LevelMenu.SetActive(true);
	}
	
	void DisplayStartMenu()
	{
		StartMenu.SetActive(true);
	}
	
	//Display Start Menu, wait for player to hit play button, reset play bool
	void WaitForPlayButton()
	{
		Debug.Log("Waiting for play button");
		
		//Display 
		if(playerButtonClick)
		{
			StartMenu.SetActive(false);
			playerButtonClick = false;
			Randomize();
			stateMethod = new FState(RandomizeFinished);
		}
	}
	

	
	//Start Randomizer, and wait for 'ready' bool, then init level
	void Randomize()
	{
		Debug.Log("Randomize");	
		GameObject.Find("Randomizer").GetComponent<Randomize>().StartRandomizing();
	}
	
	void RandomizeFinished()
	{
		if(ready)
		{
			if(fade.ToTransparent())
			{
				InitLevel();
				stateMethod = new FState(WaitForGoal);
				stateMethod();
			}
		}
	}
	
	//Find player spawn, find goal spawn, drop player, drop end, update radar, reset dark (start), fade transition
	void InitLevel()
	{
		Vector3 p = GameObject.Find("SpawnPlayer").transform.position;
		leader = GameObject.Instantiate(PlayerPrefab, p, Quaternion.identity) as GameObject;
		playerMove = leader.GetComponent<PlayerMove>();
		
		Quaternion q = Quaternion.Euler(-90,0,0);
		Vector3 p2 = GameObject.Find ("SpawnEndPoint").transform.position;
		Torch = GameObject.Instantiate(TorchPrefab, p2,q) as GameObject;
	}
	
	void WaitForGoal()
	{
		if(playerGoal == true)
		{
			
		}
	}
	
	void PlayerDrop()
	{
		GameObject ps =  GameObject.Find("PlayerSpawn");
		
		//Debug.Log("DROP");
		//DROP PLAYER AND FRIENDS
		SpeechGroup.SetActive(true);
		SpeechLabel.text = "It is getting dark... lets go!";
		
		//yield return new WaitForSeconds(1.5);
	}
	
	//When Player hits goal, add total score, reset level score, transition opaque, display level complete, wait for player button, reset player
	void PlayerGoal()
	{
		
	}
	
//	void PlayerDrop2()
//	{}
	

	#region GLOBAL REFS
	
	
	#endregion
}
