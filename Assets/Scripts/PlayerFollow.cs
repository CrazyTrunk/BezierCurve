using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector2 positionOfPlayer;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        //make many routes array object ?
        routeToGo = 0; 
        tParam = 0f;
        speed = 0.5f;
        StartCoroutine(GoToRoute(routeToGo));

    }

    // Update is called once per frame

    IEnumerator GoToRoute(int routeToGo)
    {
        //4 points of moving
        var p0 = routes[routeToGo].GetChild(0).position;
        var p1 = routes[routeToGo].GetChild(1).position;
        var p2 = routes[routeToGo].GetChild(2).position;
        var p3 = routes[routeToGo].GetChild(3).position;

        while (tParam < 1f)
        {
            tParam += Time.deltaTime * speed;
            positionOfPlayer = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1
                + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = positionOfPlayer;
            yield return null;
        }
    }
}
