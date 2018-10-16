using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip backgroundMusic;
	public AudioClip beam;
	public AudioClip torpedo;
	public AudioClip destoryed;
	private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }


	// Audio players components.
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	// Singleton instance.
	private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		PlayMusic(backgroundMusic);
		
    }

	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;

		MusicSource.Play();
		

	}

	void Update(){

		if(MusicSource.isPlaying){
			return;
		}
		else{
			
			PlayMusic(backgroundMusic);

		}

	}

}
