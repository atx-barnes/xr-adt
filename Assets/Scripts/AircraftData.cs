using System;
using UnityEngine;

[Serializable]
public class AircraftData
{
    [field: SerializeField]
    public int ID { get; set; }

    [field: SerializeField]
    public double Pitch { get; set; }

    [field: SerializeField]
    public int Altitude { get; set; }

    [field: SerializeField]
    public double Heading { get; set; }

    [field: SerializeField]
    public double Longitude { get; set; }

    [field: SerializeField]
    public double Latitude { get; set; }

    [field: SerializeField]
    public int Airspeed { get; set; }
}