using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points1;
    public static Transform[] points2;

    void Awake()
    {
        points1 = new Transform[transform.Find("Waypoints").childCount];
        for(int i=0; i<points1.Length; i++)
        {
            points1[i] = transform.Find("Waypoints").GetChild(i);
        }
        
        points2 = new Transform[transform.Find("Waypoints (1)").childCount];
        if(points2 != null)
        {
            for (int i = 0; i < points2.Length; i++)
            {
                points2[i] = transform.Find("Waypoints (1)").GetChild(i);
            }
        }  
    }

    public static Transform GetWaypoint(int index, int waypointSetIndex)
    {
        if (waypointSetIndex == 1)
        {
            return points1[index];
        }
        else if (waypointSetIndex == 2)
        {
            return points2[index];
        }
        else
        {
            return null;
        }
    }

    public static int GetWaypointCount(int waypointSetIndex)
    {
        if (waypointSetIndex == 1)
        {
            return points1.Length;
        }
        else if (waypointSetIndex == 2)
        {
            return points2.Length;
        }
        else return 0;
    }
}
