using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	Rect leftPointsRect 	= new Rect(Screen.width 	/ 2 	+ 200,20,200,200);
	Rect rightPointsRect 	= new Rect(Screen.width 	/ 2 	- 200,20,200,200);
	void OnGUI(){
		GUI.Label(leftPointsRect,Global.LeftPoints.ToString());
		GUI.Label(rightPointsRect,Global.RightPoints.ToString());
	}
}
