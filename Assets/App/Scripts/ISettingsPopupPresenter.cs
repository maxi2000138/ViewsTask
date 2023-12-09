public interface ISettingsPopupPresenter : IPopupPresenter
{
    void Construct(SpriteToggle musicToggle, SpriteToggle soundsToggle);
    void MusicButtonAction();
    void SoundsButtonAction();
    void InitButtons();
    void LanguageButtonAction();
}