using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using hw_12.LogicComponent.Shared;

namespace hw_12.LogicComponent.ComponentTypes;

public class BufferComponent : BaseComponent
{
    public override string Name { get; } = "Буффер";
    public override int Width { get; } = 50;
    public override int Height { get; } = 50;

    private bool _lastValue = false;
    public override bool GetOutput(IList<bool>? inputValues)
    {
        if (inputValues is not null && inputValues.Any())
        {
            bool current = inputValues.First();
            bool tmp = _lastValue;
            _lastValue = current;
            
            return tmp;
        }

        return false;
    }

    public override void Render(DrawingContext context, VisualizationTypes visualizationType)
    {
        if (visualizationType == VisualizationTypes.ANSI)
        {
            DrawAnsi(context);
        }
        else
        {
            DrawGost(context);
        }
    }

    private void DrawGost(DrawingContext context)
    {
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/buf_gost.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));
    }

    private void DrawAnsi(DrawingContext context)
    {
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/buf_ansi.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));
    }
}