using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public Vector2 GroupSize = new Vector2(150, 20);
	public Vector2 GoldPosition = new Vector2(20,60);
	public Texture2D GoldBarEmpty;
	public GUIStyle BoxGUIStyle = null;
	public GUIContent GoldContent;
	public string GoldText = "Gold";
//	private int Count = 0; 

	private GameController GameController;
	




	private void OnGUI(){

		//InitBoxStyles ();

		//GUI.BeginGroup (new Rect(0, 0, GroupSize.x, GroupSize.y));

		//GoldContent = new GUIContent ();
		//GoldContent.text = "Gold: " + Count;

		//GUI.Box (new Rect (0, 0, GroupSize.x, GroupSize.y), GoldContent, BoxGUIStyle);

		//GUI.EndGroup ();


			
	}

	private void InitBoxStyles(){
		
		if (BoxGUIStyle != null) {
			return;
		}		
		
		BoxGUIStyle = new GUIStyle( GUI.skin.box );
		BoxGUIStyle.normal.background = CreateBackground(400,80, new Color( 0f, 0f, 0f, 0.9f ) );
		
	}
	
	
	private Texture2D CreateBackground(int width, int height, Color col){
		
		var pix = new Color[width * height];
		
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		
		var result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		
		return result;
	}
}
