using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceType { D20, D12, D10, D8, D6, D4, D0 };

public class DiceScript : MonoBehaviour
{
    [SerializeField] public DiceType type;
    [SerializeField] private int sides;
    [SerializeField] private float time;
    [SerializeField] private float elapsedTime;

    public void GenerateStats(DiceType type)
    {
        this.type = type;
        this.sides = GetSides(type);
        time = sides;
        elapsedTime = 0;
    }

    public int GetFrames(int sides)
    {
        return sides * 50;
    }

    public void ElapseFrame(float time)
    {
        elapsedTime += time;
        if (elapsedTime >= time)
        {
            // need to evolve
            type = AdvanceDice(type);
            sides = GetSides(type);
            time = sides;
            elapsedTime = 0;
        }
    }

    public void Expire()
    {
        this.transform.parent.GetComponent<DiceTree>().Rot();
        Destroy(this.gameObject, 0f);
    }

    public DiceType AdvanceDice(DiceType type)
    {
        switch (type)
        {
            case DiceType.D20: return DiceType.D12;
            case DiceType.D12: return DiceType.D10;
            case DiceType.D10: return DiceType.D8;
            case DiceType.D8: return DiceType.D6;
            case DiceType.D6: return DiceType.D4;
            case DiceType.D4: return DiceType.D0;
            default: Expire(); return DiceType.D0;
        }
    }

    public int GetSides(DiceType type)
    {
        switch (type)
        {
            case DiceType.D20: return 20; 
            case DiceType.D12: return 12; 
            case DiceType.D10: return 10; 
            case DiceType.D8: return 8; 
            case DiceType.D6: return 6; 
            case DiceType.D4: return 4; 
            default: return 0;
        }
    }
}
