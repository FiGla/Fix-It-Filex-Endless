using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
    // board elements
    public float colums = 4; 
    public float rows = 5;
    public GameObject startHome;
    public GameObject restHome;
    public GameObject[] windows;
    public GameObject[] door;
    public GameObject[] windowUp;

    void BoardSetup( float y) {
        GameObject toInsta = restHome;
        GameObject instant = Instantiate(toInsta, new Vector3(0f, y, 0f), Quaternion.identity) as GameObject;
        for (float j = y-4f,k=0;k < colums; ++k,j+=2.6f) {
            for (float i = -3.5f; i < rows; i += 1.7f) {
                instant = Instantiate(windows[Random.Range(0, windows.Length)], new Vector3(i,j, 0f), Quaternion.identity)as GameObject;
            } 
        }
    }

    void FirstBoardSetup()
    {
        GameObject toInsta = startHome;
        GameObject instant = Instantiate(toInsta, new Vector3(0f, 2f, 0f), Quaternion.identity) as GameObject;
        for (float j = -1.9f, k = 0; k < colums; ++k){
            for (float i = -3.5f, c = 0; c < rows; i += 1.7f, ++c) {
                if (c == 2) { 
                    if (k == 0)
                        instant = Instantiate(door[Random.Range(0, door.Length)], new Vector3(i, j+0.3f, 0f), Quaternion.identity)as GameObject;
                    else if (k == 1)
                        instant = Instantiate(windowUp[Random.Range(0, windowUp.Length)], new Vector3(i, j, 0f), Quaternion.identity) as GameObject;
                    else
                        instant = Instantiate(windows[Random.Range(0, windows.Length)], new Vector3(i, j, 0f), Quaternion.identity) as GameObject;
                }
                else
                    instant = Instantiate(windows[Random.Range(0, windows.Length)], new Vector3(i, j, 0f), Quaternion.identity) as GameObject;
            }
            if (k == 0) j += 2.9f;
            else j += 2.5f;
        }
    }
    
    public void SetupScence(bool level, float y ) {
        if (!level)
            FirstBoardSetup();
        else BoardSetup(y);

    }
}
