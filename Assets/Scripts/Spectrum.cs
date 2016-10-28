using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab;
    public float gridX = 3f;
    public float gridY = 3f;
    public float spacing = 2f;
    public int numberOfObjects = 60;
    public GameObject[] Platform;

    void Start()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x, -5/spacing, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
        Platform = GameObject.FindGameObjectsWithTag("Platform1");
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[1024]; AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = Platform[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 3, Time.deltaTime * 30);
            Platform[i].transform.localScale = previousScale;
        }
    }
}
