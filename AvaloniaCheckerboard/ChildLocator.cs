using Avalonia;
using Avalonia.Collections;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using System.Collections.Generic;

namespace AvaloniaCheckerboard
{
    public interface IChildLocator
    {
        T? FindLogical<T>(IEnumerable<ILogical> children, string? name = null);

        T? FindVisual<T>(IEnumerable<Visual> children, string? name = null);
    }

    public class ChildLocator : IChildLocator
    {
        public T? FindLogical<T>(IEnumerable<ILogical> children, string? name = null)
        {
            foreach (var child in children)
            {
                if (child is T t)
                {
                    return t;
                }

                var found = FindLogical<T>(child.LogicalChildren, name);

                if (found != null)
                {
                    return found;
                }
            }

            return default;
        }

        public T? FindVisual<T>(IEnumerable<Visual> children, string? name = null)
        {
            foreach (var child in children)
            {
                if (child is T t)
                {
                    return t;
                }

                var found = FindVisual<T>(child.GetVisualChildren(), name);

                if (found != null)
                {
                    return found;
                }
            }

            return default;
        }
    }
}
