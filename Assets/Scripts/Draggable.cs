using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDragging;

    void OnMouseDown()
    {
        startPosition = transform.position; // שמירה על המיקום ההתחלתי
        isDragging = true;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, startPosition.z); // תזוזה בהתאם לעכבר
    }

    void OnMouseUp()
    {
        isDragging = false; // עצירת הגרירה
    }
}



