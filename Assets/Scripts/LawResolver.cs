using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LawResolver : MonoBehaviour
{
    public bool EvaluateSoul(Law law, Soul soul, bool toHeaven)
    {
        foreach (var rule in law.rules)
        {
            if (EvaluateRule(rule, soul) && (toHeaven == law.heaven))
            {
                return true;
            }
        }
        return false;
       }

    bool EvaluateRule(RuleGroup rules, Soul soul)
    {
        bool result = true;
        foreach (var trait in rules.traits)
        {
            if (rules.not)
            {
                result = result && !soul.HasTrait(trait);
            }
            else
            {
                result = result && soul.HasTrait(trait);
            }
        }

        return result;
    }
}
