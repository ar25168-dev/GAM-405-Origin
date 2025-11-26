using UnityEngine;

public enum TorchlightState
{
    Off, // When the torch is off
    On, // When the torch is on
    Dead, // When there is no battery left
}
public class TorchBatteryManager : MonoBehaviour
{
    [Tooltip("The speed that the battery is lost at.")] [Range(0f, 2f)] [SerializeField] float batteryLossTick = 0.5f;
    
    [Tooltip("This is the amount of battery that the player starts with.")][SerializeField] int startBattery = 100;

    [Tooltip("This is the amount that the player currently has.")] public int currentBattery;

    [Tooltip("The state of the torch.")] public TorchlightState state;

    [Tooltip("Is the torch on?")] private bool torchIsOn;

    [Tooltip("They key that is required to be pressed to turn on/off the torch.")] [SerializeField] KeyCode ToggleKey = KeyCode.Q;

    private void Start()
    {
        currentBattery = startBattery; // Set the current battery to the start battery when the game starts

        InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick); // Loses the battery at set interval of time.
    }

    private void Update()
    {
        if (Input.GetKeyDown(ToggleKey)) ToggleTorchlight(); // Toggles the falshlight
    }

    public void GainBattery(int amount) // Handles the gaining of battery
    {
        if (currentBattery + amount > startBattery)
           currentBattery = startBattery; // Automatically cause the battery to be the maximum.
        else
           currentBattery += amount; //Adds the <amount> of battery to the current battery.
    }

    public void LoseBattery(int amount) // Hnadles the loss of battery
    {
        if (state == TorchlightState.On) currentBattery--; // Subsracts the battery by 1, if the tirch is on.
    }

    private void ToggleTorchlight() // Toggles the on/off state of the torch
    {
        torchIsOn = !torchIsOn;

        if (state == TorchlightState.Dead) torchIsOn = false; // Automatically overrides the state, if there's no battery
    }

    // Continue video from 9:30

}
