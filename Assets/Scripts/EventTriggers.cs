using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggers : MonoBehaviour
{
    [Header("Day 1's Events")]
    public bool dayOneStart;
    public bool dayOneEnd;

    [Header("Day 2's Events")]
    public bool dayTwoStart;
    public bool dayTwoEnd;

    [Header("Dax's Events")]
    public bool daxMoves;
    public string daxMovesScene;
    public bool daxDeath;

    [Header("Bryces' Events")]
    public bool bryceMoves;
    public string bryceMovesScenes;
    public int brycesConfidenceCounter = 0;


    [Header("Misc")]
    public int trashCan = 0;



}
