using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSlot : MonoBehaviour
{
    [SerializeField]
    private string ValidTag;

    [SerializeField]
    private Material noHighlight;
    [SerializeField]
    private Material highlight;

    [SerializeField]
    private MeshRenderer slotRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ValidTag)
        {
            if(slotRenderer.material != highlight) slotRenderer.material = highlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == ValidTag)
        {
            if(slotRenderer.material != noHighlight) slotRenderer.material = noHighlight;
        }
    }
}
