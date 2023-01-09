/*
 * GridObject.cs
 * This class is on every GridPosition and keeps a list of all the game Objects that are in the game
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;

    private GridObject gridObject;
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }
    private void Update()
    {
        Debug.Log(gridObject);
        textMeshPro.text = gridObject.ToString();
    }

}
