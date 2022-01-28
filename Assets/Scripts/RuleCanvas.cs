using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleCanvas : MonoBehaviour
{
    public GameObject traitPrefab;

    public Transform traitsContainer;

    public GameObject not;

    public void ApplyRule(RuleGroup rule)
    {
        not.SetActive(rule.not);
        foreach (var trait in rule.traits)
        {
            var x = Instantiate(traitPrefab, traitsContainer.transform, false);
            var traitImage = x.GetComponent<Image>();
            traitImage.sprite = trait.image;
        }
    }
}
