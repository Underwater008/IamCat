using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public RectTransform topBar, bottomBar, leftBar, rightBar;
    
    [Range (0,1)] public float EditorBoarder=0;
    float comicBoarder = 0;
    public float ComicBoarder
    {
        set
        {
            comicBoarder = Mathf.Clamp(value, 0, 1);
            topBar.anchoredPosition = new Vector3(topBar.anchoredPosition.x, 5 - comicBoarder * 10);
            bottomBar.anchoredPosition = new Vector3(topBar.anchoredPosition.x, -5 + comicBoarder * 10);
            leftBar.anchoredPosition = new Vector3(-5 + comicBoarder * 10, topBar.anchoredPosition.y);
            rightBar.anchoredPosition = new Vector3(5 - comicBoarder * 10, topBar.anchoredPosition.y);
        }
        get
        {
            return comicBoarder;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        ComicBoarder = EditorBoarder;
    }
}
