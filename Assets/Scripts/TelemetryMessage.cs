using System;

[Serializable]
public class TelemetryMessage
{
    public int ID { get; set; }
    public double Pitch { get; set; }
    public int Altitude { get; set; }
    public double Heading { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public int Airspeed { get; set; }
}