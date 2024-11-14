using DotNurse.Injector.Attributes;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace Dorisoy.PeriodontalChat;

/// <summary>
/// 牙龈宽度,袋深(数据结构)
/// </summary>
[RegisterAs(typeof(ToothPoint), ServiceLifetime.Singleton)]
public class ToothPoint : ReactiveObject
{
    [Reactive] public int Point1 { get; set; }
    [Reactive] public int Point2 { get; set; }
    [Reactive] public int Point3 { get; set; }
}

/// <summary>
/// 龋齿(数据结构)
/// </summary>
[RegisterAs(typeof(DentalCaries), ServiceLifetime.Singleton)]
public class DentalCaries : ReactiveObject
{
    [Reactive] public bool Point1 { get; set; }
    [Reactive] public bool Point2 { get; set; }
    [Reactive] public bool Point3 { get; set; }
    [Reactive] public bool Point4 { get; set; }
    [Reactive] public bool Point5 { get; set; }
    [Reactive] public bool Point6 { get; set; }

    [Reactive] public int Number1 { get; set; }
    [Reactive] public int Number2 { get; set; }
    [Reactive] public int Number3 { get; set; }
    [Reactive] public int Number4 { get; set; }
    [Reactive] public int Number5 { get; set; }
    [Reactive] public int Number6 { get; set; }
}

/// <summary>
/// 根分叉(数据结构)
/// </summary>
[RegisterAs(typeof(RootBiFurcation), ServiceLifetime.Singleton)]
public class RootBiFurcation : ReactiveObject
{
    [Reactive] public bool Point1 { get; set; }
    [Reactive] public bool Point2 { get; set; }
    [Reactive] public int Counter1 { get; set; }
    [Reactive] public int Counter2 { get; set; }
}

/// <summary>
/// 出血,菌斑,牙结石,溢脓(数据结构)
/// </summary>
[RegisterAs(typeof(CheckPoint), ServiceLifetime.Singleton)]
public class CheckPoint : ReactiveObject
{
    [Reactive] public bool Point1 { get; set; }
    [Reactive] public bool Point2 { get; set; }
    [Reactive] public bool Point3 { get; set; }
}

/// <summary>
/// 表示牙齿模型
/// </summary>
[RegisterAs(typeof(Tooth), ServiceLifetime.Singleton)]
public class Tooth : ReactiveObject
{
    /// <summary>
    /// 牙位索引
    /// </summary>
    [Reactive] public int ToothIndex { get; set; }

    /// <summary>
    /// 牙位序号
    /// </summary>
    [Reactive] public int ToothNumber { get; set; }

    /// <summary>
    /// 牙位Img
    /// </summary>
    [Reactive] public string ToothImage { get; set; }
    /// <summary>
    /// 牙位Img
    /// </summary>
    [Reactive] public string ToothImage2 { get; set; }



    /// <summary>
    /// 缺失
    /// </summary>
    [Reactive] public bool Available { get; set; }

    /// <summary>
    /// 松动度
    /// </summary>
    [Reactive] public int Mobility { get; set; }

    /// <summary>
    /// 种植牙
    /// </summary>
    [Reactive] public bool DentalImplant { get; set; }
    [Reactive] public string DentalImplantImage { get; set; }
    [Reactive] public string DentalImplantImage2 { get; set; }

    /// <summary>
    /// 根分叉 
    /// </summary>
    [Reactive] public RootBiFurcation RootBiFurcation { get; set; } = new();
    [Reactive] public RootBiFurcation RootBiFurcation2 { get; set; } = new();
    [Reactive] public bool ShowRBF { get; set; }
    [Reactive] public bool ShowRBF2 { get; set; }

    /// <summary>
    /// 牙髓/周炎
    /// </summary>
    [Reactive] public bool Periodontitis { get; set; }
    [Reactive] public string PeriodontitisImage { get; set; }
    [Reactive] public string PeriodontitisImage2 { get; set; }

    /// <summary>
    /// 填充物
    /// </summary>
    [Reactive] public bool FillingMaterial { get; set; }


