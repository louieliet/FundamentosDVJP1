using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class LogicScript : MonoBehaviour
{

    private float currentTime = 0f;
    public float startingTime;
    public TextMeshProUGUI countdown;
    public GameObject winMenu;
    public GameObject gameoverMenu;
    public GameObject Spawnner;
    public GameObject playercamera;

    private void Start()
    {
        currentTime = startingTime;   
        countdown = FindObjectOfType<TextMeshProUGUI>();

    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
            if(gameoverMenu.activeInHierarchy == false){
                Win();
            }
        }
    }

    public void Die(){
        if(winMenu.activeInHierarchy == false){
            gameoverMenu.SetActive(true);
        }
        
        playercamera.SetActive(false);

    }

    public void Win(){
        Spawnner.SetActive(false);
        winMenu.SetActive(true);
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("Enemy")){
            Destroy(x);
        }
    }

    public void Retry(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Application.Quit();
    }
    
}
