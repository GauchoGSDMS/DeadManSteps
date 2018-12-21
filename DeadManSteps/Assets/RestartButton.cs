using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour 
{
	
	public void Restart()
	{
		Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
			/*pnlGameOver.SetActive(false);
			Time.timeScale = 1f;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			 */
	}

}