    /// <summary>
    /// 龋齿 
    /// </summary>
    [Reactive] public DentalCaries DentalCaries { get; set; } = new();
    [Reactive] public DentalCaries DentalCaries2 { get; set; } = new();
    [Reactive] public string DentalCariesImage1 { get; set; }
    [Reactive] public string DentalCariesImage2 { get; set; }
    [Reactive] public string DentalCariesImage3 { get; set; }
    [Reactive] public string DentalCariesImage4 { get; set; }
    [Reactive] public string DentalCariesImage5 { get; set; }
    [Reactive] public string DentalCariesImage6 { get; set; }

    [Reactive] public string DentalCariesImage21 { get; set; }
    [Reactive] public string DentalCariesImage22 { get; set; }
    [Reactive] public string DentalCariesImage23 { get; set; }
    [Reactive] public string DentalCariesImage24 { get; set; }
    [Reactive] public string DentalCariesImage25 { get; set; }
    [Reactive] public string DentalCariesImage26 { get; set; }


    /// <summary>
    /// 出血
    /// </summary>
    [Reactive] public CheckPoint Bleeding { get; set; } = new();

    /// <summary>
    /// 菌斑 
    /// </summary>
    [Reactive] public CheckPoint BacterialPlaque { get; set; } = new();

    /// <summary>
    /// 牙结石 
    /// </summary>
    [Reactive] public CheckPoint DentalCalculus { get; set; } = new();

    /// <summary>
    /// 溢脓 
    /// </summary>
    [Reactive] public CheckPoint OverflowPus { get; set; } = new();

    /// <summary>
    /// 牙龈宽度  
    /// </summary>
    [Reactive] public ToothPoint GingivalWidth { get; set; } = new();
    [Reactive] public ToothPoint GingivalWidth2 { get; set; } = new();


    /// <summary>
    /// 袋深  
    /// </summary>
    [Reactive] public ToothPoint ProbingDepth { get; set; } = new();
    [Reactive] public ToothPoint ProbingDepth2 { get; set; } = new();

    [Reactive] public bool ShowChat { get; set; }
    [Reactive] public bool ShowChat2 { get; set; }

    /// <summary>
    /// Buccal 袋深/宽度 Chat
    /// </summary>
    [Reactive]
    public ISeries[] Series { get; set; } =
    {
        // 袋深
        new LineSeries<int>
        {
            Values = new ObservableCollection<int>{0,0,0},
            Stroke = new SolidColorPaint
            {
                // 线条颜色
                Color = SkiaSharp.SKColors.Blue,
                // 设置线条粗细
                StrokeThickness = 1
            },
            // 设置标记点的大小,GeometrySize 被设置为 10，表示每个标记的大小是 10x10 像素的正方形区域
            GeometrySize = 5,
            GeometryFill = new SolidColorPaint(SKColors.Blue) // 这将使点成为实心的
        },
        // 宽度
        new LineSeries<int>
        {
            Values = new ObservableCollection<int>{0,0,0},
            Stroke = new SolidColorPaint
            {
                // 线条颜色
                Color = SkiaSharp.SKColors.Red,
                // 设置线条粗细
                StrokeThickness = 1
            },
            // 设置标记点的大小,GeometrySize 被设置为 10，表示每个标记的大小是 10x10 像素的正方形区域
            GeometrySize = 5,
            GeometryFill = new SolidColorPaint(SKColors.Red) // 这将使点成为实心的
        }
    };

    /// <summary>
    /// Lingual 袋深/宽度 Chat
    /// </summary>
    [Reactive]
    public ISeries[] Series2 { get; set; } =
    {
        // 袋深
        new LineSeries<int>
        {
            Values = new ObservableCollection<int>{0,0,0},
            Stroke = new SolidColorPaint
            {
                // 线条颜色
                Color = SkiaSharp.SKColors.Blue,
                // 设置线条粗细
                StrokeThickness = 1
            },
            // 设置标记点的大小,GeometrySize 被设置为 10，表示每个标记的大小是 10x10 像素的正方形区域
            GeometrySize = 5,
            GeometryFill = new SolidColorPaint(SKColors.Blue) // 这将使点成为实心的
        },
        // 宽度
        new LineSeries<int>
        {
            Values = new ObservableCollection<int>{0,0,0},
            Stroke = new SolidColorPaint
            {
                // 线条颜色
                Color = SkiaSharp.SKColors.Red,
                // 设置线条粗细
                StrokeThickness = 1
            },
            // 设置标记点的大小,GeometrySize 被设置为 10，表示每个标记的大小是 10x10 像素的正方形区域
            GeometrySize = 5,
            GeometryFill = new SolidColorPaint(SKColors.Red) // 这将使点成为实心的
        }
    };

