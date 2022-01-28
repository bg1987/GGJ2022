using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Trait", menuName = "Trait", order = 1)]
public class Trait : ScriptableObject {
    public string traitName = "Trait";
    public Sprite image;
}