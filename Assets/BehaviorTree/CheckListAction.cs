using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckList", story: "Create item from [list] if is missing using [controller]", category: "Action", id: "1094569c03f041b2f52ffe7dea8667b7")]
public partial class CheckListAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> List;
    [SerializeReference] public BlackboardVariable<FoodController> Controller;
    [SerializeReference] public BlackboardVariable<int> ListValue;

    protected override Status OnStart()
    {
        if (Controller.Value.SetActiveItem(ListValue.Value))
        {
            Debug.Log("Item created");
        }
        
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

