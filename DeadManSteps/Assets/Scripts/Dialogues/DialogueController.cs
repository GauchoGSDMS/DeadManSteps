using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour {

	public Text dialogueText;
	public Image dialogueBox;
	private Queue<string> sentences;
	public Text chargeText;
	public GameObject panelLS = null;
	public Scrollbar slider;
	
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
			StartCoroutine(LoadAsynchronously(2));
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

	IEnumerator LoadAsynchronously(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		
		if(panelLS!=null)
			panelLS.SetActive(true);
		
		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.size = progress; 
			chargeText.text = Mathf.Round(progress * 100f).ToString() + "%";
			yield return null;
		}
	}
	
}
