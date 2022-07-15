using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceType {D20, D12, D10, D8, D6, D4, D0};

public class Dice : MonoBehaviour
{   
    enum DiceType {D20, D12, D10, D8, D6, D4, D0};
    enum Status {Growing, Thirsty, Rotten, Carried};

    private DiceType type;
    private Status status;
    private int sides;
    private int frames;
    private int elapsedFrames;

    public Dice(int sides){
        this.sides = sides;
        frames = GetFrames(sides);
        elapsedFrames = 0;
    };

    public int GetFrames(int sides){
        return sides * 50;
    }

    public void ElapseFrame(){
        elapsedFrames += 1;
        if (elapsedFrames >= frames){
            // need to evolve
            type = AdvanceDice(type);
            sides = GetSides(type);
            frames = GetFrames(sides);
            elapsedFrames = 0;
        }
    }

    public DiceType AdvanceDice(DiceType type){
        switch (type)
        {
            case D20: D12;
            case D12: D10;
            case D10: D8;
            case D8: D6;
            case D6: D4;
            case D4: D0;
            default: D0;
        }
    }

    public int GetSides(DiceType type){
        switch (type)
        {
            case D20: 20;
            case D12: 12;
            case D10: 10;
            case D8: 8;
            case D6: 6;
            case D4: 4;
            default: 0;
        }
    }

}
