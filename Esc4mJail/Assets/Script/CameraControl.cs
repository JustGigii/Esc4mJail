using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject Look;
	Vector3 Poss;
	public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Poss = new Vector3(Look.transform.position.x, Look.transform.position.y, -10f);
		transform.position = Vector3.Lerp(transform.position, Poss, Speed*Time.deltaTime);
    }
}
