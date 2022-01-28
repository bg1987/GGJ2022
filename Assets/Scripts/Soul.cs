using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public Trait[] traits;

    public List<SpriteRenderer> icons;

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

    public void DrawTraits()
    {
        foreach (Trait trait in traits)
        {
            icons[0].sprite = trait.image;
        }
    }
}
