using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;

public class Airbase : MonoBehaviour
{
    public AircraftScriptableObject AircraftData;
    public MapRenderer MapRenderer;

    private Transform aircraft;

    public void Start()
    {
        aircraft = Instantiate(AircraftData.AircraftPrefab).transform;
        aircraft.position = new Vector3(0, 1, 0);
    }

    private void Update()
    {
        Debug.Log($"{AircraftData.aircraftData.Latitude * Mathf.Rad2Deg}, {AircraftData.aircraftData.Longitude * Mathf.Rad2Deg}");
        MapRenderer.Center = new LatLon(AircraftData.aircraftData.Latitude * Mathf.Rad2Deg, AircraftData.aircraftData.Longitude * Mathf.Rad2Deg);
        aircraft.rotation = Quaternion.Euler((float)AircraftData.aircraftData.Pitch * Mathf.Rad2Deg, (float)AircraftData.aircraftData.Heading * Mathf.Rad2Deg, (float)AircraftData.aircraftData.Bank * Mathf.Rad2Deg);
    }
}
