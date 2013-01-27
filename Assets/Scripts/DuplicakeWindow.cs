///// <summary>
///// DuplicakeWindow was created by Richard Bryan Irwin of Streamfall Interactive, whose website can be found at http://www.streamfall.com. I hope you enjoy using it!
///// </summary>
///// 
///// l#
///// 
///// 
//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//
//
//public enum CakeDirection {plusY, minusY, minusX, plusX, plusZ, minusZ, center};
//public enum CakeRotation {x,y,z};
//
//public class DuplicakeWindow : EditorWindow {
//	
//	
//	//All settings stored to the window object
//	public bool TransformAndDuplicate = false;
//	public bool UsePrecisionTransform = false;
//	public bool TransformAndRotate = false;
//	public bool MassTransform = false;
//	public float RotationPrecision = 10.0f;
//	public float transformPrecision = 0.1f;
//	public CakeRotation RotationAxis = CakeRotation.y;
//	public bool MassRotate = false;
//	
//	//static SeedSingle thing; 
//	static GameObject duplicake;
//	Object[] things;
//	Object blank;
//	CakeDirection direction;
//	
//	static DuplicakeWindow window;
//	//HOEditorUndoManager undoManager;
//	
//	void OnEnable()
//	{
//		//undoManager = new HOEditorUndoManager( blank, "Duplicake");
//	}
//	
//	[MenuItem ("Window/Duplicake Window")]
//	static void CreateWindow()
//	{
//		window = (DuplicakeWindow)EditorWindow.GetWindow(typeof (DuplicakeWindow));
//		
//		window.Focus();
//		
//	}
//	
//	
////	static void Init()
////	{
////		if(!GameObject.Find("Duplicake"))
////		{
////			duplicake = new GameObject("Duplicake");
////			
////			thing = duplicake.AddComponent<SeedSingle>();
////			thing.Awake();
////			
////		}
////	}
//	
//	Color32 green = new Color32(11,74,1,110);
//	Color32 red = new Color32(105,0,0,100);
//	Color32 tan = new Color32(232,224,167,200);
//	Color32 purple = new Color32(35,2,43,80);
//	Color32 blue = new Color32(5,3,84,150);
//	
//	public void OnGUI()
//	{	
//		
//		things = Selection.gameObjects;
//		
//		#region Transform
//		GUI.backgroundColor = tan;
//		
//		if(GUILayout.Button("Duplicate" ))
//		{
//			direction = CakeDirection.center;
//			int index = 0;
//			//Selections = new GameObject[Selection.gameObjects.Length];
//			
//			//Object[] objects = new Object[Selection.gameObjects.Length];
//			//Undo.RegisterUndo(objects, "the group duplicate");
//			//int i = 0;
//			foreach(GameObject go in Selection.gameObjects)
//			{
//				 Duplicate(go, direction, index);
//				//i++;
//				
////				Selection.objects = Selections;
//			}
//		}
//		
//		GUI.backgroundColor = purple;
//		
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		#region Transform Section
//		GUILayout.Label("Transform" );
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		GUI.backgroundColor = Color.white;
//		TransformAndDuplicate = GUILayout.Toggle(TransformAndDuplicate, "Transform and Duplicate");
//		
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		UsePrecisionTransform = GUILayout.Toggle(UsePrecisionTransform, "Use Precision");
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		
//		GUI.backgroundColor = Color.white;
//		transformPrecision= EditorGUILayout.FloatField("Precision :", transformPrecision, GUILayout.MinWidth(170));
//		
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		GUILayout.Label("Selected : "+ Selection.gameObjects.Length);
//		//MassTransform = GUILayout.Toggle(MassTransform, "Mass Transform");
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		GUI.backgroundColor = blue;
//		#region Transform -Z
//		if(GUILayout.Button("-Z"))
//		{
//			direction = CakeDirection.minusZ;
//			
//			DirectionalButton(direction);
//			
//		}
//		#endregion
//		GUI.backgroundColor = green;
//		
//		#region Transform +Y
//		if(GUILayout.Button("+Y"))
//		{
//			direction = CakeDirection.plusY;
//			
//			DirectionalButton(direction);
//			
//		}
//		#endregion
//		
//		GUI.backgroundColor = red;
//		
//		#region Transform -X
//		if(GUILayout.Button("-X"))
//		{
//			direction = CakeDirection.minusX;
//			
//			DirectionalButton(direction);
//			
//		}
//		#endregion
//		
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		GUI.backgroundColor = purple;
////		if(GUILayout.Button("Snap to Grid"))
////		{
//////			direction = DupDirection.center;
//////			
//////			Debug.Log("Snap me to grid, rounding my transform to a whole number");
////		}
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		GUI.backgroundColor = red;
//		
//		#region Transform +X
//		if(GUILayout.Button("+X"))
//		{
//			direction = CakeDirection.plusX;
//			
//			DirectionalButton(direction);
//			
//		}
//		#endregion
//		
//		GUI.backgroundColor = green;
//		
//		#region Transform -Y
//		if(GUILayout.Button("-Y"))
//		{
//			direction = CakeDirection.minusY;
//			
//			DirectionalButton(direction);
//			
//		}
//		#endregion
//		
//		GUI.backgroundColor = blue;
//		
//		#region Transform +Z
//		if(GUILayout.Button("+Z"))
//		{
//			direction = CakeDirection.plusZ;
//			
//			DirectionalButton(direction);
//		}
//		#endregion
//		
//		GUILayout.EndHorizontal();
//		
//		#endregion
//		
//		GUILayout.BeginHorizontal();
//		GUILayout.FlexibleSpace();
//		GUILayout.Label("Rotate" );
//		GUILayout.FlexibleSpace();
//		GUILayout.EndHorizontal();
//		
//		GUILayout.BeginHorizontal();
//		
//		GUI.backgroundColor = Color.white;
//		
//		#endregion
////		x = GUILayout.Toggle(x, "rotate x");
////		y = GUILayout.Toggle(y, "rotate y");
////		z = GUILayout.Toggle(z, "rotate z");
//
//		RotationAxis = (CakeRotation)EditorGUILayout.EnumPopup("Rotation Axis ",RotationAxis);
//		GUILayout.EndHorizontal();
//		//MassRotate = GUILayout.Toggle(MassRotate, "Rotate as a group or individually");
//		GUILayout.BeginHorizontal();
//		if(GUILayout.Button("-180"))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(-180f,  RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				
//				Rotate(-180, RotationAxis, item as GameObject);
//			}
//		}
//		if(GUILayout.Button("-45"))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(-45.0f, RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				
//				Rotate(-45, RotationAxis, item as GameObject);
//			
//			}
//		}
//		if(GUILayout.Button("45"))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(45.0f,RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				
//				Rotate(45, RotationAxis, item as GameObject);
//			
//			}
//		}
//		if(GUILayout.Button("180"))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(180.0f, RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				
//				Rotate(180, RotationAxis, item as GameObject);
//			}
//		}
//		GUILayout.EndHorizontal();
//		GUILayout.BeginHorizontal();
//		
//		if(GUILayout.Button("- :" + RotationPrecision))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(-RotationPrecision, RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				Rotate(-RotationPrecision, RotationAxis, item as GameObject);
//			}
//		}
//		RotationPrecision = EditorGUILayout.FloatField(RotationPrecision);
//		if(GUILayout.Button("+ :"+ RotationPrecision))
//		{
//			if(MassRotate)
//			{
//				MassRotateTool(RotationPrecision, RotationAxis);
//			}
//			else
//			foreach(Object item in things)
//			{
//				
//				Rotate(+RotationPrecision, RotationAxis, item as GameObject);
//			}
//		}
//		GUILayout.BeginHorizontal();
//		GUILayout.EndHorizontal();
//		
//		GUI.backgroundColor = Color.white;
//		
//		
//	
//	
////		if (GUI.changed)
////		{
////			Debug.Log("GUI Changed");
//////     		Undo.SetSnapshotTarget(target,target.name);
//////			Undo.CreateSnapshot();
////		}
//	
//	}
//	
//	public GameObject Selections;
//	GameObject Duplicate(GameObject go, CakeDirection direction, int index)
//	{
//	
//		Transform go_t = go.transform;
//		
//		GameObject next = Instantiate(go) as GameObject;
//		
//		Transform n_t = next.transform;
//		n_t.parent = go_t.parent;
//		n_t.position = go_t.position;
//		next.name = go.name;
//		
//		n_t.localScale = go_t.localScale;
//		
//		//Undo.RegisterUndo((GameObject)next, next.name + " creation");
//		
//		return next;
//
//	}
//	
////	public void Duplicate(CakeDirection direction)
////	{
////		size = GetTheSize();
////		
////		
////
////		next = Instantiate(gameObject) as GameObject;
////		next.name = gameObject.name + UnityEngine.Random.value;
////		//next.name = gameObject.name + UnityEngine.Random.value; // Hardcoded name plus a number
////		SeedScript ss = next.GetComponent<SeedScript>(); //Get the SeedScript component remotely
////		//ss.seed = seed;
////		ss.size = size;
////		//ss.snapValues.x = (float)Math.Truncate( transform.position.x);
////		//Debug.Log(ss.snapValues.x + "after split");
////		next.transform.localScale = transform.localScale;
////		
////		Selection.activeTransform = next.transform;
////
////		switch (direction)
////		{
////		case CakeDirection.plusY:
////			next.transform.Translate(new Vector3 (0,size.y,0),Space.World);
////			break;
////		case CakeDirection.minusY:
////			next.transform.Translate(new Vector3 (0,-size.y,0),Space.World);
////			break;
////		case CakeDirection.minusX:
////			next.transform.Translate(new Vector3 (- size.x,0,0),Space.World);
////			break;
////		case CakeDirection.plusX:
////			next.transform.Translate(new Vector3 ( + size.x,0,0),Space.World);
////			break;
////		case CakeDirection.plusZ:
////			next.transform.Translate(new Vector3 (0,0,+ size.z),Space.World);
////			break;
////		case CakeDirection.minusZ:
////			next.transform.Translate(new Vector3 (0,0,- size.z),Space.World);
////			break;
////		case CakeDirection.center:
////			next.transform.Translate(new Vector3 (0,0,0),Space.World);
////			break;
////		}
////		
////	}
//	
//	public Vector3 GetTheSize(GameObject go)
//	{
//		MeshFilter mf;
//		if(go.GetComponent<MeshFilter>())
//		{
//			mf= go.transform.GetComponent<MeshFilter>();
//		}
//		else if(go.GetComponentInChildren<MeshFilter>())
//		{
//			mf  = go.GetComponentInChildren<MeshFilter>();
//		}
//		else
//		{
//			Debug.Log("This GameObject has no MeshRenderer");
//			return new Vector3(0,0,0);
//		}
//		
//		Mesh mesh = mf.sharedMesh;
//		Vector3 meshSize = mesh.bounds.size;
////		if(go.GetComponent<Renderer>())
////		{
////			return go.renderer.bounds.size;
////		}
////		else{
////			return Vector3.up;
////		}
//		
//		
//	
//		return meshSize;
//		
//	}
//	 
//	void DirectionalButton(CakeDirection direction)
//	{
//		//should be able to transform and duplicate with precision and without. 
//			//should be able to transform and dupliate as a group and as a single.
//			//alternately
//			//should transform with precision or without
//			//should transform as group or as single
//			
//			//Debug.Log(thing.GetComponent<SeedScript>().TransformAndDuplicate.ToString());
//			//move a single item with precision or not
//		if(TransformAndDuplicate && !MassTransform)
//		{
//			if(UsePrecisionTransform)
//			{
//				Undo.RegisterSceneUndo(" precision duplicate.");
//				foreach(Object item in things)
//				{
//					Duplicate(item as GameObject, direction, 0); 
//				}
//				MoveThings(direction, transformPrecision);
//			}
//			//transform+duplicate without precision on single or multiple objects
//			else if(!UsePrecisionTransform) 
//			{
//				//Duplicate(direction);
//				
//				Undo.RegisterSceneUndo(" duplicate.");
//				foreach(Object item in things)
//				{
//					Duplicate (item as GameObject,direction,0);
//				}
//				MassMove(direction);
//			}
//			//thing.Duplicate(direction);
//		}//dupliate and move a single item with precision or not
//		if(!TransformAndDuplicate && !MassTransform)
//		{
//			if(UsePrecisionTransform)
//			{
//				int p = things.Length;
//				for(int c = 0 ; c <= p ; c++)
//				{
//					MoveThings(direction,transformPrecision);
//				}
//			}
//			//transform+duplicate without precision on single or multiple objects
//			else if(!UsePrecisionTransform) 
//			{
//				
//				//					foreach(Object item in things)
//				//					{
//				//MoveThings(direction);
//				//THIS SHOULD MOVE BASED ON THE MESH BOUNDS!
//				MassMove(direction);
//				//					}
//				
//			}
//		}
//		//Do not seem to need MassTransform anymore!
//		//move a mass of items without duplication with precision or not precision
////		if(MassTransform && !TransformAndDuplicate)
////		{
////			//if mass transformation and precision
////			if(UsePrecisionTransform)
////			{
////				MassMove(direction, transformPrecision);
////			}
////			else //if mass transform and group size
////			{
////				MassMove(direction);
////			}
////			
////			
////		}//move a mass of items with duplication with precision or not
////		if(TransformAndDuplicate && MassTransform)
////		{
////			if(UsePrecisionTransform)
////			{
////				Debug.Log("Not implemented yet, contact me at rbi.noli@gmail.com if you need it!");
////			}
////			else
////			{
////				//duplicate each of them then transferm them to current selection
////				/*foreach(GameObject go in Selection.gameObjects)
////					{
////						SeedScript s = go.GetComponent<SeedScript>();
////						s.Duplicate(direction); //does this move the original or the copy... ?
////					}*/
////				MassDuplicate();
////				MassMove(direction);  //does this move the original or the copy... ?
////				//Debug.Log("Not fully implemented yet");
////			}
////		}
//		//	Dirty();
//	}
//
//	//Get the bounds of each item, find the top and the bottom, then compare the distance between the two to find the distance to MassMove
//	//THE BOUNDS ONLY WORK IF IT ISN'T ROTATED. TRY CALCULATING BASED ON ROTATION AS WELL ~ 
//	void MassMove(CakeDirection direction)
//	{
//		
//		
//		GameObject[] go = Selection.gameObjects;
//		
//		//REGISTER UNDO
//		Object[] o = EditorUtility.CollectDeepHierarchy(things);
//		Undo.RegisterUndo(o, "test");
//	
//		Vector3 topBound = new Vector3(0,0,0);//right, or positive
//		Vector3 bottomBound = new Vector3(0,0,0); //left, or negative //we don't care about the actual objects, just the dimension
//		Vector3 actualMovement = Vector3.zero;
//		int i = 0;//for first round, initializing both values with useful numbers 
//		foreach(GameObject a in go)
//		{
//			
//			Vector3 itembounds = Vector3.zero;
//			Vector3 bottomTemp = Vector3.zero;
//			Vector3 topTemp = Vector3.zero;
//			switch(direction)
//			{
//			case CakeDirection.plusY:
//				itembounds = GetTheSize(a); //get the v3 bound
//				//itembounds = Quaternion.AngleAxis(
//				//itembounds = Vector3.RotateTowards(itembounds,a.transform.localPosition, 360,360); //this sort of works - but it seems to be based on its position from zero
//				if(i == 0)
//				{
//					bottomBound.y = a.transform.localPosition.y;
//					topBound.y = a.transform.localPosition.y;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.y =  a.transform.position.y - (itembounds.y/2)));
//				Debug.Log("Top calc" +( topTemp.y =  a.transform.position.y + (itembounds.y / 2 ))); //top bounds in worldspace
//				if(bottomTemp.y < bottomBound.y)
//				{
//					bottomBound.y = bottomTemp.y;
//				}
//				if(topTemp.y > topBound.y)
//				{
//					topBound.y = topTemp.y;
//				}
//				i++;
//				break;
//			case CakeDirection.minusY:
//				itembounds = GetTheSize(a); //get the v3 bound
//				if(i == 0)
//				{
//					bottomBound.y = a.transform.localPosition.y;
//					topBound.y = a.transform.localPosition.y;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.y =  a.transform.position.y - (itembounds.y/2)));
//				Debug.Log("Top calc" +( topTemp.y =  a.transform.position.y + (itembounds.y / 2 ))); //top bounds in worldspace
//				if(bottomTemp.y < bottomBound.y)
//				{
//					bottomBound.y = bottomTemp.y;
//				}
//				if(topTemp.y > topBound.y)
//				{
//					topBound.y = topTemp.y;
//				}
//				i++;
//				break;
//			case CakeDirection.plusX:
//				itembounds = GetTheSize(a); //get the v3 bound
//				if(i == 0)
//				{
//					bottomBound.x = a.transform.localPosition.x;
//					topBound.x = a.transform.localPosition.x;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.x =  a.transform.position.x - (itembounds.x/2)));
//				Debug.Log("Top calc" +( topTemp.x =  a.transform.position.x + (itembounds.x / 2 ))); //top bounds in worldspace
//				if(bottomTemp.x < bottomBound.x)
//				{
//					bottomBound.x = bottomTemp.x;
//				}
//				if(topTemp.x > topBound.x)
//				{
//					topBound.x = topTemp.x;
//				}
//				i++;
//				break;
//			case CakeDirection.minusX:
//				itembounds = GetTheSize(a); //get the v3 bound
//				if(i == 0)
//				{
//					bottomBound.x = a.transform.localPosition.x;
//					topBound.x = a.transform.localPosition.x;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.x =  a.transform.position.x - (itembounds.x/2)));
//				Debug.Log("Top calc" +( topTemp.x =  a.transform.position.x + (itembounds.x / 2 ))); //top bounds in worldspace
//				if(bottomTemp.x < bottomBound.x)
//				{
//					bottomBound.x = bottomTemp.x;
//				}
//				if(topTemp.x > topBound.x)
//				{
//					topBound.x = topTemp.x;
//				}
//				i++;
//				break;
//			case CakeDirection.plusZ:
//				itembounds = GetTheSize(a); //get the v3 bound
//				if(i == 0)
//				{
//					bottomBound.z = a.transform.localPosition.z;
//					topBound.z = a.transform.localPosition.z;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.z =  a.transform.position.z - (itembounds.z/2)));
//				Debug.Log("Top calc" +( topTemp.z =  a.transform.position.z + (itembounds.z / 2 ))); //top bounds in worldspace
//				if(bottomTemp.z < bottomBound.z)
//				{
//					bottomBound.z = bottomTemp.z;
//				}
//				if(topTemp.z > topBound.z)
//				{
//					topBound.z = topTemp.z;
//				}
//				i++;
//				break;
//			case CakeDirection.minusZ:
//				itembounds = GetTheSize(a); //get the v3 bound
//				if(i == 0)
//				{
//					bottomBound.z = a.transform.localPosition.z;
//					topBound.z = a.transform.localPosition.z;
//				}
//				
//				Debug.Log("Bottom calc" + (bottomTemp.z =  a.transform.position.z - (itembounds.z/2)));
//				Debug.Log("Top calc" +( topTemp.z =  a.transform.position.z + (itembounds.z / 2 ))); //top bounds in worldspace
//				if(bottomTemp.z < bottomBound.z)
//				{
//					bottomBound.z = bottomTemp.z;
//				}
//				if(topTemp.z > topBound.z)
//				{
//					topBound.z = topTemp.z;
//				}
//				i++;
//				break;
//			
//			}
//			
//		}
//		
//		actualMovement = topBound - bottomBound;
//		Debug.Log("Actual movement : " + actualMovement);
//		foreach(GameObject a in go)
//		{
//			if(direction == CakeDirection.plusX || direction == CakeDirection.plusY || direction == CakeDirection.plusZ)
//			{
//				Debug.Log("plus : " + actualMovement);
//				a.transform.Translate(actualMovement, Space.Self);	
//			}
//			if(direction == CakeDirection.minusX || direction == CakeDirection.minusY || direction == CakeDirection.minusZ)
//			{
//				Debug.Log("minus : " + -actualMovement);
//				a.transform.Translate(-actualMovement, Space.Self);	
//			}
//		}
//		
//	}
//	
//	void MassMove(CakeDirection direction, float precision) //Mass Move with precision instead of based on the size of the object. Origin calculations should not be necessary
//	{
//		GameObject[] go = Selection.gameObjects;
//		
//		foreach (GameObject a in go)
//		{
//			switch (direction)
//			{
//			case CakeDirection.plusY:
//				a.transform.Translate(new Vector3 (0,precision,0),Space.World);
//				break;
//			case CakeDirection.minusY:
//				a.transform.Translate(new Vector3 (0,-precision,0),Space.World);
//				break;
//			case CakeDirection.minusX:
//				a.transform.Translate(new Vector3 (-precision,0,0),Space.World);
//				break;
//			case CakeDirection.plusX:
//				a.transform.Translate(new Vector3 (precision,0,0),Space.World);
//				break;
//			case CakeDirection.plusZ:
//				a.transform.Translate(new Vector3 (0,0,precision),Space.World);
//				break;
//			case CakeDirection.minusZ:
//				a.transform.Translate(new Vector3 (0,0,-precision),Space.World);
//				break;
//			case CakeDirection.center:
//				a.transform.Translate(new Vector3 (0,0,0),Space.World);
//				break;
//			}
//		}
//	}
//	
//	void MassDuplicate()
//	{
//		GameObject[] go = Selection.gameObjects;
//		GameObject[] FutureSelections = new GameObject[Selection.gameObjects.Length];
//		int i = 0;
//		foreach (GameObject a in go)
//		{
//			GameObject next = Instantiate(a) as GameObject;
//			next.transform.localScale = a.transform.localScale;
//			next.name = a.name;// + UnityEngine.Random.value;
//			FutureSelections[i] = next;
//			i++;
//		}
//		
//		Selection.objects = FutureSelections;
//	}
//	
//	public void MassRotateTool(float angle, CakeRotation axis)
//	{	
//		//Create a temporary GameObject to control the pivot of the items. Afterwards, Delete it. 
//		GameObject Temp = new GameObject();
//		
//		//Change the transform to the center of the gameobjects. Get the pivot?
//		GameObject[] go = Selection.gameObjects;
//		Object[] o = EditorUtility.CollectDeepHierarchy(go);
//		Undo.RegisterUndo(o, " selected rotations");
//		
//		float x = 0;
//		float y = 0;
//		float z = 0;
//		foreach(GameObject a in go)
//		{
//			x += a.transform.position.x;
//			y += a.transform.position.y;
//			z += a.transform.position.z;
//		}
//		
//		float xdiv = x/go.Length;
//		float ydiv = x/go.Length;
//		float zdiv = z/go.Length;
//		
//		Temp.transform.position = new Vector3(xdiv,ydiv,zdiv);
//
//		foreach(GameObject a in go)
//		{
//			a.transform.parent = Temp.transform;
//		}
//		
//		switch(axis)
//		{
//		case CakeRotation.x:
//			Temp.transform.Rotate(Vector3.right, angle, Space.World);
//			break;
//		case CakeRotation.y:
//			Temp.transform.Rotate(Vector3.up, angle, Space.World);
//			break;
//		case CakeRotation.z:
//			Temp.transform.Rotate(Vector3.forward, angle, Space.World);
//			break;
//		}
//		
//		foreach(GameObject a in go)
//		{
//			a.transform.parent = null;
//		}
//		
//		DestroyImmediate(Temp);
//	}
//	
//	public void Rotate(float angle, CakeRotation axis , GameObject go)
//	{
//		Debug.Log("Rotate singles..");
//		Transform t = go.transform;
//		Undo.RegisterUndo(t,  t.name + " rotation");
//		switch(axis) 
//		{
//		case CakeRotation.x:
//			t.Rotate(Vector3.right,angle, Space.Self);
//			
//			break;
//		case CakeRotation.y:
//			t.Rotate(Vector3.up,angle,Space.World);
//			break;
//		case CakeRotation.z:
//			t.Rotate(Vector3.forward,angle, Space.Self);
//			break;
//		}
//		
//	}
//	
//	
//	
//	
//	public void MoveThings(CakeDirection direction)
//	{
//		
//		//Debug.Log(size.ToString());
//		
//		GameObject goTest = Selection.activeObject as GameObject;
//		Vector3 size = GetTheSize(goTest.gameObject);
//		Transform goTransform = goTest.transform;
//		Undo.RegisterUndo((Transform)goTransform, goTest.name + " movement");
//		switch (direction)
//			{
//			case CakeDirection.plusY:
//				goTransform.Translate(new Vector3 (0,size.y,0),Space.World);
//				break;
//			case CakeDirection.minusY:
//				goTransform.Translate(new Vector3 (0,-size.y,0),Space.World);
//				break;
//			case CakeDirection.minusX:
//				goTransform.Translate(new Vector3 (-size.x,0,0),Space.World);
//				break;
//			case CakeDirection.plusX:
//				goTransform.Translate(new Vector3 (size.x,0,0),Space.World);
//				break;
//			case CakeDirection.plusZ:
//				goTransform.Translate(new Vector3 (0,0,size.z),Space.World);
//				break;
//			case CakeDirection.minusZ:
//				goTransform.Translate(new Vector3 (0,0,-size.z),Space.World);
//				break;
//		}
//	}
//	
//	public void MoveThings(CakeDirection direction, float precision)
//	{
//		GameObject goTest = Selection.activeObject as GameObject;
//		Transform goTransform = goTest.transform;
//		Undo.RegisterUndo((Transform)goTransform, goTest.name + " movement");
//		
//		switch (direction)
//		{
//		case CakeDirection.plusY:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (0,precision ,0),Space.World);	
//			}
//			
//			break;
//		case CakeDirection.minusY:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (0,-precision,0),Space.World);
//			}
//			break;
//		case CakeDirection.minusX:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (-precision,0,0),Space.World);
//			}
//			break;
//		case CakeDirection.plusX:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (precision,0,0),Space.World);
//			}
//			break;
//		case CakeDirection.plusZ:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (0,0,precision),Space.World);
//			}
//			break;
//		case CakeDirection.minusZ:
//			foreach(GameObject go in things)
//			{
//				go.transform.Translate(new Vector3 (0,0,-precision),Space.World);
//			}
//			break;
//		}
//	}
//	
//	void Duplicate( CakeDirection direction)
//	{
//		
//		
//		GameObject go = Selection.activeGameObject;
//		//Grab the size of go
//		Vector3 size = GetTheSize(go);
//		//Create a copy of go
//		GameObject next = Instantiate(go) as GameObject;
//		next.transform.localScale = go.transform.localScale;
//		next.name = go.name;// + UnityEngine.Random.value;
//		Selection.activeGameObject = next;
//		
//		//next.name = next.name = "Branch" + UnityEngine.Random.value; //Hardcoded name + random number
//		switch (direction)
//		{
//		case CakeDirection.plusY:
//			next.transform.Translate(new Vector3 (0,size.y,0), Space.World);
//			break;
//		case CakeDirection.minusY:
//			next.transform.Translate(new Vector3 (0,-size.y,0),Space.World);
//			break;
//		case CakeDirection.plusX:
//			next.transform.Translate(new Vector3 ( size.x,0,0),Space.World);
//			break;
//		case CakeDirection.minusX:
//			next.transform.Translate(new Vector3 ( - size.x,0,0),Space.World);
//			break;
//		case CakeDirection.plusZ:
//			next.transform.Translate(new Vector3 (0,0,+ size.z),Space.World);
//			break;
//		case CakeDirection.minusZ:
//			next.transform.Translate(new Vector3 (0,0,- size.z),Space.World);
//			break;
//		case CakeDirection.center:
//			next.transform.Translate(new Vector3 (0,0,0),Space.World);
//			break;
//			
//			
//		}
//		
//	}
//	
//	public Vector3 GetTheSizeTool(GameObject go)
//	{
//		MeshFilter mf;
//		if(go.GetComponent<MeshFilter>())
//		{
//			mf= go.transform.GetComponent<MeshFilter>();
//		}
//		else if(go.GetComponentInChildren<MeshFilter>())
//		{
//			mf  = go.GetComponentInChildren<MeshFilter>();
//		}
//		else
//		{
//			Debug.Log("This GameObject has no MeshRenderer");
//			return new Vector3(0,0,0);
//		}
//		//MeshFilter mf = gameObject.GetComponent<MeshFilter>();
//		Mesh mesh = mf.sharedMesh;
//		
//		Vector3 meshSize = mesh.bounds.size;
//		//Debug.Log("Mesh bounds :" + meshSize + " local scale :" + go.transform.localScale);
//		
//		//combine Mesh Bounds size * scale
//		//meshSize = meshSize ( transform.localScale);
//		
//		Vector3 newVector = Vector3.Scale(meshSize,go.transform.localScale);
//		//Debug.Log(newVector);
//		return newVector;
//		
//	}
//}
