﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Spectrum : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    //public float gridX = 1f;
    //public float gridY = 1f;
    public float spacing = 1f;
    public int numberOfObjects = 60;
    public GameObject[] Platform1;

    void Start()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Vector3 pos = new Vector3(x, -5 / spacing, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
        Platform1 = GameObject.FindGameObjectsWithTag("Platform1");
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[1024]; AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = Platform1[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 3, Time.deltaTime * 30);

            //Platform1[i].transform.localScale = previousScale; 
            Platform1[i].transform.DOScaleY(previousScale.y, 2f);
        }
    }
}
