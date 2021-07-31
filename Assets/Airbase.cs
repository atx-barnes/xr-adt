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
    public float MapZoomMaxLimit = 13.5f;
    public float MapZoomMinMimit = 18;
    public float AircraftModelMaxYPosition = 1;
    public float AircraftModelMinYPosition = 0.1f;
    private Transform aircraft;

    public void Start()
    {
        aircraft = Instantiate(Aircraft.AircraftPrefab, new Vector3(0 ,AircraftModelMinYPosition ,0), Quaternion.identity, MapRenderer.transform).transform;
        aircraft.localPosition = new Vector3(0,AircraftModelMinYPosition , 0);
    }

    private void Update()
    {
        MapRenderer.Center = new LatLon(Aircraft.Data.Latitude, Aircraft.Data.Longitude);
        MapRenderer.ZoomLevel = MapZoomMinMimit - RemapValue(0, AltitudeLimit, MapZoomMaxLimit, MapZoomMinMimit, (float)Aircraft.Data.Altitude) + MapZoomMaxLimit;
        aircraft.localRotation = Quaternion.Euler((float)Aircraft.Data.Pitch, (float)Aircraft.Data.Heading, (float)Aircraft.Data.Bank);
        aircraft.localPosition = new Vector3(0, RemapValue(0, AltitudeLimit, AircraftModelMinYPosition, AircraftModelMaxYPosition, (float)Aircraft.Data.Altitude), 0);
    }

    public float RemapValue(float oMin, float oMax, float nMin, float nMax, float oValue)
    {
        float oRange = (oMax - oMin);
        float nRange = (nMax - nMin);
        float nValue = (((oValue - oMin) * nRange) / oRange) + nMin;
        return (Mathf.Clamp(nValue, nMin, nMax));
    }
}
