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

    public LatLon BaseLocation => baseLatLon.ToLatLon();

    public AircraftScriptableObject[] AircraftData;

    public Dictionary<AircraftScriptableObject, GameObject> Aircrafts = new Dictionary<AircraftScriptableObject, GameObject>();

    public void AddAircraft(AircraftScriptableObject data, GameObject gameObject)
    {
        Aircrafts.Add(data, gameObject);
    }

    public bool TryGetAircraftGameObject(AircraftScriptableObject data, out GameObject aircraftObject)
    {
        return Aircrafts.TryGetValue(data, out aircraftObject);
    }
}