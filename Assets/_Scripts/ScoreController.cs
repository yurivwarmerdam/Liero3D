using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public FloatVariable Player1HP;
    public FloatVariable Player2HP;
    public FloatVariable P1Kills; 
    public FloatVariable P2Kills;
    public Text P1ScoreText;
    public Text P2ScoreText;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        P1ScoreText.text="Health: "
            + Player1HP.value 
            +"\n"+"Kills: " + P1Kills.value;

        P2ScoreText.text= "Health: " 
            + Player2HP.value 
            + "\n"+"Kills: " + P2Kills.value;
    }
}