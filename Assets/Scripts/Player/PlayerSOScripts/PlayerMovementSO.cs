using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/PlayerConfig/PlayerMovementConfig")]
public class PlayerMovementSO : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float JumpPower { get; private set; }
}
