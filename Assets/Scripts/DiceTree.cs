using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {Growing, Thirsty, Rotten, Carried, Healthy};


public class DiceTree : MonoBehaviour
{   

    private int elapsedFrames;
    private Dice dice;
    private Status status;
    // Start is called before the first frame update
    void Start()
    {   
        elapsedFrames = 0;
        dice = GenerateDice();
    }

    void FixedUpdate()
    {
        //update the dice
        FrameAction();
    }

    public void SetStatus(Status stat){
        status = stat;
    }

    private void FrameAction(){
        if (status == Status.Healthy){
            dice.ElapseFrame();
            elapsedFrames = 0;
        }
    }

    public Dice GenerateDice(){
        return new Dice(DiceType.D20);
    }
}
