using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	Rect leftPointsRect 	= new Rect(Screen.width 	/ 2 	+ 200,20,200,200);
	Rect rightPointsRect 	= new Rect(Screen.width 	/ 2 	- 200,20,200,200);
	Rect middleRect			= new Rect(Screen.width 	/ 2		- 100,Screen.height / 2 , 200,200);

	int shortTime = 300;
	bool puns = false;
	void OnGUI(){
		GUI.Label(leftPointsRect,Global.LeftPoints.ToString());
		GUI.Label(rightPointsRect,Global.RightPoints.ToString());

		if(!Management.ball ){
			puns = true;
		}
		if(shortTime <= 1){
			shortTime = 300;
			puns = false;
		}
		if(puns && shortTime > 0){
			GUI.Label(middleRect,"OW SHIT THATS GONNA HURT");
			shortTime -= 1;
			Debug.Log("ShortTime = " + shortTime);
		}
	}
}
