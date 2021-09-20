using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Maths 
{
    public static bool PointInCircle(float px, float py, float cx, float cy, float r)
    {
        float distX = px - cx;
        float distY = py - cy;

        float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

        if (distance <= r)
        {
            return true;
        }
        return false;
    }
}
