using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class AutoTileTexture : MonoBehaviour
{

    public float scaler = 1f;
    MeshRenderer render;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>()
            .sharedMaterial
            .SetTextureScale("_MainTex", new Vector2(
                transform.lossyScale.x * scaler,
                transform.lossyScale.z * scaler
                ));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
