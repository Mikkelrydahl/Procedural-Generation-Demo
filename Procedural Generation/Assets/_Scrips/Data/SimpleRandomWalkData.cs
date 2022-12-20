using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SimpleRandomWalkParameters_",menuName = "GCG/SimpleRandomWalkData")]
public class SimpleRandomWalkData : ScriptableObject
                                   //Create Menu i Inspectoren
{
    public int iterations = 10, walkLength = 10;
    public bool startRandomlyEachIteration = true;


}
