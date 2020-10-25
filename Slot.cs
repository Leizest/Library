using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler
{
    public GameObject item;
    public int ID;
    public string Type;
    public string Description;
    public bool Empty;
    public Sprite icon;
    public Transform SlotIconGO;
    // Start is called before the first frame update
    public void UpdateSlots()
    {
        SlotIconGO.GetComponent<Image>().sprite = icon;
    }
    void Start()
    {
        SlotIconGO = transform.GetChild(0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(Description);
    }

    void Update()
    {
        
    }
}
