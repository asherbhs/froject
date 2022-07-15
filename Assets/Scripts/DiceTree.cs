using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status { Growing, Thirsty, Rotten, Carried, Healthy };

public class DiceTree : MonoBehaviour
{
    private int elapsedFrames;
    public GameObject dice;
    public DiceScript diceScript;
    private Status status;
    private float statusTimer;
    [SerializeField] private GameObject dicePrefab;

    void Start()
    {
        status = Status.Healthy;
        elapsedFrames = 0;
        Debug.Log("!");
        GenerateDice();
    }

    void FixedUpdate()
    {
        //update the dice
        FrameAction(Time.deltaTime);
        statusTimer -= Time.deltaTime;
        if (statusTimer <= 0){
            status = Status.Healthy;
        }
    }

    public void Rot()
    {
        GenerateDice();
        this.status = Status.Rotten;
    }

    public void SetStatus(Status stat)
    {
        status = stat;
    }

    private void FrameAction(float time)
    {
        if (status == Status.Healthy)
        {
            diceScript.ElapseFrame(time);
        }
        else if (status == Status.Thirsty)
        {
            diceScript.ElapseFrame(time / 2.0f);
        }
    }

    public void GenerateDice()
    {
        Debug.Log("GEN");
        dice = Instantiate(dicePrefab, this.transform);
        diceScript = dice.AddComponent<DiceScript>();
        diceScript.GenerateStats(0);
    }
}
