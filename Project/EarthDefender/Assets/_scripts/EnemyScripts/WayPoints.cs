using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

	//list of points
	[SerializeField]
	private List<Transform> points;
	//create this list as singleton
	private static WayPoints _instance;
    public static WayPoints Instance { get { return _instance; } }

	// Use this for initialization
	void Start () {
		//if the instance already exists
		if (_instance != null && _instance != this)
        {
			//destroy the object
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

	}

	public List<Transform> getPoints(){
		//retun the list of points
		return points;
	}

}
