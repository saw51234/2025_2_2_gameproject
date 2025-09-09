using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DeliveryUIManager : MonoBehaviour
{
    [Header("UI 요소")]
    public Text statusText;
    public Text messageText;
    public Slider batterySlider;
    public Image batteryFill;

    [Header("게임 오브젝트")]
    public DeliveryDriver driver;

    // Start is called before the first frame update
    void Start()
    {
        if(driver != null)
        {
            driver.driveEvents.OnMoneyChanged.AddListener(UpdateMoney);
            driver.driveEvents.OnBatteryChanged.AddListener(UpdateBattery);
            driver.driveEvents.OnDeliveryCountChanged.AddListener(UpdateDeliveryCount);
            driver.driveEvents.OnMoveStarted.AddListener(OnMoveStarted);
            driver.driveEvents.OnMoveStoped.AddListener(OnMoveStopped);
            driver.driveEvents.OnLowBattery.AddListener(OnLowBattery);
            driver.driveEvents.OnLowBatteryEmpty.AddListener(OnBatteryEmpty);
            driver.driveEvents.OnDeliveryCompleted.AddListener(OnDeliveryCompleted);
        }

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(statusText != null && driver != null)
        {
            statusText.text = driver.GetStatusText();
        }
    }

    void ShowMessage(string message, Color color)
    {
        if(messageText != null)
        {
            messageText.text = message;
            messageText.color = color;
            StartCoroutine(ClearMessageAgterDelay(2f));
        }
    }

    IEnumerator ClearMessageAgterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(messageText != null)
        {
            messageText.text = "";
        }
    }

    void UpdateMoney(float money)
    {
        ShowMessage($"돈 : {money} 원", Color.green);
    }

    void UpdateBattery(float battery)
    {
        if(batterySlider != null)
        {
            batterySlider.value = battery / 100f;
        }

        if(batteryFill != null)
        {
            if(battery > 50f)
                batteryFill.color = Color.green;
            else if (battery > 20f)
                batteryFill.color = Color.yellow;
            else
                batteryFill.color = Color.red;
        }
    }

    void UpdateDeliveryCount(int count)
    {
        ShowMessage($"배달 완료 : {count}건", Color.blue);
    }

    void OnMoveStarted()
    {
        ShowMessage($"이동 시작", Color.cyan);
    }

    void OnMoveStopped()
    {
        ShowMessage($"이동 정지", Color.gray);
    }

    void OnLowBattery()
    {
        ShowMessage($"배터리 부족!", Color.red);
    }

    void OnBatteryEmpty()
    {
        ShowMessage("배터리 방전!", Color.red);
    }

    void OnDeliveryCompleted()
    {
        ShowMessage("배달 완료!", Color.green);
    }

    void UpdateUI()
    {
        if (driver != null)
        {
            UpdateMoney(driver.currentMoney);
            UpdateBattery(driver.batteryLevel);
            UpdateDeliveryCount(driver.deliveryCount);
        }
    }

    void OnDestroy()
    {
        if(driver != null)
        {
            driver.driveEvents.OnMoneyChanged.AddListener(UpdateMoney);
            driver.driveEvents.OnBatteryChanged.AddListener(UpdateBattery);
            driver.driveEvents.OnDeliveryCountChanged.AddListener(UpdateDeliveryCount);
            driver.driveEvents.OnMoveStarted.AddListener(OnMoveStarted);
            driver.driveEvents.OnMoveStoped.AddListener(OnMoveStopped);
            driver.driveEvents.OnLowBattery.AddListener(OnLowBattery);
            driver.driveEvents.OnLowBatteryEmpty.AddListener(OnBatteryEmpty);
            driver.driveEvents.OnDeliveryCompleted.AddListener(OnDeliveryCompleted);
        }
    }
}
