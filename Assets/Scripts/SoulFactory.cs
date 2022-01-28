using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulFactory : MonoBehaviour
{
    
    public TraitsCollection collection;
    
    public int traitsPerSoul = 3;
    public GameObject soulPrefab;

    public bool Create;

    private void Update()
    {
        if (Create)
        {
            CreateSoul();
        }
        Create = false;
    }

    public Soul CreateSoul()
    {
        Transform firstSlot = Queue.Instance.slots[Queue.Instance.slots.Count-1];
        var soulObject = Instantiate(soulPrefab,firstSlot,false);

        var soul = soulObject.GetComponent<Soul>();
        soul.traits = RandomizeTraits();
        return soul;
    }

    Trait[] RandomizeTraits()
    {
        var result = new Trait[traitsPerSoul];
        var tempColl = new List<Trait>(collection.traits);
        for (int i = 0; i < traitsPerSoul; i++)
        {
            var selectedIndex = Random.Range(0, tempColl.Count);
            result[i] = tempColl[selectedIndex];
            tempColl.RemoveAt(selectedIndex);
        }

        return result;
    }
}
