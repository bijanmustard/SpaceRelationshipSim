using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggers : MonoBehaviour
{
    [Header("Day 1's Events")]
    public bool dayOneStart;
    public bool daxMovesToBarDay1;
    public bool daxDeath;
    public bool dayOneEnd;

    [Header("Day 2's Events")]
    public bool dayTwoStart;
    public int brycesConfidenceCounter = 0;
    public bool dayTwoEnd;

    [Header("Misc")]
    public int trashCan = 0;



}
