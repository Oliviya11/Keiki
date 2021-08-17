using UnityEngine;

public class PanelSafeArea : MonoBehaviour
{
    public Canvas canvas;
    RectTransform panelSafeArea;
    Rect currentSafeArea;
    ScreenOrientation currentOrientation;
    public RectTransform leftPanel, rightPanel;

    // Start is called before the first frame update
    void Awake()
    {
        panelSafeArea = GetComponent<RectTransform>();
        currentSafeArea = Screen.safeArea;
        applySafeArea();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
        {
            applySafeArea();
        }
    }

    void applySafeArea()
    {
        if (panelSafeArea == null)
        {
            return;
        }

        Rect safeArea = Screen.safeArea;

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;

        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;

        leftPanel.sizeDelta = new Vector2((safeArea.size.x / 2f), leftPanel.sizeDelta.y);
        rightPanel.sizeDelta = new Vector2((safeArea.size.x / 2f), leftPanel.sizeDelta.y);

        currentOrientation = Screen.orientation;
        currentSafeArea = Screen.safeArea;
    }
}
