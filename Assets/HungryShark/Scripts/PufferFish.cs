using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : Fish
{
    public override void Init() 
    {
        HealthToGive = -20;
    }
    public override void TriggerEatenEffect()
    {
        _playerShark.SpeedFactor = 1.2f;
    }
}
