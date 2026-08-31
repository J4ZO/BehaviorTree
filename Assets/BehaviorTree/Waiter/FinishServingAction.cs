using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FinishServing", story: "Served [Item]", category: "Action", id: "0d80c226746cbf4dcd6d18e21f62f789")]
public partial class FinishServingAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Item;
    [SerializeReference] public BlackboardVariable<GameObject> CurrentItem;
    [SerializeReference] public BlackboardVariable<FoodController> Controller;

    protected override Status OnStart()
    {
        CurrentItem.Value = null;
        if(Item.Value.transform.childCount > 0) Controller.Value.DestroyItem(Item.Value.transform.GetChild(0).gameObject);
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

