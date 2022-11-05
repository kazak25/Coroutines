using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] 
    public Color[] _colors;
    
    public Color SetRandomColor()
    {
        var index = Random.Range(0, _colors.Length);
        var color = _colors[index];
        return color;
    }

    
}