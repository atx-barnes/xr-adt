using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;

public class Airbase : MonoBehaviour
{
    public AircraftScriptableObject Aircraft;
    public MapRenderer MapRenderer;
    public float AltitudeLimit = 3000;
    public float MapZoomMinLimit = 13.5f;
    public float MapZoomMaxMimit = 18;
    public float AircraftModelMaxYPosition = 1;
    public float AircraftModelMinYPosition = 0.1f;
    private Transform aircraft;

    public void Start()
    {
        aircraft = Instantiate(Aircraft.AircraftPrefab, new Vector3(0,AircraftModelMinYPosition,0), Quaternion.identity, MapRenderer.transform).transform;
        aircraft.localPosition = new Vector3(0, AircraftModelMinYPosition, 0);
    }

    private void Update()
    {
        MapRenderer.Center = new LatLon(Aircraft.Data.Latitude * Mathf.Rad2Deg, Aircraft.Data.Longitude * Mathf.Rad2Deg);
        MapRenderer.ZoomLevel = (MapZoomMaxMimit - RemapValue(0, AltitudeLimit, MapZoomMinLimit, MapZoomMaxMimit, (float)Aircraft.Data.Altitude)) + MapZoomMinLimit;
        aircraft.localRotation = Quaternion.Euler((float)Aircraft.Data.Pitch * Mathf.Rad2Deg, (float)Aircraft.Data.Heading * Mathf.Rad2Deg, (float)Aircraft.Data.Bank * Mathf.Rad2Deg);
        aircraft.localPosition = new Vector3(0, RemapValue(0, AltitudeLimit, AircraftModelMinYPosition, AircraftModelMaxYPosition, (float)Aircraft.Data.Altitude), 0);
    }

    public float RemapValue(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float OldRange = (oldMax - oldMin);
        float NewRange = (newMax - newMin);
        float NewValue = (((oldValue - oldMin) * NewRange) / OldRange) + newMin;
        return (Mathf.Clamp(NewValue, newMin, newMax));
    }
}
