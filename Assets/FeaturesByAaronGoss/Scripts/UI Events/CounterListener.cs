using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterListener : MonoBehaviour
{
    // This class will be LISTENING to the "Increase Counter" event
    // When the event is announced, this class will...
    // ...increase the counter
    // ...update the UI text

    [SerializeField] private int counter = 0;
    [SerializeField] private TMPro.TextMeshProUGUI counterUiText;

    private void OnEnable()
    {
        CounterAnnouncer.OnStartEvent += IncreaseCount;
    }

    private void OnDisable()
    {
        CounterAnnouncer.OnStartEvent -= IncreaseCount;
    }

    private void IncreaseCount()
    {
        counter++;
        counterUiText.text = "Number of game starts: " + counter.ToString();
    }
}
