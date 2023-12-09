using Zenject;

public class PopupInstallerExtensions
{
    public static void BinPopup<TInterface,TRealization>(DiContainer container, BasePopup popup) where TInterface : IPopupPresenter where TRealization : TInterface
    {
        container.Bind<TInterface>().To<TRealization>().AsSingle();
        BindPopup<TInterface>(container, popup);
    }

    
    private static void BindPopup<T>(DiContainer container, BasePopup basePopup) where T : IPopupPresenter 
        => container.Bind<PopupData>().FromMethod(c => CreatePopupData<T>(container, basePopup)).AsTransient();

    private static PopupData CreatePopupData<T>(DiContainer container, BasePopup basePopup) where T : IPopupPresenter => 
        new(basePopup, container.Resolve<T>());
}