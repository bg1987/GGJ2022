using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Law", menuName = "Law", order = 1)]
public class Law : ScriptableObject
{
    public RuleGroup[] rules;
    public bool heaven;
}