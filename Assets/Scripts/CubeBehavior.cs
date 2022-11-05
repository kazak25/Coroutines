using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private float _cubeSpawnerInterval;
    [SerializeField] private GameObject _prefabCube;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _cubeColorChangeTime;
    [SerializeField] private float _colorChangeInterval;

    private Painter _painter;
    private List<GameObject> _cubes = new List<GameObject>();
    private Color cubeNewColor;
    private float _currentTime;
    private float travelTime;

    // Start is called before the first frame update
    private int n = 1;


    private void Awake()
    {
        StartCoroutine(SpawnCubes());
    }

    public void Initialize(Painter painter)
    {
        _painter = painter;
    }

    private IEnumerator SpawnCubes()
    {
        var count = 0;
        var position = _startPosition.position;
        for (int i = 0; i < 20; i++)
        {
            for (int i1 = 0; i1 < 20; i1++)
            {
                var cube = Instantiate(_prefabCube);
                _cubes.Add(cube);
                yield return new WaitForSeconds(_cubeSpawnerInterval);
                cube.transform.position = position;
                position.x += 1f;
            }

            count++;
            position = _startPosition.position;
            position.z -= count;
        }
    }

    public void StartCubeColorCoroutin()
    {
        cubeNewColor = _painter.SetRandomColor();
        StartCoroutine(CubeColorChange(cubeNewColor));
    }

    public IEnumerator CubeColorChange(Color color)
    {
        for (var i = 0; i < _cubes.Count - 1; i++)
        {
            _currentTime = 0;

            var startColor = _cubes[i].GetComponent<Renderer>().material.color;
            while (_currentTime <= _cubeColorChangeTime)
            {
                _cubes[i].GetComponent<Renderer>().material.color =
                    Color.Lerp(startColor, color, _currentTime / _cubeColorChangeTime);
                _currentTime += Time.deltaTime;
                yield return null; //нужно ли? не совсем понимаю для чего
            }

            yield return new WaitForSeconds(_colorChangeInterval);
        }
    }
}