namespace Dorisoy.PeriodontalChat;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }



#if WINDOWS
    private Microsoft.UI.Windowing.AppWindow GetAppWindow(MauiWinUIWindow window)
    {
        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
        return appWindow;
    }
#endif

    private void Print_Clicked(object sender, EventArgs e)
    {

    }

    private void Download_Clicked(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 全屏
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnToggleFullscreenClicked(object sender, EventArgs e)
    {
#if WINDOWS
		var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;
        
        var appWindow = GetAppWindow(window);

        switch (appWindow.Presenter)
        {
            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
                {
                    overlappedPresenter.SetBorderAndTitleBar(true, true);
                    overlappedPresenter.Restore();
                }
                else
                {
                    overlappedPresenter.SetBorderAndTitleBar(false, false);
                    overlappedPresenter.Maximize();
                }

                break;
        }
#endif
    }

    /// <summary>
    /// 最大化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnToggleMaximizeClicked(object sender, EventArgs e)
    {
#if WINDOWS
        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;

        var appWindow = GetAppWindow(window);

        switch (appWindow.Presenter)
        {
            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                overlappedPresenter.IsMaximizable = !overlappedPresenter.IsMaximizable;
                break;
        }
#endif
    }

    /// <summary>
    /// 最小化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnToggleMinimizeClicked(object sender, EventArgs e)
    {
#if WINDOWS
        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;

        var appWindow = GetAppWindow(window);

        switch (appWindow.Presenter)
        {
            case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                overlappedPresenter.IsMinimizable = !overlappedPresenter.IsMinimizable;
                break;
        }
#endif
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is MainPageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }
}