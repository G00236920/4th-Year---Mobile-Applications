using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

	//Sliders to control audio
	public Slider masterSlider;
	public Slider fxSlider;
	public Slider musicSlider;

	//Audio sources
	public AudioSource musicVolume;
	public AudioSource playerFXVolume;
	public AudioSource enemyFXVolume;

	// Use this for initialization
	void Start () {

		//set the volumes to that of the sources
		musicVolume = SoundManager.Instance.MusicSource;
		playerFXVolume = SoundManager.Instance.EffectsSource;
		enemyFXVolume = SoundManager.Instance.EnemySource;

		//set the sliders to max
		masterSlider.value = 100;
		fxSlider.value = 100;
		musicSlider.value = 100;
	}
	
	// Update is called once per frame
	void Update () {
		//make sure the master volume slider has effect on the overall volume level
		float x = masterSlider.value;
		//multiply the volume by that of the master slider value
		musicVolume.volume = musicSlider.value * x;
		playerFXVolume.volume = fxSlider.value * x;
		enemyFXVolume.volume = fxSlider.value * x;
	}
}
