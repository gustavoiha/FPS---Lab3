using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int collectiblesCollected = 0;

	public static int collectiblesTotal = 10;

	public static string[] collectibleTexts = new string[] {	"What are you doing?", 
																"Stop reading this.", 
																"I'm coming after you.", 
																"I will never get out of here. Alive.", 
																"I won't say it again.", 
																"This was my life.", 
																"No one will survive.", 
																"I'll have your head.", 
																"You're almost at the end.", 
																"This is the last one."};

	public static void Collected (){
		collectiblesCollected++;
		collectiblesCollected = Mathf.Min (collectiblesTotal, collectiblesCollected);
	}
}
