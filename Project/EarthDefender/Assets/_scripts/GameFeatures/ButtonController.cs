using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public GameObject TorpButton;
    public GameObject PromButton;
    public GameObject EntButton;
    public GameObject DefButton;
    public GameObject prom;
    public GameObject def;
    public GameObject ent;

    private bool defiantUnlocked = false;

    private bool enterpriseUnlocked = false;

	private static ButtonController _instance;
    public static ButtonController Instance { get { return _instance; } }

    // Use this for initialization
	void Start () {

		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        
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

        if(defiantUnlocked){
            DefButton.GetComponentInChildren<Text>().text = "Select";
        }

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

        if(enterpriseUnlocked){
            EntButton.GetComponentInChildren<Text>().text = "Select";
        }

        if (GameRules.Instance.getShip().name == ent.name)
        {
            EntButton.SetActive(false);
        }
        else
        {
            EntButton.SetActive(true);
        }

    }

    public bool getDefiantUnlocked(){
        return defiantUnlocked;
    }

    public void setDefiantUnlocked(bool b){
        defiantUnlocked = b;
    }

    public bool getEnterpriseUnlocked(){
        return enterpriseUnlocked;
    }

    public void setEnterpriseUnlocked(bool b){
        enterpriseUnlocked = b;
    }
}
