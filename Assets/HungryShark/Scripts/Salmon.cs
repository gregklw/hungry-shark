using UnityEngine;

public class Salmon : Fish
{
    public override void Init()
    {
        HealthToGive = 30;
        ScoreWhenEaten = 50;
    }

    public override void TriggerEatenEffect()
    {
        _playerShark.SpeedFactor -= 0.5f;
    }
}
