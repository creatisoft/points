using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour {


    //Setting up the UI
    public Text playerPointsUI;
    public Text cpuPointsUI;

    public Text playerStats;
    public Text cpuStats;

    public Button playerAttackButton;
    public Button playerDefendButton;


    //Setting up the Player Variables
    struct Player {

        public float strength;
        public float defense;

        public float internalStrength;
        public float internalDefense;

        public float points;

        public int playerCommandChoice;
        
    }

    struct CPU {

        public float strength;
        public float defense;

        public float internalStrength;
        public float internalDefense;

        public float points;

        public int cpuCommandChoice;

    }

    //Referencing the Structs
    Player player;
    CPU cpu;


    public float nextFireRate = 0.5f;

    // Start is called before the first frame update
    void Start() {

        playerAttackButton.onClick.AddListener(AttackButton);

        player.points = 100f;
        cpu.points = 100f;

        

        Debug.Log("=======================");
        RandomStatsGenerator();
        Debug.Log("=======================");
        RandomInternalStatsGenerator();
        Debug.Log("=======================");

        player.defense = player.defense + (player.internalDefense / 4);
        player.strength = player.strength + (player.internalStrength / 3);


        UpdateUI();
        //Debug.Log(player.defense);
        //Debug.Log(player.strength);

    }

    void RandomStatsGenerator() {

        
        player.defense = Random.Range(1, 6);
        Debug.Log("Player Defense: " + player.defense);
        player.strength = Random.Range(0, 5);
        Debug.Log("Player Strength: " + player.strength);

        
        cpu.defense = Random.Range(1, 6);
        Debug.Log("CPU Defense: " + cpu.defense);
        cpu.strength = Random.Range(0, 5);
        Debug.Log("CPU Strength: " + cpu.strength);

    }

    void RandomInternalStatsGenerator() {

        player.internalDefense = Random.Range(2, 5);
        Debug.Log("Player Defense: " + player.internalDefense);
        player.internalStrength = Random.Range(1, 4);
        Debug.Log("Player Strength: " + player.internalStrength);

        cpu.internalDefense = Random.Range(2, 5);
        Debug.Log("CPU Internal Defense: " + cpu.internalDefense);
        cpu.internalStrength = Random.Range(1, 4);
        Debug.Log("CPU Internal Strength: " + cpu.internalStrength);

    }


    int CPULogic() {

        cpu.cpuCommandChoice = Random.Range(1, 3);

        return cpu.cpuCommandChoice;

    }

    void AttackButton() {

        CPULogic();

        player.playerCommandChoice = 1;

        cpu.points = cpu.points - player.strength;
        UpdateUI();
        Debug.Log("clicky");

    }

    void DefendButton() {

        player.playerCommandChoice = 0;

    }

    void UpdateUI() {

        playerPointsUI.text = player.points.ToString("000.0");
        cpuPointsUI.text = cpu.points.ToString("000.0");

        playerStats.text = "Attack: " + player.strength.ToString("0.0") + "\nDef: " + player.defense.ToString("0.0");
        cpuStats.text = "Attack: " + cpu.strength.ToString("0.0") + "\nDef: " + cpu.defense.ToString("0.0");


    }



// Update is called once per frame
void Update() {




        





        //Time test - idk where this is going to be used just yet
        /*
        if( Time.fixedTime > nextFireRate ) {

            Debug.Log("firing...");
            nextFireRate = Time.fixedTime + 2.5f;



        }*/



    }
}
