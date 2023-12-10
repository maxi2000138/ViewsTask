using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Zenject;

public class IAPHandler : IInitializable, IDetailedStoreListener
{
    private IStoreController _storeController;
    
    private readonly IAPConfig _iapConfig;

    public IAPHandler(IAPConfig iapConfig)
    {
        _iapConfig = iapConfig;
    }


    public void Initialize()
    {
        SetupBuilder();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
    }

    private void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        foreach (var consumableItem in _iapConfig._consumableItems)
        {
            builder.AddProduct(consumableItem.BaseData.Id, ProductType.Consumable);
        }
        
        foreach (var nonConsumableItem in _iapConfig._consumableItems)
        {
            builder.AddProduct(nonConsumableItem.BaseData.Id, ProductType.NonConsumable);
        }

        foreach (var subscriptionItem in _iapConfig._subscriptionItems)
        {
            builder.AddProduct(subscriptionItem.BaseData.Id, ProductType.Subscription);
        }
        
        UnityPurchasing.Initialize(this,builder);
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        
    }
}