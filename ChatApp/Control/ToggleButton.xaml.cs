using System.Windows.Input;

namespace Dorisoy.PeriodontalChat.Control;

public partial class ToggleButton : ContentView
{
    public static readonly BindableProperty IsCheckedProperty =
        BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(ToggleButton),
                                defaultValue: false, propertyChanged: OnIsCheckedChanged);

    // CheckedColor 绑定属性
    public static readonly BindableProperty CheckedColorProperty =
        BindableProperty.Create(nameof(CheckedColor), typeof(Color), typeof(ToggleButton),
                                defaultValue: Color.FromArgb("#ffffff"));

    // UncheckedColor 绑定属性
    public static readonly BindableProperty UncheckedColorProperty =
        BindableProperty.Create(nameof(UncheckedColor), typeof(Color), typeof(ToggleButton),
                                defaultValue: Color.FromArgb("#dddddd"));

    public static readonly BindableProperty ButtonColorProperty =
           BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(ToggleButton), Colors.Transparent);

    public static readonly BindableProperty TextProperty =
         BindableProperty.Create(nameof(Text), typeof(String), typeof(ToggleButton), string.Empty);

    public static readonly BindableProperty ImageProperty =
     BindableProperty.Create(nameof(Image), typeof(String), typeof(ToggleButton), string.Empty);

    public static readonly BindableProperty CounterProperty = 
        BindableProperty.Create(nameof(Counter), typeof(Int32), typeof(ToggleButton), 0, propertyChanged: OnCounterChanged);
    public int Counter
    {
        get => (Int32)GetValue(CounterProperty);
        set => SetValue(CounterProperty, value);
    }


    public string Text
    {
        get => (String)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Image
    {
        get => (String)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public Color CheckedColor
    {
        get => (Color)GetValue(CheckedColorProperty);
        set => SetValue(CheckedColorProperty, value);
    }

    public Color UncheckedColor
    {
        get => (Color)GetValue(UncheckedColorProperty);
        set => SetValue(UncheckedColorProperty, value);
    }

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public Color ButtonColor
    {
        get => (Color)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }

    public static readonly BindableProperty IsToggleProperty = 
        BindableProperty.Create(nameof(IsToggle), typeof(Boolean), typeof(ToggleButton), true);
    public bool IsToggle
    {
        get => (Boolean)GetValue(IsToggleProperty);
        set => SetValue(IsToggleProperty, value);
    }

    public ICommand ToggleCommand { get; }
    public ToggleButton()
    {
        InitializeComponent();

        // 初始化 ToggleCommand
        ToggleCommand = new Command(() =>
        {
            if (IsToggle)
            {
                IsChecked = !IsChecked;
            }
            else
            {
                if (Counter >= 3)
                    Counter = -1;

                Counter++;
            }
        });

        // 显示初始背景色
        if (IsToggle)
        {
            UpdateButtonColor(IsChecked);
        }
        else
        {
            UpdateButtonImage(0);
        }
    }

    private static void OnIsCheckedChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        ((ToggleButton)bindable).UpdateButtonColor((bool)newValue);
    }

    //
    private static void OnCounterChanged(BindableObject bindable, object oldvalue, object newValue)
    {
        ((ToggleButton)bindable).UpdateButtonImage((Int32)newValue);
    }

    private void UpdateButtonImage(int counter)
    {
        Image = $"f{counter}.png";
    }

    private void UpdateButtonColor(bool isChecked)
    {
        // 根据是否选中更新 Button 的背景色
        ButtonColor = isChecked ? CheckedColor : UncheckedColor;
    }

    private void OnTapped(object sender, EventArgs e)
    {
        // 切换状态
        IsChecked = !IsChecked;
    }
}