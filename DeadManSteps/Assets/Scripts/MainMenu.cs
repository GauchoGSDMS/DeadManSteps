using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
	
	public GameObject loadingScreen;
	public Scrollbar slider;
	public GameObject pauseMenuUI;
	public static bool gameIsPaused = false;
	public Text chargeText;

	public void NewGame(int sceneIndex)
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	public void QuitGame (){
		Application.Quit();
	}

	void Start()
	{
		if(pauseMenuUI.activeSelf){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}else{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		
	}

	public void MainMenuGame(int sceneIndex){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1f;
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)){		
			if (gameIsPaused){
				ResumeGame();	
			}else{
				PauseGame();
			}
		}
	}
	

	public void ResumeGame(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void PauseGame(){
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	IEnumerator LoadAsynchronously(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive(true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.size = progress; 
			chargeText.text = progress * 100f + "%";
			yield return null;
		}
	}
}
