using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


	public AudioClip MenuMusic;
	public AudioClip level1;
	public AudioClip beam;
	public AudioClip torpedo;
	public AudioClip destroyed;
	public AudioClip boss;

	private static SoundManager _instance;
	private static AudioClip currentClip;

    public static SoundManager Instance { get { return _instance; } }


	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioSource EnemySource;
	

	// Singleton instance.
	private void Awake()
    {

		DontDestroyOnLoad(gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		PlayMusic(MenuMusic);
		
    }

	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	public void PlayEnemy(AudioClip clip)
	{
		EnemySource.clip = clip;
		EnemySource.Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		currentClip = clip;

		MusicSource.clip = clip;

		MusicSource.Play();

	}

	void Update(){

		if(MusicSource.isPlaying){
			return;
		}
		else{
			
			PlayMusic(currentClip);

		}

	}

}
