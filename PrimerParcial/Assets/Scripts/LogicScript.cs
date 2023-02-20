using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    private float currentTime = 0f;
    private float startingTime = 30f;
    [SerializeField] Text countdown;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        currentTime = startingTime;     
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
        }
    }

    public void Die(){
        Debug.Log("You died");
    }
}
