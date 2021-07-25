using System.Collections.Generic;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using UnityEngine;

[CreateAssetMenu(fileName = "AirbaseData", menuName = "Scriptable Objects/Airbase Data", order = 1)]
public class AirbaseData : ScriptableObject
{
    [Header("Airbase Info")]
    public string AirbaseName;

    [SerializeField]
    private LatLonWrapper baseLatLon;

    public LatLon SiteLocation => baseLatLon.ToLatLon();

    public AircraftScriptableObject[] aircraftData;

    public Dictionary<AircraftScriptableObject, GameObject> windTurbines = new Dictionary<AircraftScriptableObject, GameObject>();

    public void AddAircraft(AircraftScriptableObject data, GameObject gameObject)
    {
        windTurbines.Add(data, gameObject);
    }

    public bool TryGetTurbineGameObject(AircraftScriptableObject data, out GameObject aircraftObject)
    {
        return windTurbines.TryGetValue(data, out aircraftObject);
    }
}