using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {
	
	public GameObject loadingScreen;
	public Scrollbar slider;
	public static bool gameIsPaused = false;

	public void NewGame(int sceneIndex)
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}

	public void ResumeGame()
	{
		
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
}
