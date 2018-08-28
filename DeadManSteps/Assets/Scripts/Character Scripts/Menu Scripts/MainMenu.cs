using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	
	public GameObject loadingScreen;
	public Scrollbar slider;
	public static bool gameIsPaused = false;
	public GameObject pauseUIMenu = null;


	void Start()
	{
		if (pauseUIMenu != null)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;			
		}else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}


	public void NewGame(int sceneIndex)
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	public void MainMenuGame(int sceneIndex)
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1f;
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gameIsPaused)
			{
				ResumeGame();
			}else
			{
				PauseGame();
			}
		}	
	}

	IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);

		while (!operation.isDone) 
		{

			float progress = Mathf.Clamp01 (operation.progress / .9f);

			slider.size = progress;

			yield return null;
		}
	}

	public void ResumeGame()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.None;
		gameIsPaused = false;
		pauseUIMenu.SetActive(false);
		Time.timeScale = 1f;
		
	}

	public void PauseGame()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		pauseUIMenu.SetActive(true);
		gameIsPaused = true;
		Time.timeScale = 0f;
	} 

}
