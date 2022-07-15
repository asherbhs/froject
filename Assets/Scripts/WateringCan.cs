using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : ITool
{
    public void DoWorkOn(Tree tree) { tree.Water(); }
}