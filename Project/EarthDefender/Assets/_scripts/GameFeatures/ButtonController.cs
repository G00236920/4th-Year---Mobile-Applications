using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public GameObject TorpButton;
    public GameObject PromButton;
    public GameObject EntButton;
    public GameObject DefButton;
    public GameObject prom;
    public GameObject def;
    public GameObject ent;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkTorpButton();
        checkPromButton();
        checkEntButton();
        checkDefButton();
	}

    void checkTorpButton() {

        if (GameRules.Instance.getTorp())
        {
            TorpButton.SetActive(false);
        }
        else
        {
            TorpButton.SetActive(true);
        }
    }

    void checkPromButton()
    {

        if (GameRules.Instance.getShip().name ==  prom.name)
        {
            PromButton.SetActive(false);
        }
        else
        {
            PromButton.SetActive(true);
        }

    }

    void checkDefButton()
    {

        if (GameRules.Instance.getShip().name == def.name)
        {
            DefButton.SetActive(false);
        }
        else
        {
            DefButton.SetActive(true);
        }

    }
    
    void checkEntButton()
    {

        if (GameRules.Instance.getShip().name == ent.name)
        {
            EntButton.SetActive(false);
        }
        else
        {
            EntButton.SetActive(true);
        }

    }
}
