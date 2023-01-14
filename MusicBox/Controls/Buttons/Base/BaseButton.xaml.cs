namespace MusicBox.Controls.Buttons.Base;

public partial class BaseButton : Button
{
    public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(BaseButton), string.Empty);

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public BaseButton()
    {
        InitializeComponent();
    }
}