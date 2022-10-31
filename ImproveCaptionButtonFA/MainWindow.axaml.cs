using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using FluentAvalonia.Core.ApplicationModel;
using FluentAvalonia.Styling;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Controls.Primitives;

using System;

namespace ImproveCaptionButtonFA
{
    public partial class MainWindow : CoreWindow
    {
        private readonly FluentAvaloniaTheme _theme;

        public MainWindow()
        {
            InitializeComponent();
            _theme = AvaloniaLocator.Current.GetRequiredService<FluentAvaloniaTheme>();
            _theme.RequestedTheme = FluentAvaloniaTheme.LightModeString;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void OnThemeToggleClick(object? sender, RoutedEventArgs e)
        {
            if (ThemeToggle.IsChecked == true)
            {
                _theme.RequestedTheme = FluentAvaloniaTheme.DarkModeString;
            }
            else
            {
                _theme.RequestedTheme = FluentAvaloniaTheme.LightModeString;
            }
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            e.NameScope.Get<MinMaxCloseControl>("SystemCaptionButtons").Height = 40;
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

            CoreApplicationViewTitleBar titleBar = TitleBar;
            if (titleBar != null)
            {
                titleBar.ExtendViewIntoTitleBar = true;

                titleBar.LayoutMetricsChanged += OnApplicationTitleBarLayoutMetricsChanged;

                SetTitleBar(Titlebar);
                Titlebar.Margin = new Thickness(0, 0, titleBar.SystemOverlayRightInset, 0);
            }
        }

        private void OnApplicationTitleBarLayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            Titlebar.Margin = new Thickness(0, 0, sender.SystemOverlayRightInset, 0);
        }
    }
}