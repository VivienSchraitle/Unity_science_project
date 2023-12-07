using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentScript : MonoBehaviour

{
    // Start is called before the first frame update

    public GameObject mrtkCanvas;
    void Start()
    {
        transform.SetParent(mrtkCanvas.transform);
        transform.localPosition = new Vector3((float)-0.161,(float)0.281,(float)-0.1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
