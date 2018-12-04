using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	//Music files
	public AudioClip MenuMusic;
	public AudioClip level1;
	public AudioClip level2;
	public AudioClip level3;

	//sound effect files
	public AudioClip beam;
	public AudioClip torpedo;
	public AudioClip destroyed;
	public AudioClip boss;

	//soundmanager singleton
	private static SoundManager _instance;
	//the current clip being played
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
		//play some music on main menu
		PlayMusic(MenuMusic);
		
    }

	public void Play(AudioClip clip)
	{
		//play a sound clip for player
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	public void PlayEnemy(AudioClip clip)
	{
		//play a sound clip for enemies
		EnemySource.clip = clip;
		EnemySource.Play();
	}

	public void PlayMusic(AudioClip clip)
	{
		//play music
		currentClip = clip;
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	void Update(){


		//if there is music playing
		//leave it and do nothing
		if(MusicSource.isPlaying){
			return;
		}
		else{
			//play music if not
			PlayMusic(currentClip);

		}

	}

}
