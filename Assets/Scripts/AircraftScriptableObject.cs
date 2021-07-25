using System;
using Microsoft.Geospatial;
using UnityEngine;

[CreateAssetMenu(fileName = "AircraftData", menuName = "Scriptable Objects/Aircraft Data")]
public class AircraftScriptableObject : ScriptableObject
{
    public Action onDataUpdated;

    public AircraftData aircraftData;

    public void UpdateData(AircraftData newAircraftData)
    {
        aircraftData = newAircraftData;
        onDataUpdated?.Invoke();
    }

    public LatLon CurrentLocation { get; set; }
}