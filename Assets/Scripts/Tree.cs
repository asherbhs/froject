using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status { Rotten, Healthy };

public class DiceTree : MonoBehaviour
{
    public Dice dice;
    private Status status;

    public float timeSinceLastWater;
    private const float timeToBecomeThirsty = 10;

    private float timeSinceDiceExpired;
    private const float timeToGrowNewDice = 10;

    void Start()
    {
        status = Status.Healthy;
        timeSinceLastWater = 0f;
    }

    private bool IsThirsty()
    {
        return timeSinceLastWater >= timeToBecomeThirsty;
    }

    public void Water() { timeSinceLastWater = 0; }

    void FixedUpdate()
    {
        // update all the times
        float dt = Time.deltaTime;
        timeSinceLastWater += dt;
        if (dice.IsExpired()) timeSinceDiceExpired += dt;

        // update the dice
        dice.FixedUpdate(dt);
        if (dice.IsExpired())
        {
            status = Status.Rotten;
            timeSinceDiceExpired = 0f;
        }
    }
}
