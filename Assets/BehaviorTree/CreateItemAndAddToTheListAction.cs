using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Create Item and Add to the List", story: "[From] List Create missing item to [OriginalList]", category: "Action", id: "abd213aad7e0d434deedb08c42ffbc7f")]
public partial class CreateItemAndAddToTheListAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> From;
    [SerializeReference] public BlackboardVariable<List<GameObject>> OriginalList;

    protected override Status OnStart()
    {
        CheckList();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }

    private void CheckList()
    {
        foreach (var bottleCopy in From.Value)
        {
            if (!OriginalList.Value.Contains(bottleCopy))
            {
                OriginalList.Value.Add(bottleCopy);
            }
        }

        foreach (var bottle in OriginalList.Value)
        {
            if(!bottle.activeSelf) bottle.SetActive(true);
        }
    }
}

