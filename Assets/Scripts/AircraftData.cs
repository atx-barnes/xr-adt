using System;
using UnityEngine;

[Serializable]
public class AircraftData
{
    [field: SerializeField]
    private string _id;
    public string Id { get => _id; set => _id = value; }

    [field: SerializeField]
    private double _pitch;
    public double Pitch { get => _pitch; set => _pitch = value * Mathf.Rad2Deg; }

    [field: SerializeField]
    private double _altitude;
    public double Altitude { get => _altitude; set => _altitude = value; }

    [field: SerializeField]
    private double _heading;
    public double Heading { get => _heading; set => _heading = value * Mathf.Rad2Deg; }

    [field: SerializeField]
    private double _longitude;
    public double Longitude { get => _longitude; set => _longitude = value * Mathf.Rad2Deg; }

    [field: SerializeField]
    private double _latitude;
    public double Latitude { get => _latitude; set => _latitude = value * Mathf.Rad2Deg; }

    [field: SerializeField]
    private double _airspeed;
    public double Airspeed { get => _airspeed; set => _airspeed = value; }

    [field: SerializeField]
    private double _bank;
    public double Bank { get => _bank; set => _bank = value * Mathf.Rad2Deg; }
}