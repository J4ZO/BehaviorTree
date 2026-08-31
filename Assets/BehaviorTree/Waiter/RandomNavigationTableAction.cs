using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RandomNavigationTable", story: "Select random from [TablesPositions] and move [self]", category: "Action", id: "3f8463c8d5360f1fc932232075c869ec")]
public partial class RandomNavigationTableAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> TablesPositions;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<GameObject> CurrentPosition;
    private NavMeshAgent agent;
    private int tablePosition;

    protected override Status OnStart()
    {
        if(TablesPositions.Value.Contains(CurrentPosition.Value)) return Status.Running;
        agent = Self.Value.GetComponent<NavMeshAgent>();
        tablePosition = Random.Range(0, TablesPositions.Value.Count);
        CurrentPosition.Value = TablesPositions.Value[tablePosition];
        agent.speed = Speed.Value;
        agent.SetDestination(TablesPositions.Value[tablePosition].transform.position);
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

