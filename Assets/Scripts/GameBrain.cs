using UnityEngine;
using System.Collections;


public class GameBrain : MonoBehaviour {
	
	public GameObject leader;
	public GameObject PlayerPrefab;
	public bool ready = false;
	public bool playerGoal = false;
	public bool playerButtonClick = false;
	public PlayerMove playerMove;
	
	public UILabel LevelNumber;
	public UILabel TotalScore;
	public UILabel LevleScore;
	
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
	
	void OnDeath()
	{
		EndGameMenu.SetActive(true);
		
		
	}
	
	//Button Click
	void OnResetScene()
	{
		stateMethod = new FState(ResetState);
		
		InitLevel();
		
	}
	
	//This needs to go on for a while
	void ResetState()
	{
		fade.FadeIn();
		
	}
	
	void PlayButtonClick()
	{
		Debug.Log("Click");
		playerButtonClick = true;
		StartMenu.SetActive(false);
		LevelMenu.SetActive(false);
		//yield return new WaitForEndOfFrame();
		
	}
	
	void Start()
	{
		LevelNumber.text = (SceneNumber + 1).ToString();
		if(SceneNumber == 0)
		{
			fade = gameObject.GetComponent<FadeTransition>();
			Debug.Log("Start");
			stateMethod = new FState(WaitForPlayButton);
			fade.Sprite.gameObject.SetActive(true);
			fade.ImmediateOpaque();
			
			stateMethod = new FState(WaitForPlayButton);
			DisplayStartMenu();
		}
		if(SceneNumber >= 1 && SceneNumber != 4)
		{
			Debug.Log("Start scene 2 - 3");
			stateMethod = new FState(WaitForPlayButton);
			fade.ImmediateOpaque();
			
			Application.LoadLevel(SceneNumber);
			//DisplayLevelMenu();
		}
		if(SceneNumber == 4)
		{
			Debug.Log("Start scene 4");
			fade.ImmediateOpaque();
			EndGameMenu.SetActive(true);
		}	
		
	}
	
	IEnumerator CloseBubble()
	{
		Debug.Log("CLose");
		yield return new WaitForSeconds(2);
		SpeechGroup.SetActive(false);
		SpeechBG.enabled = false;
		SpeechLabel.enabled = false;
	}
	
//	void Start2()
//	{
//		stateMethod = new FState(WaitForPlayButton);
//		fade.ImmediateOpaque();
//		SceneNumber++;
//		Application.LoadLevel(SceneNumber);
//		DisplayLevelMenu();
//	}
	
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
		
		RadarSingle.Instance.AddEnemy(Torch.transform);
		SpeechGroup.SetActive(true);
		StartCoroutine("CloseBubble");
		SpeechLabel.text = "Why is it getting dark so suddenly.. oh my gosh!";
	}
	
	void WaitForGoal()
	{
		if(playerGoal == true)
		{
			playerGoal = false;
			SceneNumber++;
			Destroy(leader);
			Destroy(Torch);
			DestroyRandomizedObjects();
			DisplayLevelMenu();
			Start ();
		}
	}
	
	void DestroyRandomizedObjects()
	{
		Destroy(GameObject.Find("AllRocks"));
		Destroy(GameObject.Find("AllVeg"));
		Destroy (GameObject.Find("AllTrees"));
	}
	
	void PlayerDrop()
	{
		GameObject ps =  GameObject.Find("PlayerSpawn");
		
		Debug.Log("DROP");
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
