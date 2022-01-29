using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public Trait[] traits;

    public List<SpriteRenderer> icons;

    public SpriteRenderer bodySprite;
    public SpriteRenderer headSprite;
    public SpriteRenderer shirtSprite;
    public SpriteRenderer faceSprite;
    public SpriteMask bodyMask;
    public SpriteMask headMask;

    public Animator floatAnimator;

    void Start()
    {
        floatAnimator.speed = Random.Range(0.9f, 1.1f);
        floatAnimator.Play("float", 0, Random.Range(0f, 1f));
    }

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
        for (int i = 0; i < traits.Length; i++)
        {
            icons[i].sprite = traits[i].image;
        }
    }

    public void SetLook(Sprite body, Sprite head, Sprite shirt, Sprite face)
    {
        bodySprite.sprite = body;
        headSprite.sprite = head;
        shirtSprite.sprite = shirt;
        faceSprite.sprite = face;
        bodyMask.sprite = body;
        headMask.sprite =    head;
        Debug.Log(body);
        Debug.Log(head);
        Debug.Log(shirt);
        Debug.Log(face);
    }
}
