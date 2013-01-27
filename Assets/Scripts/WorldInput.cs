using UnityEngine;
using System.Collections;

public class WorldInput : MonoBehaviour {
	
	
	GameBrain gameBrain;
	public Camera worldCamera;
	public LayerMask MovementMask;
	Vector3 endPos;
	Vector3 startPos;
	
	void Start()
	{
		gameBrain = GameBrain.Instance;
	}
	
	void Update()
	{
		MouseInput();
	}
	
	private void MouseInput () 
	{ 
		if(worldCamera)
		{
			
			if(Input.GetMouseButtonUp(0) )// && releaseControls) to prevent extra raycasting. Need to release controls from the UI Camera, with NGUI or whatever gets used. 
			{
				//Debug.Log("Button UP");
				Ray ray = worldCamera.ScreenPointToRay(new Vector3( Input.mousePosition.x, Input.mousePosition.y ) );
				
				RaycastHit hit ;
				if( Physics.Raycast(ray,out hit, 100, MovementMask) )
				{	
					endPos = hit.point;
					
//					if(gameBrain.playTutorial)
//					tutorial.lastTouchedThing = hit.collider.gameObject;
//					
//					if(SceneSpecific.Instance)
//					SceneSpecific.Instance.lastTouchedWorldThing = hit.collider.gameObject;
					
//					if(gestureAttack.attack == GestureAttack.Attacks.resting)
//					{
//						if(gestureAttack.CheckIfSwipe(startPos, endPos))
//						{
//							
//						}
//						else 
//						{
							if(gameBrain.leader)
							gameBrain.playerMove.BeginPathfind(hit.point);
							//PlaceDestinationMarker(hit.point);
							//GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
							//g.transform.position = hit.point;
						//}
		//			}
					
//					if (gestureAttack.attack == GestureAttack.Attacks.drawing)
//					{
//						gestureAttack.ReleaseDistance();
//					}
				}
			}
			
			//Mouse down
//			if(Input.GetMouseButtonDown(0) && gameBrain.release)
//			{
//				Ray ray = worldCamera.ScreenPointToRay(new Vector3( Input.mousePosition.x, Input.mousePosition.y ) );
//				//Debug.Log("button down");
//				RaycastHit hit ;
//				if( Physics.Raycast(ray,out hit, 100, MovementMask) )
//				{
//					//Debug.Log("Raycast hit" + hit.collider.tag);
//					startPos = hit.point;
//					
//					
////					if(gestureAttack.attack == GestureAttack.Attacks.resting && hit.collider.gameObject.tag == GameBrain.Instance.leader.name)
////					{
////						//initiate draw. Cancel draw if the change is not great enough
////						//Debug.Log("Begin draw..");
////						gestureAttack.BeginDrawState();
////						
////						//Start Drawing
////					}
//				}
//			}
			
			//Drawline
//			if(Input.mousePosition != startPos  && gameBrain.release && Input.GetMouseButton(0) )
//			{
//				Ray ray = worldCamera.ScreenPointToRay(new Vector3( Input.mousePosition.x, Input.mousePosition.y ) );
//				
//				RaycastHit hit ;
//				if( Physics.Raycast(ray,out hit, 200 , GestureMask) )
//				{
//					gestureAttack.CurrentTouchScreenPosition = hit.point;	
//					
//					if(DrawInfiniteLoopForFun)
//					{
//						DrawLine( hit.point);
//					}
//					//Draw
//				}
//			}
		}
	} 
	
}
