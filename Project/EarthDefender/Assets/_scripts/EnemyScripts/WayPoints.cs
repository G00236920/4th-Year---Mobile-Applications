using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

	[SerializeField]
	private List<Transform> points;
	private static WayPoints _instance;
    public static WayPoints Instance { get { return _instance; } }

	// Use this for initialization
	void Start () {
		
		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

	}

	public List<Transform> getPoints(){
		return points;
	}

}
