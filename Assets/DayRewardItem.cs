using TMPro;
using UnityEngine;
using Zenject;

public class DayRewardItem : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private int _day;
    [SerializeField] private CustomButton _customButton;
    [SerializeField] private SpriteToggle _spriteToggle;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private TMP_Text _dayText;
    
    private DayRewardButton _dayRewardButton;


    [Inject]
    private void Construct(DayRewardButton dayRewardButton)
    {
        _dayRewardButton = dayRewardButton;
    }
    
    public void SetState(bool state)
    {
        if(state)
            _customButton.EnableButton();
        else
            _customButton.DisableButton();

        _spriteToggle.SetSprite(state);
    }

    private void Start()
    {
        _amountText.text = $"X{_reward}";
        _dayText.text = $"DAY{_day}";
        _customButton.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _customButton.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        SetState(false);
        _dayRewardButton.OnClick(_reward);
    }
}