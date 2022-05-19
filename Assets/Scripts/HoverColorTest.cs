using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverColorTest : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {

        rend.material.color = hoverColor;
    }
}
