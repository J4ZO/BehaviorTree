using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TakeItem", story: "Take Item from [controller]", category: "Action", id: "2c37f93ccf6779674c248da7a9d72229")]
public partial class TakeItemAction : Action
{
    [SerializeReference] public BlackboardVariable<FoodController> Controller;
    [SerializeReference] public BlackboardVariable<int> ListValue;
    [SerializeReference] public BlackboardVariable<GameObject> ItemPosition;
    [SerializeReference] public BlackboardVariable<GameObject> CurrentItem;
    

    protected override Status OnStart()
    {
        CurrentItem.Value = Controller.Value.DisableItem(ListValue.Value);
        Controller.Value.InstantiateItem(CurrentItem.Value, ItemPosition.Value);
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

