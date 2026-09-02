using System;
using UnityEngine;
using Unity.Behavior;
public class GuardDetection : MonoBehaviour
{
    private BehaviorGraphAgent _behaviorGraphAgent;
    private void Start()
    {
        _behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        Debug.Log("Player entered");
        if (_behaviorGraphAgent.GetVariable("IsTalkingToThePlayer",
                out BlackboardVariable<bool> isTalkingToThePlayer))
        {
            isTalkingToThePlayer.Value = true;
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (_behaviorGraphAgent.GetVariable("IsTalkingToThePlayer",
                out BlackboardVariable<bool> isTalkingToThePlayer))
        {
            isTalkingToThePlayer.Value = false;
        }
        
    }
}
