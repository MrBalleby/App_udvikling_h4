using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YetAnotherWeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteView : ContentPage
    {
        private readonly Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        private List<SKPath> paths = new List<SKPath>();

        public NoteView()
        {
            InitializeComponent();
			base.OnAppearing();
        }

        protected override void OnAppearing()
        {
            if (paths != new List<SKPath>())
            {
                paths = new List<SKPath>();
            }
        }

		private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
		{
			var surface = e.Surface;
			var canvas = surface.Canvas;
			canvas.Clear(SKColors.White);
			
			var textPaint = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Fill,
				Color = SKColors.Blue,
				TextSize = 80
			};
			canvas.DrawText("Tegneblokken", 60, 160 + 80, textPaint);

			var touchPathStroke = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Stroke,
				Color = SKColors.Purple,
				StrokeWidth = 5
			};
			foreach (var touchPath in temporaryPaths)
			{
				canvas.DrawPath(touchPath.Value, touchPathStroke);
			}
			foreach (var touchPath in paths)
			{
				canvas.DrawPath(touchPath, touchPathStroke);
			}
		}

		private void OnTouch(object sender, SKTouchEventArgs e)
		{
			switch (e.ActionType)
			{
				case SKTouchAction.Pressed:
					var p = new SKPath();
					p.MoveTo(e.Location);
					temporaryPaths[e.Id] = p;
					break;
				case SKTouchAction.Moved:
					if (e.InContact && temporaryPaths.TryGetValue(e.Id, out var moving))
						moving.LineTo(e.Location);
					break;
				case SKTouchAction.Released:
					if (temporaryPaths.TryGetValue(e.Id, out var releasing))
						paths.Add(releasing);
					temporaryPaths.Remove(e.Id);
					break;
				case SKTouchAction.Cancelled:
					temporaryPaths.Remove(e.Id);
					break;
			}
			if (e.InContact)
				((SKCanvasView)sender).InvalidateSurface();

			e.Handled = true;
		}
	}
}