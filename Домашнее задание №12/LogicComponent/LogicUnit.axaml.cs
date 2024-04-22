using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Threading;
using hw_12.LogicComponent.ComponentTypes;
using hw_12.LogicComponent.Shared;

namespace hw_12.LogicComponent;

public partial class LogicUnit : Control
{
    public static readonly StyledProperty<BaseComponent> LogicComponentProperty =
        AvaloniaProperty.Register<LogicUnit, BaseComponent>(
            name: nameof(LogicComponent));

    public static readonly StyledProperty<VisualizationTypes> VisualizationTypeProperty =
        AvaloniaProperty.Register<LogicUnit, VisualizationTypes>(
            name: nameof(VisualizationType),
            defaultValue: VisualizationTypes.ANSI);

    public static readonly StyledProperty<ObservableCollection<bool>> InputValuesProperty =
        AvaloniaProperty.Register<LogicUnit, ObservableCollection<bool>>(
            name: nameof(InputValues),
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<bool> OutputValueProperty =
        AvaloniaProperty.Register<LogicUnit, bool>(
            name: nameof(OutputValue),
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<bool> IsSelectedProperty =
        AvaloniaProperty.Register<LogicUnit, bool>(
            name: nameof(IsSelected), 
            false,
            defaultBindingMode: BindingMode.TwoWay);
    public BaseComponent LogicComponent
    {
        get => GetValue(LogicComponentProperty);
        set => SetValue(LogicComponentProperty, value);
    }
    public VisualizationTypes VisualizationType
    {
        get => GetValue(VisualizationTypeProperty);
        set => SetValue(VisualizationTypeProperty, value);
    }

    public ObservableCollection<bool> InputValues
    {
        get => GetValue(InputValuesProperty);
        set => SetValue(InputValuesProperty, value);
    }

    public bool OutputValue
    {
        get => GetValue(OutputValueProperty);
        set => SetValue(OutputValueProperty, value);
    }

    public bool IsSelected
    {
        get => GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        OutputValue = LogicComponent.GetOutput(InputValues);
        LogicComponent.Render(context, VisualizationType);

        if (IsSelected)
        {
            context.DrawRectangle(
                new Pen(Brushes.ForestGreen, 5),
                new Rect(0, 0, 50, 50)
                );
        }
    }

    public LogicUnit()
    {

        Loaded += (s, o) =>
        {

            MinWidth = 50;
            MinHeight = 50;
            Margin = new Thickness(5);
            Width = LogicComponent.Width;
            Height = LogicComponent.Height;

            Tapped += (s, o) =>
            {
                IsSelected = !IsSelected;
                Dispatcher.UIThread.Invoke(InvalidateVisual);
            };
            InputValues.CollectionChanged += (sender, args) =>
            {
                Dispatcher.UIThread.Invoke(InvalidateVisual);
            };
        };


    }
}