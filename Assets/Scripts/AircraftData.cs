using System;
using UnityEngine;

[Serializable]
public class AircraftData
{
    [field: SerializeField]
    public string Id { get; set; }

    [field: SerializeField]
    public double Pitch { get; set; }

    [field: SerializeField]
    public double Altitude { get; set; }

    [field: SerializeField]
    public double Heading { get; set; }

    [field: SerializeField]
    public double Longitude { get; set; }

    [field: SerializeField]
    public double Latitude { get; set; }

    [field: SerializeField]
    public double Airspeed { get; set; }

    [field: SerializeField]
    public double Bank { get; set; }
}