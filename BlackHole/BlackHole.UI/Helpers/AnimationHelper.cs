using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace BlackHole.UI.Helpers
{
    public static class AnimationHelper
    {
        public static Storyboard ScaleUpAnimation(UIElement element)
        {
            element.RenderTransform = new CompositeTransform();
            element.RenderTransformOrigin = new Point(0.5, 0.5);

            var story = new Storyboard();

            var xAnim = new DoubleAnimation();
            var yAnim = new DoubleAnimation();

            xAnim.Duration = TimeSpan.FromSeconds(0.25);
            yAnim.Duration = TimeSpan.FromSeconds(0.25);

            xAnim.From = 0;
            yAnim.From = 0;
            xAnim.To = 1;
            yAnim.To = 1;

            story.Children.Add(xAnim);
            story.Children.Add(yAnim);

            Storyboard.SetTarget(xAnim, element);
            Storyboard.SetTarget(yAnim, element);

            Storyboard.SetTargetProperty(xAnim, "(UIElement.RenderTransform).(CompositeTransform.ScaleX)");
            Storyboard.SetTargetProperty(yAnim, "(UIElement.RenderTransform).(CompositeTransform.ScaleY)");

            return story;
        }
    }
}
