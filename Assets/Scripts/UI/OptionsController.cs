using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider sfxSlider;

	void Start ()	{
		volumeSlider.value = PlayerPrefsManager.GetMusicVoume();
		sfxSlider.value = PlayerPrefsManager.GetSFXVoume();
	}

	// Update is called once per frame
	void Update () {
	}

	public void SaveAndExit (){
		PlayerPrefsManager.SetMusicVolume (volumeSlider.value);
		PlayerPrefsManager.SetSFXVolume (sfxSlider.value);
	}

	public void ResetOptions (){
		volumeSlider.value = 50;
		sfxSlider.value = 50;
	}

}
