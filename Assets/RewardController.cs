using UnityEngine;

public class RewardController : MonoBehaviour
{
    private readonly RewardsConfig _rewardsConfig;

    public RewardController(RewardsConfig rewardsConfig)
    {
        _rewardsConfig = rewardsConfig;
    }
}