using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnim : MonoBehaviour
{
    private float scrollSpeed = 1.0f;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = scrollSpeed * Input.GetAxisRaw("Vertical") * Time.time;

        _renderer.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
        _renderer.material.SetTextureOffset("_BumpMap", new Vector2(0f, offset));
    }
}
