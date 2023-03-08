using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 8, 0f);
    }
}
