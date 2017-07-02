using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float targetTime;

    // Use this for initialization
    void Start()
    {
        targetTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
            targetTime = 0f;
        }

    }

    private void timerEnded()
    {
        //do your stuff here.
    }


}
