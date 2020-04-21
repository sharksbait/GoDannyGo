using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public int buttonWidth;
	public int buttonHeight;
	private int origin_x;
	private int origin_y;
	public GUISkin mySkin;
    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width/2 - buttonWidth/2;
        origin_y = Screen.height/2 - buttonHeight*2;
    }

    void OnGUI() {
    	GUI.skin = mySkin;
    	if(GUI.Button(new Rect(origin_x,origin_y,buttonWidth,buttonHeight), "Level 1")) {
    		Application.LoadLevel(1);
    	}
    	if(GUI.Button(new Rect(origin_x,origin_y+buttonHeight+20,buttonWidth,buttonHeight), "Level 2")) {
    		Application.LoadLevel(2);
    	}
    	if(GUI.Button(new Rect(origin_x,origin_y+buttonHeight*2+40,buttonWidth,buttonHeight), "Level 3")) {
    		Application.LoadLevel(3);
    	}
    	if(GUI.Button(new Rect(origin_x,origin_y+buttonHeight*3+60,buttonWidth,buttonHeight), "Quit")) {
    		#if UNITY_EDITOR
    			UnityEditor.EditorApplication.isPlaying = false;
    		#else
    			Application.Quit();
    		#endif
    	}
    }
}







