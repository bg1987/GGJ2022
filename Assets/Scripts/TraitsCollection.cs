using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TraitsCollection", menuName = "Traits Collection", order = 1)]
public class TraitsCollection : ScriptableObject
{
    public Trait[] traits;
}