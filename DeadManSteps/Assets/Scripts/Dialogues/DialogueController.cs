using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	public Text dialogueText;
	public Image dialogueBox;
	private Queue<string> sentences;

	void Awake () {
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		dialogueBox.gameObject.SetActive(true);
		
		sentences.Clear();
		Time.timeScale = 0f;

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0 && GameController.isPhoneAlive) 
		{	
			EndDialogue();
			return;
		}
		else if(sentences.Count == 0 && !GameController.isPhoneAlive)
		{
			EndDialogue();
			Debug.Log("Termino el Primer Nivel");
			return;
		}
		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	void EndDialogue()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		dialogueBox.gameObject.SetActive(false);
		Time.timeScale = 1f;
	}

}
