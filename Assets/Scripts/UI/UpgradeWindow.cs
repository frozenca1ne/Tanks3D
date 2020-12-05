using System;
using System.Collections;
using Scripts.SOData;
using SOData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UpgradeWindow : MonoBehaviour
    {
        // public event Action<float> OnSpeedValueUpdate;
        // public event Action<float> OnTurnValueUpdate;
        // public event Action<float> OnShootValueUpdate;
        // public event Action<float> OnDamageValueUpdate;
        // [Header("Labels")]
        // [SerializeField] private TMPro.TMP_Text speedText = default;
        // [SerializeField] private TMPro.TMP_Text turnSpeedText = default;
        // [SerializeField] private TMPro.TMP_Text shootSpeedText = default;
        // [SerializeField] private TMPro.TMP_Text damageText = default;
        // [SerializeField] private TMPro.TMP_Text noMoneyText = default;
        //
        // [Header("Costs")]
        // [SerializeField] private TMPro.TMP_Text speedCoinsCost = default;
        // [SerializeField] private TMPro.TMP_Text turnSpeedCoinsCost = default;
        // [SerializeField] private TMPro.TMP_Text shootSpeedCoinsCost = default;
        // [SerializeField] private TMPro.TMP_Text damageCoinsCost = default;
        //
        // [Header("UpgradeButtons")]
        // [SerializeField] private Button speedUpgradeButton = default;
        // [SerializeField] private Button turnSpeedUpgradeButton = default;
        // [SerializeField] private Button shootSpeedUpgradeButton = default;
        // [SerializeField] private Button damageUpgradeButton = default;
        //
        // [Header("PlayerInfo")]
        // [SerializeField] private TankInfo playerInfo;
        // [SerializeField] private UpgradeCoast upgradeCoast;
        //
        // private float m_CurrentSpeed;
        // private float m_CurrentTurnSpeed;
        // private float m_CurrentShootSpeed;
        // private float m_CurrentDamage;
        // private float m_CurrentCoins;
        //
        // private float m_UpgradeValue;
        //
        // private void OnEnable()
        // {
        //
        //     m_CurrentSpeed = playerInfo.Speed;
        //     m_CurrentTurnSpeed = playerInfo.TurnSpeed;
        //     m_CurrentShootSpeed = playerInfo.ShootSpeed;
        //     m_CurrentDamage = playerInfo.Damage;
        //     m_CurrentCoins = playerInfo.Coins;
        //     m_UpgradeValue = upgradeCoast.UpgradeValue;
        //
        //
        //     speedCoinsCost.text = $"{upgradeCoast.SpeedCost} coins";
        //     turnSpeedCoinsCost.text = $"{upgradeCoast.TurnSpeedCost} coins";
        //     shootSpeedCoinsCost.text = $"{upgradeCoast.ShootSpeedCost} coins";
        //     damageCoinsCost.text = $"{upgradeCoast.DamageCost} coins";
        //
        //
        //     speedText.text = $"Speed : {m_CurrentSpeed}";
        //     turnSpeedText.text = $"TurnSpeed : {m_CurrentTurnSpeed}";
        //     shootSpeedText.text = $"ShootSpeed : {m_CurrentShootSpeed}";
        //     damageText.text = $"Damage : {m_CurrentDamage}";
        //
        //     OnSpeedChange(m_CurrentSpeed);
        //     OnTurnSpeedChange(m_CurrentTurnSpeed);
        //     OnShootSpeedChange(m_CurrentShootSpeed);
        //     OnDamageChange(m_CurrentDamage);
        //
        //     playerInfo.Speed.Variable.OnValueChanged += OnSpeedChange;
        //     playerInfo.TurnSpeed.Variable.OnValueChanged += OnTurnSpeedChange;
        //     playerInfo.ShootSpeed.Variable.OnValueChanged += OnShootSpeedChange;
        //     playerInfo.Damage.Variable.OnValueChanged += OnDamageChange;
        //     playerInfo.Coins.Variable.OnValueChanged += OnCoinsCountChange;
        //
        //     OnSpeedValueUpdate += OnSpeedChange;
        //     OnTurnValueUpdate += OnTurnSpeedChange;
        //     OnShootValueUpdate += OnShootSpeedChange;
        //     OnDamageValueUpdate += OnDamageChange;
        //
        //     speedUpgradeButton.onClick.AddListener(BuySpeed);
        //     turnSpeedUpgradeButton.onClick.AddListener(BuyTurnSpeed);
        //     shootSpeedUpgradeButton.onClick.AddListener(BuyShootSpeed);
        //     damageUpgradeButton.onClick.AddListener(BuyDamage);
        // }
        //
        // private void OnDisable()
        // {
        //     playerInfo.Speed.Variable.OnValueChanged -= OnSpeedChange;
        //     playerInfo.TurnSpeed.Variable.OnValueChanged -= OnTurnSpeedChange;
        //     playerInfo.ShootSpeed.Variable.OnValueChanged -= OnShootSpeedChange;
        //     playerInfo.Damage.Variable.OnValueChanged -= OnDamageChange;
        //     playerInfo.Coins.Variable.OnValueChanged -= OnCoinsCountChange;
        // }
        //
        // private void OnSpeedChange(float speed)
        // {
        //     speedText.text = $"Speed : {speed}";
        // }
        //
        // private void OnTurnSpeedChange(float turnSpeed)
        // {
        //     turnSpeedText.text = $"TurnSpeed : {turnSpeed}";
        // }
        //
        // private void OnShootSpeedChange(float shootSpeed)
        // {
        //     shootSpeedText.text = $"ShootSpeed : {shootSpeed}";
        // }
        //
        // private void OnDamageChange(float damage)
        // {
        //     damageText.text = $"Damage : {damage}";
        // }
        //
        // private void OnCoinsCountChange(float coins)
        // {
        //     m_CurrentCoins -= coins;
        // }
        //
        // private void BuySpeed()
        // {
        //     if (m_CurrentCoins >= upgradeCoast.SpeedCost)
        //     {
        //         OnCoinsCountChange(upgradeCoast.SpeedCost);
        //         var newValue = m_CurrentSpeed + m_UpgradeValue;
        //         OnSpeedValueUpdate?.Invoke(newValue);
        //     }
        //     else
        //     {
        //         StartCoroutine(nameof(ActiveText));
        //     }
        //
        // }
        // private void BuyTurnSpeed()
        // {
        //     if (m_CurrentCoins >= upgradeCoast.TurnSpeedCost)
        //     {
        //         OnCoinsCountChange(upgradeCoast.TurnSpeedCost);
        //         var newValue = m_CurrentTurnSpeed + m_UpgradeValue;
        //         OnTurnValueUpdate?.Invoke(newValue);
        //     }
        //     else
        //     {
        //         StartCoroutine(nameof(ActiveText));
        //     }
        //
        // }
        // private void BuyShootSpeed()
        // {
        //     if (m_CurrentCoins >= upgradeCoast.ShootSpeedCost)
        //     {
        //         OnCoinsCountChange(upgradeCoast.ShootSpeedCost);
        //         var newValue = m_CurrentShootSpeed + m_UpgradeValue;
        //         OnShootValueUpdate?.Invoke(newValue);
        //     }
        //
        //     else
        //     {
        //         StartCoroutine(nameof(ActiveText));
        //     }
        // }
        // private void BuyDamage()
        // {
        //     if (m_CurrentCoins >= upgradeCoast.DamageCost)
        //     {
        //         OnCoinsCountChange(upgradeCoast.DamageCost);
        //         var newValue = m_CurrentDamage + m_UpgradeValue;
        //         OnDamageValueUpdate?.Invoke(newValue);
        //     }
        //     else
        //     {
        //         StartCoroutine(nameof(ActiveText));
        //     }
        //
        // }
        //
        // private IEnumerator ActiveText()
        // {
        //     noMoneyText.gameObject.SetActive(true);
        //     yield return new WaitForSeconds(1f);
        //     noMoneyText.gameObject.SetActive(false);
        // }
    
    }
}
