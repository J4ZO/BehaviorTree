using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    
    [Header("Actions")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference runAction;
    
    [Header("Camera")]
    [SerializeField] private Camera cameraRef;
    private Transform _cameraPosition;
    
    [Header("Variables")]
    private Vector3 _destination;
    private Vector2 _movementInput;

    
    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _cameraPosition = cameraRef.transform;
    }

    private void Update()
    {
        if(runAction.action.IsPressed()) _movement.IncreaseSpeed();
        else _movement.ResetSpeed();
    }


    void FixedUpdate()
    {
       _movementInput = moveAction.action.ReadValue<Vector2>();
       Debug.Log(_movementInput);
       _destination = _cameraPosition.forward  * _movementInput.y + _cameraPosition.right * _movementInput.x;
       
       _movement.Movement(_destination);
       
       Quaternion targetRotation = Quaternion.Euler(0f, _cameraPosition.eulerAngles.y, 0f);
       _movement.Rotation(targetRotation);
    }
}
