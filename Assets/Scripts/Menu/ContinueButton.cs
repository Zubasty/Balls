using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _panelMenu;
    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1;
        _panelMenu.SetActive(false);
    }
}
