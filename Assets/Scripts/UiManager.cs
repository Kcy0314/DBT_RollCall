using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    #region Parameter
    enum CanvasType
    {
        Home, Classes, Students, RollCall, Tools
    }
    private CanvasType currentCanvas = CanvasType.Home;
    [SerializeField] private float homeButtonMoveTime = 0.5f;
    [SerializeField] private float canvasShowTime = 0.3f;
    #endregion


    #region HomeCanvas
    [Header("HomeCanvas")]
    [SerializeField] private RectTransform homeButtons;
    public void ReturnHomeCanvas()
    {
        switch (currentCanvas)
        {
            case CanvasType.Classes:
                CloseClassCanvas();
                break;
            case CanvasType.Students:
                CloseStudentsCanvas();
                break;
            case CanvasType.RollCall:
                CloseRollCallCanvas();
                break;
            case CanvasType.Tools:
                CloseToolsCanvas();
                break;
        }
    }

    private void ShowHomeButtons()
    {
        homeButtons.DOMoveY(homeButtons.position.y - 500, homeButtonMoveTime).SetEase(Ease.InOutBack);
    }

    private void HideHomeButtons()
    {
        homeButtons.DOMoveY(homeButtons.position.y + 500, homeButtonMoveTime).SetEase(Ease.InOutBack);
    }
    #endregion

    #region ClassesCanvas
    [Header("ClassesCanvas")]
    [SerializeField] private CanvasGroup classesCanvas;
    public void OpenClassCanvas()
    {
        if(currentCanvas != CanvasType.Home) { return; }
        HideHomeButtons();
        ShowClassesCanvas();
        currentCanvas = CanvasType.Classes;
    }

    public void CloseClassCanvas()
    {
        if (currentCanvas != CanvasType.Classes) { return; }
        HideClassesCanvas();
        ShowHomeButtons();
        currentCanvas = CanvasType.Home;
    }

    private void ShowClassesCanvas()
    {
        classesCanvas.DOFade(1, canvasShowTime).SetEase(Ease.InExpo);
        classesCanvas.blocksRaycasts = true;
    }

    private void HideClassesCanvas()
    {
        classesCanvas.DOFade(0, canvasShowTime).SetEase(Ease.OutExpo);
        classesCanvas.blocksRaycasts = false;
    }
    #endregion

    #region StudentsCanvas
    [Header("StudentsCanvas")]
    [SerializeField] private CanvasGroup studentsCanvas;
    public void OpenStudentsCanvas()
    {
        if (currentCanvas != CanvasType.Home) { return; }
        HideHomeButtons();
        ShowStudentsCanvas();
        currentCanvas = CanvasType.Students;
    }

    public void CloseStudentsCanvas()
    {
        if (currentCanvas != CanvasType.Students) { return; }
        HideStudentsCanvas();
        ShowHomeButtons();
        currentCanvas = CanvasType.Home;
    }

    private void ShowStudentsCanvas()
    {
        studentsCanvas.DOFade(1, canvasShowTime).SetEase(Ease.InExpo);
        studentsCanvas.blocksRaycasts = true;
    }

    private void HideStudentsCanvas()
    {
        studentsCanvas.DOFade(0, canvasShowTime).SetEase(Ease.OutExpo);
        studentsCanvas.blocksRaycasts = false;
    }
    #endregion

    #region RollCallCanvas
    [Header("RollCallCanvas")]
    [SerializeField] private CanvasGroup rollCallCanvas;
    public void OpenRollCallCanvas()
    {
        if (currentCanvas != CanvasType.Home) { return; }
        HideHomeButtons();
        ShowRollCallCanvas();
        currentCanvas = CanvasType.RollCall;
    }

    public void CloseRollCallCanvas()
    {
        if (currentCanvas != CanvasType.RollCall) { return; }
        HideRollCallCanvas();
        ShowHomeButtons();
        currentCanvas = CanvasType.Home;
    }

    private void ShowRollCallCanvas()
    {
        rollCallCanvas.DOFade(1, canvasShowTime).SetEase(Ease.InExpo);
        rollCallCanvas.blocksRaycasts = true;
    }

    private void HideRollCallCanvas()
    {
        rollCallCanvas.DOFade(0, canvasShowTime).SetEase(Ease.OutExpo);
        rollCallCanvas.blocksRaycasts = false;
    }
    #endregion

    #region ToolsCanvas
    [Header("ToolsCanvas")]
    [SerializeField] private CanvasGroup toolsCanvas;
    public void OpenToolsCanvas()
    {
        if (currentCanvas != CanvasType.Home) { return; }
        HideHomeButtons();
        ShowToolsCanvas();
        currentCanvas = CanvasType.Tools;
    }

    public void CloseToolsCanvas()
    {
        if (currentCanvas != CanvasType.Tools) { return; }
        HideToolsCanvas();
        ShowHomeButtons();
        currentCanvas = CanvasType.Home;
    }

    private void ShowToolsCanvas()
    {
        toolsCanvas.DOFade(1, canvasShowTime).SetEase(Ease.InExpo);
        toolsCanvas.blocksRaycasts = true;
    }

    private void HideToolsCanvas()
    {
        toolsCanvas.DOFade(0, canvasShowTime).SetEase(Ease.OutExpo);
        toolsCanvas.blocksRaycasts = false;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturnHomeCanvas();
        }
    }
}
