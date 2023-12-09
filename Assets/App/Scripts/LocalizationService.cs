public class LocalizationService 
{
    private readonly Localizer _localizer;

    public LocalizationService(Localizer localizer)
    {
        _localizer = localizer;
    }

    public void FindAllTextAndLocalize()
    {
        _localizer.FindAllTextFieldsAndConstruct();
        _localizer.LocalizeAllText();
    }
}