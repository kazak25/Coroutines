using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField] private Transform _target;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(S());
    }

    // Update is called once per frame

    private IEnumerator S()
    {
        var enemy = Instantiate(_prefab);
        while (enemy.transform.position!=_target.position)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _target.position, Time.deltaTime);
            yield return null;
        }
       
    }
}
