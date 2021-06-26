using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "DIASPRITES", menuName = "DIASPRITES", order = 0)]
public class DiaSprites : ScriptableObject
{
    public Sprite[] expressions = new Sprite[4];
}
