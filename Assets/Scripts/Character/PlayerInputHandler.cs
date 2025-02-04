using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions input;

    private Vector2 movementInput;

    private bool isBaseAttacking;

    private InputAction _jump;
    private InputAction _baseAttack;
    private InputAction _pickUpItem;
    private InputAction _useItem;
    private InputAction _scrollItemLeft;
    private InputAction _scrollItemRight;
    private InputAction _specAttackLeft;
    private InputAction _specAttackRight;

    private PlayerMovement characterMovement;
    private ColliderBaseAttack characterBaseAttack;
    private ColliderPickUpItems pickUpItems;
    
    public event Action<PlayerInputData> OnInputChanged;

    private void Awake()
    {
        characterMovement = GetComponent<PlayerMovement>();
        characterBaseAttack = GetComponentInChildren<ColliderBaseAttack>();
        pickUpItems = GetComponentInChildren<ColliderPickUpItems>();

        input = new PlayerInputActions();
        
        _jump = input.Player_1.Jump;
        _baseAttack = input.Player_1.BaseAttack;
        _pickUpItem = input.Player_1.PickUpItem;
        _useItem = input.Player_1.UseItem;
        _scrollItemLeft = input.Player_1.ScrollItemLeft;
        _scrollItemRight = input.Player_1.ScrollItemRight;
        _specAttackLeft = input.Player_1.SpecAttackLeft;
        _specAttackRight = input.Player_1.SpecAttackRight;
    }

    private void OnEnable()
    {
        input.Player_1.Enable();
        
        _jump.performed += PerformJump;
        _baseAttack.performed += PerformBaseAttack;
        _pickUpItem.performed += PerformPickUpItem;
        _useItem.performed += PerformUseItem;
        _scrollItemLeft.performed += PerformScrollItemLeft;
        _scrollItemRight.performed += PerformScrollItemRight;
        _specAttackLeft.performed += PerformSpecAttackLeft;
        _specAttackRight.performed += PerformSpecAttackRight;
    }

    private void OnDisable()
    {
        input.Player_1.Disable();
        
        _jump.performed -= PerformJump;
        _baseAttack.performed -= PerformBaseAttack;
        _pickUpItem.performed -= PerformPickUpItem;
        _useItem.performed -= PerformUseItem;
        _scrollItemLeft.performed -= PerformScrollItemLeft;
        _scrollItemRight.performed -= PerformScrollItemRight;
        _specAttackLeft.performed -= PerformSpecAttackLeft;
        _specAttackRight.performed -= PerformSpecAttackRight;
    }

    private void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        TriggerInputEvent();
    }

    private void TriggerInputEvent() => OnInputChanged?.Invoke(new PlayerInputData(movementInput, isBaseAttacking));

    private void PerformJump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jump!");
        //TriggerInputEvent();
    }

    private void PerformBaseAttack(InputAction.CallbackContext ctx)
    {
        isBaseAttacking = ctx.ReadValueAsButton();
        TriggerInputEvent();
    }

    private void PerformPickUpItem(InputAction.CallbackContext ctx)
    {
        Debug.Log("Pick Up Item!");
        // Взаимодействие с CharacterPickUpItems
        //pickUpItems.PickUpItem();
    }

    private void PerformUseItem(InputAction.CallbackContext ctx)
    {
        Debug.Log("Use Item!");
        // Логика использования предмета
    }

    private void PerformScrollItemLeft(InputAction.CallbackContext ctx)
    {
        Debug.Log("Scroll Item Left!");
        // Логика для прокрутки предметов
    }

    private void PerformScrollItemRight(InputAction.CallbackContext ctx)
    {
        Debug.Log("Scroll Item Right!");
        // Логика для прокрутки предметов
    }

    private void PerformSpecAttackLeft(InputAction.CallbackContext ctx)
    {
        Debug.Log("Special Attack Left!");
        // Логика для специальной атаки
    }

    private void PerformSpecAttackRight(InputAction.CallbackContext ctx)
    {
        Debug.Log("Special Attack Right!");
        // Логика для специальной атаки
    }
}
