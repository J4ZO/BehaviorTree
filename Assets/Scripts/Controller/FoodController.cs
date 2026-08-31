using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodController : MonoBehaviour
{
    [SerializeField] private List<GameObject> platesList;
    [SerializeField] private List<GameObject> bottlesList;

    public List<GameObject> GetList(int i)
    {
        return i == 0 ? platesList : bottlesList;
    }

    public bool SetActiveItem(int i)
    {
        if (i == 0)
        {
            foreach (var plate in platesList)
            {
                if (plate.activeSelf) continue;
                plate.SetActive(true);
                return true;

            }
        }
        else
        {
            foreach (var bottle in bottlesList)
            {
                if (bottle.activeSelf) continue;
                bottle.SetActive(true);
                return true;

            }
        }
        
        return false;
    }

    public GameObject DisableItem(int i)
    {
        if (i == 0)
        {
            var index = Random.Range(0, platesList.Count);
            platesList[index].SetActive(false);
            return platesList[index];
            
        }
        else
        {
            var index = Random.Range(0, platesList.Count);
            bottlesList[index].SetActive(false);
            return bottlesList[index];
        }
    }

    public void InstantiateItem(GameObject item, GameObject parent)
    {
        var newItem = Instantiate(item, parent.transform, false);
        newItem.transform.localPosition = Vector3.zero;
        newItem.SetActive(true);
        
        Debug.Log("Instantiate Item " +  item.name + "Parent " + parent.name);
    }

    public void DestroyItem(GameObject item)
    {
        Destroy(item);
    }
    
}
