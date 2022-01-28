using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "RuleGroup", menuName = "Rule Group", order = 1)]
public class RuleGroup : ScriptableObject {
    public Trait[] traits;
    public bool not;
}