using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawFactory : MonoBehaviour
{
    public TraitsCollection collection;
    public GameObject ruleGroupPrefab;
    public Transform mainContainer;
    public GameObject heavenMarker;
    public GameObject hellMarker;
    public float chanceHeaven = 1;
    public int minTraits = 3;
    public int maxTraits = 6;
    public int maxRuleGroupSize = 3;    
        
    public bool create;

    // Update is called once per frame
    void Update()
    {
        if (create)
        {
            CreateLaw();
        }
        create = false;
    }

    public Law CreateLaw()
    {
        CleanContainer();
        var law = Generate();
        
        heavenMarker.SetActive(law.heaven);
        hellMarker.SetActive(!law.heaven);
        
        foreach (var ruleGroup in law.rules)
        {
            InstantiateRuleGroup(ruleGroup);
        }

        return law;
    }

    private void CleanContainer()
    {
        foreach (Transform child in mainContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void InstantiateRuleGroup(RuleGroup ruleGroup)
    {
        var newRule = Instantiate(ruleGroupPrefab,mainContainer,false);
        var rc = newRule.GetComponent<RuleCanvas>();
        rc.ApplyRule(ruleGroup);
    }

    private Law Generate()
    {
        var generatedGroups = new List<RuleGroup>();

        var selectedTraitsCount = Random.Range(minTraits, maxTraits + 1);
        var selectedTraits = new List<Trait>();
        var tempColl = new List<Trait>(collection.traits);

        for (int i = 0; i < selectedTraitsCount; i++)
        {
            var selectedIndex = Random.Range(0, tempColl.Count);
            selectedTraits.Add(tempColl[selectedIndex]);
            tempColl.RemoveAt(selectedIndex);
        }

        //select how many groups we will have
        var maxGroups = selectedTraits.Count / maxRuleGroupSize + 1;
        var groups = Random.Range(0, maxGroups);

        //create the groups
        for (int i = 0; i < groups; i++)
        {
            //select the group size
            var groupSize = Random.Range(1, maxRuleGroupSize + 1);
            var group = ScriptableObject.CreateInstance<RuleGroup>();
            group.traits = new Trait[groupSize];
            //add the traits to the group
            for (int j = 0; j < groupSize; j++)
            {
                var selectedIndex = Random.Range(0, selectedTraits.Count);
                group.traits[j] = selectedTraits[selectedIndex];
                selectedTraits.RemoveAt(selectedIndex);
            }

            generatedGroups.Add(group);
        }

        //all leftover traits are set into single groups
        for (int i = 0; i < selectedTraits.Count; i++)
        {
            var group = ScriptableObject.CreateInstance<RuleGroup>();
            @group.traits = new Trait[] { selectedTraits[i] };
            generatedGroups.Add(@group);
        }

        var law = ScriptableObject.CreateInstance<Law>();
        law.rules = generatedGroups.ToArray();
        
        //randomize heaven/hell
        law.heaven = Random.value <= chanceHeaven;

        return law;
    }
}
