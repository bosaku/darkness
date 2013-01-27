using UnityEngine;
using System.Collections;

public class FadeTransition : MonoBehaviour {
	
	public UISlicedSprite Sprite;
	public float FadeLerp = .0001f;
	public float FadeCutoff = .5f;
	
	public enum Colors {blue,black,red,green,white};
	//public static FadeTransition Instance;

	
//	Color Transparent = new Color(1,1,1,0);
	
//	bool beginFade = false;
//	bool returnTransparent = false;
	
	public void Update()
	{
		ColorStateMethod();	
	}
	public void Start()
	{
		//Sprite = gameObject.GetComponent<UISlicedSprite>();
		ColorStateMethod = new ColorStates(NullState);
		
	}
	
	void NullState()
	{}
	
	public void FadeWhite()
	{
		//Sprite.color = Color.white;
		//colors = Colors.white;
		ColorStateMethod = new ColorStates(FadeIn);
	}
	
	public void ImmediateOpaque()
	{
		Sprite.color = White;
	}
	
	public Colors colors;
	private delegate void ColorStates();
	private ColorStates ColorStateMethod;
	
	float t = 0;
	Color Blue = new Color(0,0,1,1);
	Color Green = new Color(0,1,0,1);
	Color Red = new Color(1,0,0,255);
	Color White = new Color(1,1,1,255);
	Color Black = new Color(0,0,0,255);
	Color ResultingColor;
	Color _color = new Color(0,0,0);

	public void FadeIn()
	{
		ResultingColor = Color.Lerp(Sprite.color, Color.black, 20 * Time.deltaTime);
		Sprite.color = ResultingColor;
		if(Sprite.color.a >= 1)
		{
			//ColorStateMethod = new ColorStates(ToTransparent);
		}
	}
	
//	void Colorize()
//	{
//		
//		switch(colors)
//		{
//		case Colors.blue:
//			_color = Blue;
//			break;
//		case Colors.black:
//			_color = Black;
//			break;	
//		case Colors.green:
//			_color = Green;
//			break;
//		case Colors.white:
//			_color = White;
//			break;
//		case Colors.red:
//			_color = Red;
//			break;
//		}
//		t += FadeLerp;
//		ResultingColor = Color.Lerp(Sprite.color,Color.black,10 * Time.deltaTime);
//		//Debug.Log(t);
//		Sprite.color = ResultingColor;
//		if(Sprite.color == _color || t >= FadeCutoff)
//		{
//			
//			t = 0;
//			//Debug.Log("Finished Coloring");
//			ColorStateMethod = new ColorStates(ToTransparent);
//			
//		}
//		
//	}
	
	public bool ToTransparent()
	{
		//t+=FadeLerp * 200;
		//Debug.Log("ToTransparent " + t + Sprite.color.ToString());
		//Sprite.color = Color.white;
		ResultingColor = Color.Lerp(Sprite.color,Color.clear, 1.2f * Time.deltaTime);
		Sprite.color = ResultingColor;
		//Debug.Log(ResultingColor);
		if(ResultingColor.a <= 1)
		{
			Debug.Log("Finished fading");
			t = 0;
			ColorStateMethod = new ColorStates(NullState);
			Sprite.color = new Color(0,0,0,0);
			return true;
		}
		else return false;
	}
	
//	void OnSelect()
//	{
//	
//		Debug.Log("Selected");	
//		ColorStateMethod = new ColorStates(Colorize);
//			
//	}
//	
	
}