    /// <summary>
    /// 配置X轴
    /// </summary>
    public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            IsVisible = false,
            // 设置刻度线样式
            SeparatorsPaint = new SolidColorPaint 
           {
                // 不显示刻度线
               StrokeThickness = 0 
           }
        }
    };


    /// <summary>
    /// 配置Y轴
    /// </summary>
    public Axis[] YAxes { get; set; } =
    {
        new Axis
        {
            IsVisible = false,
            // 设置刻度线样式
            SeparatorsPaint = new SolidColorPaint
           {
                // 不显示刻度线
               StrokeThickness = 0
           }
        }
    };
}

/// <summary>
/// 上唇侧 Buccal
/// </summary>
[RegisterAs(typeof(Table1), ServiceLifetime.Singleton)]
public class Table1 : ReactiveObject
{
    /// <summary>
    /// 缺失
    /// </summary>
    [Reactive] public List<Tooth> Row1 { get; set; } = [];
    /// <summary>
    /// 松动度
    /// </summary>
    [Reactive] public List<Tooth> Row2 { get; set; } = [];
    /// <summary>
    /// 种植牙
    /// </summary>
    [Reactive] public List<Tooth> Row3 { get; set; } = [];
    /// <summary>
    /// 根分叉
    /// </summary>
    [Reactive] public List<Tooth> Row4 { get; set; } = [];
    /// <summary>
    /// 牙髓/周炎
    /// </summary>
    [Reactive] public List<Tooth> Row5 { get; set; } = [];
    /// <summary>
    /// 填充物
    /// </summary>
    [Reactive] public List<Tooth> Row6 { get; set; } = [];
    /// <summary>
    /// 龋齿
    /// </summary>
    [Reactive] public List<Tooth> Row7 { get; set; } = [];
    /// <summary>
    /// 出血
    /// </summary>
    [Reactive] public List<Tooth> Row8 { get; set; } = [];
    /// <summary>
    /// 菌斑
    /// </summary>
    [Reactive] public List<Tooth> Row9 { get; set; } = [];
    /// <summary>
    /// 牙结石
    /// </summary>
    [Reactive] public List<Tooth> Row10 { get; set; } = [];
    /// <summary>
    /// 溢脓
    /// </summary>
    [Reactive] public List<Tooth> Row11 { get; set; } = [];
    /// <summary>
    /// 牙龈宽度
    /// </summary>
    [Reactive] public List<Tooth> Row12 { get; set; } = [];
    /// <summary>
    /// 袋深
    /// </summary>
    [Reactive] public List<Tooth> Row13 { get; set; } = [];
    /// <summary>
    /// 唇侧
    /// </summary>
    [Reactive] public List<Tooth> Row14 { get; set; } = [];
}

/// <summary>
/// 舌侧 Lingual
/// </summary>
[RegisterAs(typeof(Table2), ServiceLifetime.Singleton)]
public class Table2 : ReactiveObject
{
    /// <summary>
    /// 舌侧
    /// </summary>
    [Reactive] public List<Tooth> Row1 { get; set; } = [];
    /// <summary>
    /// 牙龈宽度
    /// </summary>
    [Reactive] public List<Tooth> Row2 { get; set; } = [];
    /// <summary>
    /// 袋深
    /// </summary>
    [Reactive] public List<Tooth> Row3 { get; set; } = [];
    /// <summary>
    /// 根分叉
    /// </summary>
    [Reactive] public List<Tooth> Row4 { get; set; } = [];
    /// <summary>
    /// 龋齿
    /// </summary>
    [Reactive] public List<Tooth> Row5 { get; set; } = [];
    /// <summary>
    /// 出血
    /// </summary>
    [Reactive] public List<Tooth> Row6 { get; set; } = [];
    /// <summary>
    /// 菌斑
    /// </summary>
    [Reactive] public List<Tooth> Row7 { get; set; } = [];
    /// <summary>
    /// 牙结石
    /// </summary>
    [Reactive] public List<Tooth> Row8 { get; set; } = [];
    /// <summary>
    /// 溢脓
    /// </summary>
    [Reactive] public List<Tooth> Row9 { get; set; } = [];
}

