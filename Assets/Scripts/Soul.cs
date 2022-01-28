using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public Trait[] traits;

    public bool HasTrait(Trait t)
    {
        for (int i = 0; i < traits.Length; i++)
        {
            if (traits[i].traitName == t.traitName)
            {
                return true;
            }
        }
        return false;
    }
}
