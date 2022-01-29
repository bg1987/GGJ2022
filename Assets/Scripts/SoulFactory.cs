using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulFactory : MonoBehaviour
{
    
    public TraitsCollection collection;
    
    public int traitsPerSoul = 3;
    public int minTraitsPerSoul = 1;
    public int maxTraitsPerSoul = 4;
    public GameObject soulPrefab;

    public bool Create;

    [Header("Costmetics")]
    public List<Sprite> bodies;
    public List<Sprite> heads;
    public List<Sprite> shirts;
    public List<Sprite> faces;
    public List<Sprite> props;

    int bodyCount;
    int headCount;
    int shirtCount;
    int faceCount;
    int propCount;

    void Start()
    {
        bodyCount = bodies.Count;
        headCount = heads.Count;
        shirtCount = shirts.Count;
        faceCount = faces.Count;
        propCount = props.Count;
    }

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
        soul.DrawTraits();
        Sprite newBody = bodies[Random.Range(0, bodyCount)];
        Sprite newHead = heads[Random.Range(0, headCount)];
        Sprite newShirt = shirts[Random.Range(0, shirtCount)];
        Sprite newFace = faces[Random.Range(0, faceCount)];
        soul.SetLook(newBody, newHead, newShirt, newFace);
        return soul;
    }

    Trait[] RandomizeTraits()
    {
        int numberOfTraits = Random.Range(minTraitsPerSoul, maxTraitsPerSoul+1);
        var result = new Trait[numberOfTraits];
        var tempColl = new List<Trait>(collection.traits);
        for (int i = 0; i < numberOfTraits; i++)
        {
            var selectedIndex = Random.Range(0, tempColl.Count);
            result[i] = tempColl[selectedIndex];
            tempColl.RemoveAt(selectedIndex);
        }
      
        return result;
    }

    private void SetLook(Soul soul)
    {
        Sprite newBody = bodies[Random.Range(0, bodyCount)];
        Sprite newHead = heads[Random.Range(0, headCount)];
        Sprite newShirt = shirts[Random.Range(0, shirtCount)];
        Sprite newFace = faces[Random.Range(0, faceCount)];
        soul.SetLook(newBody, newHead, newShirt, newFace);
    }
}
