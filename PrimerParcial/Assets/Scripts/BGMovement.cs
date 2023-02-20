using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public Vector2 velocity;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D player;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        offset = velocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
