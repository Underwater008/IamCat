using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FoodDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
{
    private RectTransform recttrans;
    [SerializeField] private Canvas canvas;
    private CanvasGroup CG;

    public bool edible = true;
    public Vector2 ogpos;

    private void Awake()
    {
        recttrans = GetComponent<RectTransform>();
        CG = GetComponent<CanvasGroup>();
        ogpos = recttrans.anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        CG.blocksRaycasts = false;
        ogpos = recttrans.anchoredPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CG.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        recttrans.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