/// <summary>
/// 腭测 Vestibul
/// </summary>
[RegisterAs(typeof(Table3), ServiceLifetime.Singleton)]
public class Table3 : ReactiveObject
{
    /// <summary>
    /// 出血
    /// </summary>
    [Reactive] public List<Tooth> Row1 { get; set; } = [];
    /// <summary>
    /// 菌斑
    /// </summary>
    [Reactive] public List<Tooth> Row2 { get; set; } = [];
    /// <summary>
    /// 牙结石
    /// </summary>
    [Reactive] public List<Tooth> Row3 { get; set; } = [];
    /// <summary>
    /// 溢脓
    /// </summary>
    [Reactive] public List<Tooth> Row4 { get; set; } = [];
    /// <summary>
    /// 根分叉
    /// </summary>
    [Reactive] public List<Tooth> Row5 { get; set; } = [];
    /// <summary>
    /// 龋齿
    /// </summary>
    [Reactive] public List<Tooth> Row6 { get; set; } = [];
    /// <summary>
    /// 牙龈宽度
    /// </summary>
    [Reactive] public List<Tooth> Row7 { get; set; } = [];
    /// <summary>
    /// 袋深
    /// </summary>
    [Reactive] public List<Tooth> Row8 { get; set; } = [];
    /// <summary>
    /// 腭侧
    /// </summary>
    [Reactive] public List<Tooth> Row9 { get; set; } = [];
}

/// <summary>
/// 下唇侧 Buccal
/// </summary>
[RegisterAs(typeof(Table4), ServiceLifetime.Singleton)]
public class Table4 : ReactiveObject
{
    /// <summary>
    /// 唇侧
    /// </summary>
    [Reactive] public List<Tooth> Row1 { get; set; } = [];
    /// <summary>
    /// 牙龈宽度
    /// </summary>
    [Reactive] public List<Tooth> Row2 { get; set; } = [];
    /// <summary>
    /// 袋深
    /// </summary>
    [Reactive] public List<Tooth> Row3 { get; set; } = [];
    /// <summary>
    /// 根分叉
    /// </summary>
    [Reactive] public List<Tooth> Row4 { get; set; } = [];
    /// <summary>
    /// 龋齿
    /// </summary>
    [Reactive] public List<Tooth> Row5 { get; set; } = [];
    /// <summary>
    /// 出血
    /// </summary>
    [Reactive] public List<Tooth> Row7 { get; set; } = [];
    /// <summary>
    /// 菌斑
    /// </summary>
    [Reactive] public List<Tooth> Row8 { get; set; } = [];
    /// <summary>
    /// 牙结石
    /// </summary>
    [Reactive] public List<Tooth> Row9 { get; set; } = [];
    /// <summary>
    /// 溢脓
    /// </summary>
    [Reactive] public List<Tooth> Row10 { get; set; } = [];
    /// <summary>
    /// 填充物
    /// </summary>
    [Reactive] public List<Tooth> Row11 { get; set; } = [];
    /// <summary>
    /// 牙髓/周炎
    /// </summary>
    [Reactive] public List<Tooth> Row12 { get; set; } = [];
    /// <summary>
    /// 种植牙
    /// </summary>
    [Reactive] public List<Tooth> Row13 { get; set; } = [];
    /// <summary>
    /// 松动度
    /// </summary>
    [Reactive] public List<Tooth> Row14 { get; set; } = [];
    /// <summary>
    /// 缺失
    /// </summary>
    [Reactive] public List<Tooth> Row15 { get; set; } = [];
}

/// <summary>
/// 牙周检查模型
/// </summary>
[RegisterAs(typeof(Periodontal), ServiceLifetime.Singleton)]
public class Periodontal : ReactiveObject
{
    /// <summary>
    /// 就诊号
    /// </summary>
    [Reactive] public string MedicalNumber { get; set; }

    /// <summary>
    /// 首次
    /// </summary>
    [Reactive] public bool First { get; set; }

    /// <summary>
    /// 复查
    /// </summary>
    [Reactive] public bool Review { get; set; }

    /// <summary>
    /// 检查日期
    /// </summary>
    [Reactive] public DateTime CheckDate { get; set; }

