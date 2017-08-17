using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public Canvas canvas;
	public GameObject txt;

	public Slider valueSlider;

	void start()
	{
		canvas = GetComponent<Canvas> ();
		txt = canvas.GetComponentInChildren<GameObject> ();
	}

	void update()
	{
		SubmitSliderSetting ();
	}

	public void SubmitSliderSetting()
	{
		Debug.Log (valueSlider.value);
	}
}
