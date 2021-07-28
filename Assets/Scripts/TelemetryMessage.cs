using System;

[Serializable]
public class TelemetryMessage
{
    public string Id { get; set; }
    public double Pitch { get; set; }
    public double Altitude { get; set; }
    public double Heading { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Airspeed { get; set; }
    public double Bank { get; set; }
}