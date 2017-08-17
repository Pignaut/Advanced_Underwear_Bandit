using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitStation : MonoBehaviour {

	void OnTriggerEnter (Collider _collision)
	{
		SceneManager.LoadScene ("stationMenu", UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
}