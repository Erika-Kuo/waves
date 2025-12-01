using UnityEngine;

public enum DayState { Day, Night }

public class DayStateManager : MonoBehaviour
{
    public DayState currentState = DayState.Day;
}