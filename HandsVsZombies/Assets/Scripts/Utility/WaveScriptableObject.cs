using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Zombie wave", order = 1)]
public class WaveScriptableObject : ScriptableObject
{
    public int ZombieCount = 5;
    public float WaveLenght = 10;
    public float PauseLenght = 5;
}
