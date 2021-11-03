using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _panelMenu;
    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 0;
        _panelMenu.SetActive(true);
    }
}
