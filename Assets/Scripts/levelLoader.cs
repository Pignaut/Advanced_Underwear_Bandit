using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class levelLoader : MonoBehaviour {

	public void LScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
}
