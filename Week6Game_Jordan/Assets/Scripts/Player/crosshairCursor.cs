using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairCursor : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Mouse Position in screen space
        Vector2 MousePosition = Input.mousePosition;
        // get Rect Transform from Canvas (Canvas Size)
        RectTransform crosshairPosition = GetComponent<Image>().canvas.GetComponent<RectTransform>();
        Vector2 localPoint;
        // Convert Screen space mouse position to canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(crosshairPosition, MousePosition, null, out localPoint);
        // Apply the position
        GetComponent<Image>().rectTransform.localPosition = localPoint;
    }
}
