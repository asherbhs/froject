using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiceType
{
    D20 = 20,
    D12 = 12,
    D10 = 10,
    D8  = 8,
    D6  = 6,
    D4  = 4,
    Expired = 0
}

public class Dice
{
    [SerializeField] public DiceType diceType;
    [SerializeField] private float timeSinceLastChange;

    public Dice()
    {
        diceType = DiceType.D20;
        timeSinceLastChange = 0f;
    }

    public bool IsExpired() { return diceType == DiceType.Expired; }

    public void FixedUpdate(float dt)
    {
        timeSinceLastChange += dt;
        if (timeSinceLastChange >= (float) diceType)
        {
            switch (diceType)
            {
                case DiceType.D20: diceType = DiceType.D12;
                case DiceType.D12: diceType = DiceType.D10;
                case DiceType.D10: diceType = DiceType.D8;
                case DiceType.D8:  diceType = DiceType.D6;
                case DiceType.D6:  diceType = DiceType.D4;
                default:           diceType = DiceType.Expired;
            }
            timeSinceLastChange = 0;
        }
    }
}
