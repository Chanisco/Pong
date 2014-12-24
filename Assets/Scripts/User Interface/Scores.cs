using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	Rect leftPointsRect 	= new Rect(Screen.width 	/ 2 	+ 200,20,200,200);
	Rect rightPointsRect 	= new Rect(Screen.width 	/ 2 	- 200,20,200,200);
	Rect middleRect			= new Rect(Screen.width 	/ 2		- 100,Screen.height / 2 , 200,200);

	int shortTime = 300;
	bool puns = false;
	bool commentSet = false;

	string comment;
	void OnGUI(){
		GUI.Label(leftPointsRect,Global.LeftPoints.ToString());
		GUI.Label(rightPointsRect,Global.RightPoints.ToString());

		if(!Management.ball){
			puns = true;
			commentSet = false;

		}
		if(shortTime <= 1){
			shortTime = 300;
			puns = false;
		}
		if(puns && shortTime > 0){
			GUI.Label(middleRect,comment);
			shortTime -= 1;
		}

		if(puns && !commentSet){
			int switchStatement = Random.Range(1,5);
			switch(switchStatement){
			case 1:
				comment = 	"OW SHIT THATS GONNA HURT";
				break;
			case 2:
				comment =	"Show us the magic!";
				break;
			case 3:
				comment =	"Damn these graphics are epic";
				break;
			case 4:
				comment =	"10/10 would try again";
				break;
			case 5:
				comment =	"Gotta love that one!";
				break;
			case 6:
				comment =	"Dear baby jesus,Thats EPIC";
				break;
			case 7:
				comment =	"Somebody stop him!";
				break;
			case 8:
				comment =	"Can't touch this";
				break;
			case 9:
				comment =	"Luke,I'm your daddy!";
				break;
			case 10:
				comment =	"Luke, Its a me Papi";
				break;
			}
			commentSet = true;

		}
	}
}
