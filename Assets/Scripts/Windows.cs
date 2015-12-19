using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Windows : MonoBehaviour {
    public GameObject[] fixedSprite;
    public bool fix = false;

    void Start() {
        if (fix) GameManager.instance.fixedWindows++;
    }
    public void FixWindow(){
        if (!fix){
            int index = Random.Range(0, fixedSprite.Length);
            fixedSprite[index].transform.position = transform.position;
            Instantiate(fixedSprite[index], fixedSprite[index].transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    
}
