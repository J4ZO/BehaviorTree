using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")] 
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    private float _initialSpeed;
    private Rigidbody _rb;
    
    [Header("Lerp Speed")] 
    [SerializeField] private float transitionTime;
    [SerializeField] private AnimationCurve curve;
    private Coroutine _speedTransition;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _initialSpeed = speed;
    }

    public void Movement(Vector3 movement)
    {
        movement *= speed;
        _rb.linearVelocity = new  Vector3(movement.x, _rb.linearVelocity.y, movement.z);
    }
    
    public void IncreaseSpeed()
    {
        if(_speedTransition != null) StopCoroutine(_speedTransition);
        _speedTransition = StartCoroutine(LerpSpeed(runningSpeed));
    }

    public void ResetSpeed()
    {
        if(_speedTransition != null) StopCoroutine(_speedTransition);
        _speedTransition = StartCoroutine(LerpSpeed(_initialSpeed));
    }

    public void Rotation(Quaternion rotation)
    {
        _rb.rotation = rotation;
    }
    
    private IEnumerator LerpSpeed(float targetSpeed)
    {
        var time = 0f;
        var startSpeed = speed;
        while (time < transitionTime)
        {
            time += Time.deltaTime;
            speed =  Mathf.Lerp(startSpeed, targetSpeed, curve.Evaluate(time / transitionTime));
            yield return null;
        }
        speed = targetSpeed;
        _speedTransition = null;
    }
}
