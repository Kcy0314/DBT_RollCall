using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OverViewCanvasCtrl : MonoBehaviour
{
    [SerializeField] private float weekDayMoveValue = 250f;
    [SerializeField] private float weekDayMoveTime = 0.1f;
    [SerializeField] private RectTransform weekDayTrans;
    [SerializeField] private Text weekDayText;
    enum WeekDay { Sun, Mon, Tue, Wed, Thu, Fri, Sat, Len }
    WeekDay currentWeekDay = WeekDay.Mon;
    Dictionary<WeekDay, string> weekDayMap = new Dictionary<WeekDay, string>();

    private void Awake() {
        InitWeekDay();
    }

    private void InitWeekDay() {
        weekDayMap.Add(WeekDay.Sun, "星期日");
        weekDayMap.Add(WeekDay.Mon, "星期一");
        weekDayMap.Add(WeekDay.Tue, "星期二");
        weekDayMap.Add(WeekDay.Wed, "星期三");
        weekDayMap.Add(WeekDay.Thu, "星期四");
        weekDayMap.Add(WeekDay.Fri, "星期五");
        weekDayMap.Add(WeekDay.Sat, "星期六");
    }

    public void LastWeekDay() {
        weekDayTrans.DOLocalMoveX(weekDayMoveValue, weekDayMoveTime).OnComplete(() => {
            ChangeWeekDay(-1);

            weekDayTrans.localPosition = new Vector3(-1 * weekDayMoveValue, 0, 0);
            weekDayTrans.DOLocalMoveX(0, weekDayMoveTime);
        });
    }

    public void NextWeekDay() {
        weekDayTrans.DOLocalMoveX(-1 * weekDayMoveValue, weekDayMoveTime).OnComplete(() => {
            ChangeWeekDay(1);

            weekDayTrans.localPosition = new Vector3(weekDayMoveValue, 0, 0);
            weekDayTrans.DOLocalMoveX(0, weekDayMoveTime);
        });
    }

    private void ChangeWeekDay(int p_change) {
        int _currentDay = (int)currentWeekDay;
        _currentDay += p_change;
        _currentDay += (int)WeekDay.Len;
        _currentDay %= (int)WeekDay.Len;
        currentWeekDay = (WeekDay)_currentDay;
        weekDayText.text = weekDayMap[currentWeekDay];
    }
}
