using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var newPosition = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z);

        transform.position = newPosition;
	}
}
