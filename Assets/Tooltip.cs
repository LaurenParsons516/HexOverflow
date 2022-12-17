using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private GameObject tooltip;
    public string functionName;

    // Show tooltip when hovering over icon
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.GetComponent<Text>().text = functionName;
        tooltip.transform.localScale = new Vector3(1, 1, 1);
    }

    // Hide tooltip when not hovering over icon
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.transform.localScale = new Vector3(0, 0, 0);
    }

    // HIde tooltip by default
    void Start()
    {
        tooltip = GameObject.Find("AttackTooltip");
        tooltip.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
