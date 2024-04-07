using UnityEngine;

public class StoneFish : Fish
{
    public override void Init()
    {
        HealthToGive = -15;
        ScoreWhenEaten = -70;
    }

    public override void TriggerEatenEffect()
    {
        _playerShark.SpeedFactor += 0.5f;
    }
}
