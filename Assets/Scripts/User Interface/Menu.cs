using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	private Rect fullScreen 		= new Rect(0,-10,Screen.width + 20,Screen.height + 20);
	private Rect startBtnRect 		= new Rect(20,10,200,100); 
	private Rect playerBtnRect 		= new Rect(20,120,200,100); 
	private Rect numberPlayerRect 	= new Rect(225,120,50,100); 
	private Rect vsBtnRect 			= new Rect(20,230,200,100); 
	private Rect vsDiffiRect 		= new Rect(225,230,200,100); 
	private Rect instructionsRect	= new Rect(500,120,500,400);
	private Rect outputRect 		= new Rect(Screen.width - 150,Screen.height - 20,150,20); 

	public 	Texture background,startBtn,playerBtn,vsAIBtn,vsPlayerBtn;
	public 	Texture	OneText,TwoText,ThreeText,FourText,instructText;
	public 	Texture	EasyText,HardText;
	private Texture vsBtn,numberOfPlayers,vsDiffi;

	private int Timer = 300;
	private bool Counting = false;

	void Awake(){
		numberOfPlayers = TwoText;
		Global.WantedPlayers = 3;
		vsBtn = vsAIBtn;
		Global.Vs = "Computer";
	}
	void OnGUI(){
		if(background != null){
			GUI.Label(fullScreen,background);
		}

		if(GUI.Button(startBtnRect,startBtn,GUIStyle.none)){
			Invoke("StartGame" , 3);
			Counting = true;
		}

		if(GUI.Button(playerBtnRect,playerBtn,GUIStyle.none)){
			if(Global.WantedPlayers < 4){
				Global.WantedPlayers += 1;
				if(Global.WantedPlayers == 3){
					numberOfPlayers = TwoText;
				}else if(Global.WantedPlayers == 4){
					numberOfPlayers = ThreeText;
					Global.Vs = "Player";
				}
			}else{
				Global.WantedPlayers = 3;
				numberOfPlayers = TwoText;
			}
		}
		GUI.Label(numberPlayerRect,numberOfPlayers);

		if(Global.WantedPlayers == 3){
			if(GUI.Button(vsBtnRect,vsBtn,GUIStyle.none)){
				if(Global.Vs == "Computer" && Global.Difficulty == "Hard"){
					Global.Vs = "Player";
					vsBtn = vsPlayerBtn;
				}else{
					Global.Vs = "Computer";
					vsBtn = vsAIBtn;
					if(Global.Difficulty == "Easy"){
						Global.Difficulty = "Hard";
						vsDiffi = HardText;
					}else{
						Global.Difficulty = "Easy";
						vsDiffi = EasyText;
					}
				}
			}
			if(Global.Vs == "Computer"){
				GUI.Label(vsDiffiRect,vsDiffi);
			}
		}
		if(Counting == true && Timer > 0){
			GUI.Label(instructionsRect,instructText);
			GUI.Label(outputRect,"Game is startin in " + Timer.ToString());
			Timer -= 1;
		}

	}

	void StartGame(){
		Application.LoadLevel(1);
	}

}
