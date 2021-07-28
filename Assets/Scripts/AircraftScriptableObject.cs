using System;
using Microsoft.Geospatial;
using UnityEngine;

[CreateAssetMenu(fileName = "AircraftData", menuName = "Scriptable Objects/Aircraft Data")]
public class AircraftScriptableObject : ScriptableObject
{
    public GameObject AircraftPrefab;
    public Action onDataUpdated;
    public AircraftData aircraftData;
    public LatLon CurrentLocation { get; set; }
    public void UpdateData(AircraftData newAircraftData)
    {
        aircraftData = newAircraftData;
        onDataUpdated?.Invoke();
    }
}