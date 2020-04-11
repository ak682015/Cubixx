using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject HomeUI;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            HomeUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
