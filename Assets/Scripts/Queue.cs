using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{

    private static Queue _instance;

    public static Queue Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public List<Transform> slots;

    private void Start()
    {
        for (int i = transform.childCount -1 ; i >= 0; i--)
        {
            slots.Add(transform.GetChild(i));
        }
    }

    public void Progress()
    {
        for (int i = 1; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
            {
                GameObject currentSoul = slots[i].transform.GetChild(0).gameObject;
                currentSoul.transform.SetParent(slots[i-1],false);
                if (i < 4)
                {
                    currentSoul.transform.GetChild(0).GetComponent<Animator>().Play("soul_climb", 1);
                }
                else
                {
                    currentSoul.transform.GetChild(0).GetComponent<Animator>().Play("soul_move", 1);
                }
            }
        }
    }
}
