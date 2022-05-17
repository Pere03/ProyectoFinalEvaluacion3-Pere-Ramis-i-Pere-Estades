using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public GameObject CardSlot;

    public GameObject Unidad;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public GameObject ant;
    private BarraDeElixir barrdeElixir;

    public float elixirf = 1;
    public float elixir;

    public float takeDamage = 0.3f;

    private void Start()
    {

        barrdeElixir = ant.GetComponent<BarraDeElixir>();
    }

    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
            Debug.Log("OnEndDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            transform.position = CardSlot.transform.position;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {

            elixirf -= takeDamage;
            Instantiate(Unidad, raycastHit.point, Quaternion.identity);
            }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

    }

    public void OnDrop(PointerEventData eventData)
    {
       
        throw new System.NotImplementedException();
    }
}
