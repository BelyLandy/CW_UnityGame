using UnityEngine;

public struct PlayerInputData
{
    public Vector2 movementInput;
    public bool isBaseAttacking;

    public PlayerInputData(Vector2 _movementInput, bool _isBaseAttacking)
    {
        movementInput = _movementInput;
        isBaseAttacking = _isBaseAttacking;
    }
}