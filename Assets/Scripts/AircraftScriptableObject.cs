using System;
using Microsoft.Geospatial;
using UnityEngine;

[CreateAssetMenu(fileName = "AircraftData", menuName = "Scriptable Objects/Aircraft Data")]
public class AircraftScriptableObject : ScriptableObject
{
    public GameObject AircraftPrefab;
    public Action OnDataUpdated;
    public AircraftData Data;

    public void UpdateData(AircraftData data)
    {
        Data = data;
        OnDataUpdated?.Invoke();
    }
}