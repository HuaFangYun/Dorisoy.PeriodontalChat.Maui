using CommunityToolkit.Maui;
using DotNurse.Injector;
using MemoryToolkit.Maui;
using Microsoft.Extensions.Logging;

using Mopups.Hosting;
using ReactiveUI;
using System.Reactive;
using UraniumUI;
using UraniumUI.Options;
using UraniumUI.Validations;

using SkiaSharp.Views.Maui.Controls.Hosting;
using SkiaSharp.Extended.UI;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Microsoft.UI.Dispatching;
using Microsoft.Maui.LifecycleEvents;
#endif

namespace Dorisoy.PeriodontalChat;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseUraniumUIBlurs(false)
            //.UseUraniumUIWebComponents()
            .UseSkiaSharp()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFontAwesomeIconFonts();
                fonts.AddMaterialSymbolsFonts();
                fonts.AddFluentIconFonts();
            });

#if DEBUG

        builder.Logging.AddDebug();

        var memoryLeakEvents = new MemoryLeakDetectEvents();
        builder.Services.AddSingleton(memoryLeakEvents);
        builder.UseLeakDetection(onLeaked: memoryLeakEvents.InvokeOnLeaked, memoryLeakEvents.InvokeOnCollected);

#endif

        builder.Services.Configure<AutoFormViewOptions>(options =>
        {
            options.ValidationFactory = DataAnnotationValidation.CreateValidations;
        });

        RxApp.DefaultExceptionHandler = new AnonymousObserver<Exception>(ex =>
        {
            App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            // Track the exception here... (e.g. AppCenter, Sentry, etc.)
        });

        var thisAssembly = typeof(MauiProgram).Assembly;

        builder.Services.AddServicesFrom(
            type => typeof(Page).IsAssignableFrom(type),
            ServiceLifetime.Transient,
            options => options.Assembly = thisAssembly)
        .AddServicesByAttributes(assembly: thisAssembly);


#if WINDOWS
        //builder.ConfigureLifecycleEvents(events =>
        //{
        //    events.AddWindows(windowsLifecycleBuilder =>
        //    {
        //        windowsLifecycleBuilder.OnWindowCreated(window =>
        //        {
        //            window.ExtendsContentIntoTitleBar = false;
        //            var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        //            var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
        //            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);

        //             // 全屏模式设置（以下代码可能需要根据实现的不同版本进行修改）
        //             //appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

        //            switch (appWindow.Presenter)
        //            {
        //                case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
        //                    overlappedPresenter.SetBorderAndTitleBar(false, false);
        //                    overlappedPresenter.Maximize();
        //                    break;
        //            }
        //        });
        //    });
        //});
#endif

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr hWnd = WindowNative.GetWindowHandle(window);
                    WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
                    AppWindow appWindow = AppWindow.GetFromWindowId(windowId);

                    // 全屏模式设置（以下代码可能需要根据实现的不同版本进行修改）
                    //appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);

                    // 通过 DispatcherQueue 在 UI 线程上执行操作
                    var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
                    dispatcherQueue.TryEnqueue(() =>
                    {
                        // 设置最大化状态
                        var presenter = appWindow.Presenter as OverlappedPresenter;
                        if (presenter != null)
                        {
                            // 设置窗口最大化
                            presenter.Maximize();
                        }
                    });
                });

            });
        });
#endif
        builder.Services.AddCommunityToolkitDialogs();
        builder.Services.AddMopupsDialogs();

        return builder.Build();
    }
}