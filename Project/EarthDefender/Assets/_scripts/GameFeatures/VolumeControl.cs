using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {
	public Slider masterSlider;
	public Slider fxSlider;
	public Slider musicSlider;
	public AudioSource musicVolume;
	public AudioSource playerFXVolume;
	public AudioSource enemyFXVolume;

	// Use this for initialization
	void Start () {
		musicVolume = SoundManager.Instance.MusicSource;
		playerFXVolume = SoundManager.Instance.EffectsSource;
		enemyFXVolume = SoundManager.Instance.EnemySource;

		masterSlider.value = 100;
		fxSlider.value = 100;
		musicSlider.value = 100;
	}
	
	// Update is called once per frame
	void Update () {

		float x = masterSlider.value;

		musicVolume.volume = musicSlider.value * x;
		playerFXVolume.volume = fxSlider.value * x;
		enemyFXVolume.volume = fxSlider.value * x;
	}
}
