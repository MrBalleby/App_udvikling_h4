using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YetAnotherWeatherApp.ViewModels;

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
			this.BindingContext = new NoteViewModel();
			base.OnAppearing();
        }

		//Sets a blank drawing list
        protected override void OnAppearing()
        {
            if (paths != new List<SKPath>())
            {
                paths = new List<SKPath>();
            }
        }

		//OnPaint event
		private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
		{
			var surface = e.Surface;
			var canvas = surface.Canvas;
			canvas.Clear(SKColors.White);
			
			var textPaint = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Fill,
				Color = SKColors.Gold,
				TextSize = 60
			};
			canvas.DrawText("Tegneblokken", 60, 60, textPaint);

			//Draws the appering line on the canvas, from the list
			var touchPathStroke = new SKPaint
			{
				IsAntialias = true,
				Style = SKPaintStyle.Stroke,
				Color = SKColors.Green,
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
		//Register touch form user, and saves the coordinates to the list paths
		private void OnTouch(object sender, SKTouchEventArgs e)
		{
			try
			{
				var duration = TimeSpan.FromMilliseconds(1);
				Vibration.Vibrate(duration);
			}
			catch (FeatureNotSupportedException ex)
			{
			}
			catch (Exception ex)
			{
			}
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