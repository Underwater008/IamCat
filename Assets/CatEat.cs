using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatEat : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public Sprite openMouth;
    public Sprite closeMouth;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) {
            if (eventData.pointerDrag.GetComponent<FoodDrag>().edible)
            {
                Eat(eventData.pointerDrag);
                image.sprite = closeMouth;
            }
            else if (!eventData.pointerDrag.GetComponent<FoodDrag>().edible)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<FoodDrag>().ogpos;
            }
        }
    }
    public void Eat(GameObject food) {
        Destroy(food);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<FoodDrag>().edible)
            {
                image.sprite = openMouth;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<FoodDrag>().edible)
            {
                image.sprite = closeMouth;
            }
        }
    }
}
