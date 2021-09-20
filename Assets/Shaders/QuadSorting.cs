using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSorting : MonoBehaviour
{

    public string sortingLayerName = string.Empty; 
    public int orderInLayer = 0;
    public Renderer MyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SetSortingLayer();
    }

    void SetSortingLayer()
    {
        if (sortingLayerName != string.Empty)
        {
            MyRenderer.sortingLayerName = sortingLayerName;
            MyRenderer.sortingOrder = orderInLayer;
        }
    }
}
