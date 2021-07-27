using Microsoft.Unity;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class ADTDataHandler : MonoBehaviour
{
    private SignalRService rService;

    public string Url = "";
    public AirbaseData airbaseData;

    private void Start()
    {
        this.RunSafeVoid(CreateServiceAsync);
    }

    private void OnDestroy()
    {
        if (rService != null)
        {
            rService.OnConnected -= HandleConnected;
            rService.OnTelemetryMessage -= HandleTelemetryMessage;
            rService.OnDisconnected -= HandleDisconnected;
        }
    }

    private void HandleTelemetryMessage(TelemetryMessage message)
    {
        // Finally update Unity GameObjects, but this must be done on the Unity Main thread.
        UnityDispatcher.InvokeOnAppThread(() =>
        {
            Debug.Log($"Telemetry Data Incoming For Twin {message.Id}...");
            foreach (AircraftScriptableObject aircraft in airbaseData.aircraftData)
            {
                if (aircraft.aircraftData.Id == message.Id)
                {
                    aircraft.UpdateData(CreateNewAircraftData(message));
                    return;
                }
            }
        });
    }

    private AircraftData CreateNewAircraftData(TelemetryMessage message)
    {
        AircraftData data = new AircraftData
        {
            Id = message.Id,
            Pitch = message.Pitch,
            Altitude = message.Altitude,
            Heading = message.Heading,
            Longitude = message.Longitude,
            Latitude = message.Latitude,
            Airspeed = message.Airspeed
        };

        return data;
    }

    private Task CreateServiceAsync()
    {
        rService = new SignalRService();
        rService.OnConnected += HandleConnected;
        rService.OnDisconnected += HandleDisconnected;
        rService.OnTelemetryMessage += HandleTelemetryMessage;

        return rService.StartAsync(Url);
    }

    private void HandleConnected(string obj)
    {
        Debug.Log("Connected");
    }

    private void HandleDisconnected()
    {
        Debug.Log("Disconnected");
    }
}