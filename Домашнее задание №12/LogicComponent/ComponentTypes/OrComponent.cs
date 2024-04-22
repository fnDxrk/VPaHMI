using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using hw_12.LogicComponent.Shared;

namespace hw_12.LogicComponent.ComponentTypes;

public class OrComponent : BaseComponent
{
    public override string Name { get; } = "И-НЕ";
    public override int Width { get; } = 50;
    public override int Height { get; } = 50;

    private bool _lastValue = false;
    public override bool GetOutput(IList<bool>? inputValues)
    {
        if (inputValues is not null && inputValues.Any())
        {
            var tmp = true;
            foreach (var v in inputValues)
            {
                tmp |= v;
            }
            
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
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/or_gost.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));
    }

    private void DrawAnsi(DrawingContext context)
    {
        var asset = new Bitmap(AssetLoader.Open(new Uri("avares://hw_12/Assets/or_ansi.png")));

        context.DrawImage(asset, new Rect(0, 0, Width, Height));
    }
}