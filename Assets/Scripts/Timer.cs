using UnityEngine;
using TMPro;
using System.Collections;

public class Timer: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplay;
    [SerializeField] TextMeshProUGUI recordDisplay;
    [SerializeField] TextMeshProUGUI loseText;
    float seconds = 0;
    int minutes = 0;
    float record;
    private void Start()
    {
        WaitLoading();
    }

    void Update()
    {
        if ( !GameManager.Instance.isGameOver)
        {
            seconds += Time.deltaTime;
            if (seconds > 59)
            {
                minutes++;
                seconds = 0;
            }
            timeDisplay.text = AddZeroToTheBeginning(minutes) + ":" + AddZeroToTheBeginning(Mathf.Round(seconds));
        }
    }
    string AddZeroToTheBeginning(float numb)
    {
        string str = "";
        if (numb > 9)
        {
            str = numb.ToString();
        }
        else
        {
            str = "0" + numb.ToString();
        }
        return str;
    }
    public void PrintTime()
    {
        loseText.text = $"В этот раз вы смогли продержаться на платформе {minutes} минут и {Mathf.Round(seconds)} секунд";
    }
    public void ChekRecord()
    {
        float time = Mathf.Round(seconds + minutes * 60);
        if (time > DataBox.Instance.dataStore.maxTimeScore)
        {
            DataBox.Instance.dataStore.maxTimeScore = time;
            DataBox.Instance.SaveToServer();
            ShowNewRecord();
        }
    }
    void ShowNewRecord()
    {
        recordDisplay.text = $"Рекорд: {AddZeroToTheBeginning(minutes) + ":" + AddZeroToTheBeginning(Mathf.Round(seconds))}";
    }

    IEnumerator WaitLoading()
    {
        yield return new WaitForSeconds(0.5f);
        record = DataBox.Instance.dataStore.maxTimeScore;
        recordDisplay.text = $"Рекорд: {AddZeroToTheBeginning(Mathf.Round(record / 60))}:{AddZeroToTheBeginning(record % 60)}";
    }
}