    /// <summary>
    /// 患者
    /// </summary>
    [Reactive] public string UserName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [Reactive] public string Sex { get; set; }

    /// <summary>
    /// 出生日期
    /// </summary>
    [Reactive] public string DateOfBirth { get; set; }

    /// <summary>
    /// 医生
    /// </summary>
    [Reactive] public string Doctor { get; set; }

    /// <summary>
    /// 上牙序(第一列为标题)
    /// </summary>
    public List<int> ToothNumber1 { get; set; } = [0, 18, 17, 16, 15, 14, 13, 12, 11, 21, 22, 23, 24, 25, 26, 27, 28];
    public List<int> RBFIncludes1 { get; set; } = [18, 17, 16, 26, 27, 28];
    public List<int> RBFIncludes2 { get; set; } = [18, 17, 16, 14, 24, 26, 27, 28];
    public Dictionary<int, List<int>> DentalCaries1 { get; set; } = new()
    {
        { 18, new() { 1, 5, 2, 2, 6, 6 } },
        { 17, new() { 1, 5, 2, 2, 6, 6 } },
        { 16, new() { 1, 5, 2, 2, 6, 6 } },
        { 15, new() { 1, 5, 2, 2, 6, 6 } },
        { 14, new() { 1, 5, 2, 2, 6, 6 } },

        { 13, new() { 3, 3, 4, 4, 5, 6 } },
        { 12, new() { 3, 3, 4, 4, 5, 6 } },
        { 11, new() { 3, 3, 4, 4, 5, 6 } },
        { 21, new() { 3, 3, 4, 4, 5, 6 } },
        { 22, new() { 3, 3, 4, 4, 5, 6 } },
        { 23, new() { 3, 3, 4, 4, 5, 6 } },

        { 24, new() { 1, 5, 2, 2, 6, 6 } },
        { 25, new() { 1, 5, 2, 2, 6, 6 } },
        { 26, new() { 1, 5, 2, 2, 6, 6 } },
        { 27, new() { 1, 5, 2, 2, 6, 6 } },
        { 28, new() { 1, 5, 2, 2, 6, 6 } },
    };


    /// <summary>
    /// 下牙序(第一列为标题)
    /// </summary>
    public List<int> ToothNumber2 { get; set; } = [0, 48, 47, 46, 45, 44, 43, 42, 41, 31, 32, 33, 34, 35, 36, 37, 38];
    public List<int> RBFIncludes3 { get; set; } = [48, 47, 46, 36, 37, 38];
    public List<int> RBFIncludes4 { get; set; } = [48, 47, 46, 44, 34, 36, 37, 38];
    public Dictionary<int, List<int>> DentalCaries3 { get; set; }
    public Dictionary<int, List<int>> DentalCaries4 { get; set; }
    public Dictionary<int, List<int>> DentalCaries2 { get; set; } = new()
    {
        { 48, new() { 1, 5, 2, 2, 6, 6 } },
        { 47, new() { 1, 5, 2, 2, 6, 6 } },
        { 46, new() { 1, 5, 2, 2, 6, 6 } },
        { 45, new() { 1, 5, 2, 2, 6, 6 } },
        { 44, new() { 1, 5, 2, 2, 6, 6 } },

        { 43, new() { 3, 3, 4, 4, 5, 6 } },
        { 42, new() { 3, 3, 4, 4, 5, 6 } },
        { 41, new() { 3, 3, 4, 4, 5, 6 } },
        { 31, new() { 3, 3, 4, 4, 5, 6 } },
        { 32, new() { 3, 3, 4, 4, 5, 6 } },
        { 33, new() { 3, 3, 4, 4, 5, 6 } },

        { 34, new() { 1, 5, 2, 2, 6, 6 } },
        { 35, new() { 1, 5, 2, 2, 6, 6 } },
        { 36, new() { 1, 5, 2, 2, 6, 6 } },
        { 37, new() { 1, 5, 2, 2, 6, 6 } },
        { 38, new() { 1, 5, 2, 2, 6, 6 } },
    };

    [Reactive] public Table1 Table1 { get; set; } = new();
    [Reactive] public Table2 Table2 { get; set; } = new();
    [Reactive] public Table3 Table3 { get; set; } = new();
    [Reactive] public Table4 Table4 { get; set; } = new();
}




