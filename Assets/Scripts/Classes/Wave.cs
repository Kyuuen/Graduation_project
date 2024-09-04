using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Wave
{
    public GameObject[] enemy = new GameObject[4];
    public int[] count = new int[4];
    public float[] rate = new float [4];
}
