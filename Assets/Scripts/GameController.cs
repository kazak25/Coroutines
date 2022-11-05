using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Painter _painter;
    [SerializeField] private CubeBehavior _cubeSpawner;
    
    private void Awake()
    {
        _cubeSpawner.Initialize(_painter);
    }
}
