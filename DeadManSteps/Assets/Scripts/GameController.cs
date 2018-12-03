using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public static bool hasPhone;
	[SerializeField]
	private DialogueTrigger[] dialogueList;

	// Use this for initialization
	void Start () {
		dialogueList[0].TriggerDialogue();
	}
	
	// Update is called once per frame
	void Update () {

		if(hasPhone == true){
			dialogueList[1].TriggerDialogue();
		}
		
	}

}
