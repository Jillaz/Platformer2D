using TMPro;
using UnityEngine;

public class AuraStatusDislpayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AuraDamager _aura;
    private string _activeAura = "Aura active: ";
    private string _cooldownAura = "Aura cooldown: ";
    private string _readyStatus = "Aura is ready";

    private void OnEnable()
    {
        _aura.AuraActive += DisplayActiveTime;
        _aura.AuraCooldown += DisplayCooldownTime;
        _aura.AuraIsReady += DisplayReadyStatus;
    }

    private void OnDisable()
    {
        _aura.AuraActive -= DisplayActiveTime;
        _aura.AuraCooldown -= DisplayCooldownTime;
        _aura.AuraIsReady -= DisplayReadyStatus;
    }

    private void Start()
    {
        _text.text = _readyStatus;
    }

    private void DisplayActiveTime(float time)
    {
        _text.text = _activeAura + time.ToString("F0");
    }

    private void DisplayCooldownTime(float time)
    {
        _text.text = _cooldownAura + time.ToString("F0");
    }

    private void DisplayReadyStatus()
    {
        _text.text = _readyStatus;
    }
}
