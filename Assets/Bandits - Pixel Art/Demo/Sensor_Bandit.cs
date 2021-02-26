using UnityEngine;
using System.Collections;

public class Sensor_Bandit : MonoBehaviour {

    private int _counter;
    private float _disableTimeCounter;

    private void OnEnable()
    {
        _counter = 0;
    }

    public bool State()
    {
        return _counter > 0 && !(_disableTimeCounter > 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _counter++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _counter--;
    }

    private void Update()
    {
        _disableTimeCounter -= Time.deltaTime;
    }

    public void SetDisableTimerDuration(float duration)
    {
        _disableTimeCounter = duration;
    }
}
