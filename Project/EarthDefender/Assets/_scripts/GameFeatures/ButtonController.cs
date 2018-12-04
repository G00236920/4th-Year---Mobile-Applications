using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    //Each button on the menu
    public GameObject TorpButton;
    public GameObject PromButton;
    public GameObject EntButton;
    public GameObject DefButton;
    //each ship to be shown on screen
    public GameObject prom;
    public GameObject def;
    public GameObject ent;

    //to tell if the ships are unlocked or not
    private bool defiantUnlocked = false;
    private bool enterpriseUnlocked = false;

    //make this controller a singleton
	private static ButtonController _instance;
    public static ButtonController Instance { get { return _instance; } }

    // Use this for initialization
	void Start () {
        //if the instance exists
		if (_instance != null && _instance != this)
        {
            //destroy it
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        //check if the buttons are clicked
        checkTorpButton();
        checkPromButton();
        checkEntButton();
        checkDefButton();
	}

    void checkTorpButton() {
        //if the torpedos are unlocked
        if (GameRules.Instance.getTorp())
        {
            //set the button to be invisible
            TorpButton.SetActive(false);
        }
        else
        {
            //Set the button to be visible
            //since in this case its locked
            TorpButton.SetActive(true);
        }
    }

    void checkPromButton()
    {
        //if the selected ship is the prometheus
        if (GameRules.Instance.getShip().name ==  prom.name)
        {
            //disable the button for selecting the prometheus
            PromButton.SetActive(false);
        }
        else
        {
            //enable the button if its not selected
            PromButton.SetActive(true);
        }

    }

    void checkDefButton()
    {
        //if the defiant is unlocked.
        //then it can be selected, change its text
        if(defiantUnlocked){
            DefButton.GetComponentInChildren<Text>().text = "Select";
        }
        //if the defiant is the current ship of choice
        if (GameRules.Instance.getShip().name == def.name)
        {
            //Disable the button
            DefButton.SetActive(false);
        }
        else
        {
            //enable the button
            DefButton.SetActive(true);
        }

    }
    
    void checkEntButton()
    {
        //if the enterprise is unlocked
        if(enterpriseUnlocked){
            EntButton.GetComponentInChildren<Text>().text = "Select";
        }
        //if the enterprise is the current ship of choice
        if (GameRules.Instance.getShip().name == ent.name)
        {  
            //disable the button
            EntButton.SetActive(false);
        }
        else
        {
            //enable the button
            EntButton.SetActive(true);
        }

    }

    public bool getDefiantUnlocked(){
        //determine if the defiant is unlocked
        return defiantUnlocked;
    }

    public void setDefiantUnlocked(bool b){
        //unlock the defiant
        defiantUnlocked = b;
    }

    public bool getEnterpriseUnlocked(){
        //determine if the Enterprise is unlocked
        return enterpriseUnlocked;
    }

    public void setEnterpriseUnlocked(bool b){
        //unlock the enterprise
        enterpriseUnlocked = b;
    }
}
