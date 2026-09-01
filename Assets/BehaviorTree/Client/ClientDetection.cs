using System;
using UnityEngine;
using Unity.Behavior;
public class ClientDetection : MonoBehaviour
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
        
        if (_behaviorGraphAgent.GetVariable("ClientStates", out BlackboardVariable<ClientStates> clientStates))
        {
            Debug.Log(clientStates.Value);
            clientStates.Value =  ClientStates.TalkingPlayer;
            
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
        
        if (_behaviorGraphAgent.GetVariable("ClientStates", out BlackboardVariable<ClientStates> clientStates))
        {
            clientStates.Value = ClientStates.Eating; 
            
            
        }
    }
}
