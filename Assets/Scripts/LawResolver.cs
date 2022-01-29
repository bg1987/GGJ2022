using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LawResolver : MonoBehaviour
{
    //true means a strike
    public bool EvaluateSoul(Law law, Soul soul, bool toHeaven)
    {
        Debug.Log(string.Format("Judging {0}",soul.gameObject.name));
        bool soulPassed;
        //required to enter heaven
        if (law.heaven)
        {
            //sending to heaven
            if (toHeaven)
            {
                soulPassed = MatchAnyRule(law, soul);
            }
            //sending to hell
            else
            {
                //doesnt fit any rule to heaven
                 soulPassed = !MatchAnyRule(law, soul);
            }
        }
        else
        {
            if (toHeaven)
            {
                soulPassed = !MatchAnyRule(law, soul);
            }
            else
            {
                soulPassed = MatchAnyRule(law, soul);
            }
        }

        return !soulPassed;
    }

    bool FailAllRules(Law law, Soul soul)
    {
        var result = true;
        foreach (var rule in law.rules)
        {
            result = result && !EvaluateRule(rule, soul);
        }

        return result;
    }

    bool MatchAnyRule(Law law, Soul soul)
    {
        foreach (var rule in law.rules)
        {
            if (!EvaluateRule(rule, soul))
            {
                return false;
            }
        }

        return true;
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
