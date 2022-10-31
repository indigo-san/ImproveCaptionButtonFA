using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

using FluentAvalonia.Core.ApplicationModel;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Controls.Primitives;

using System;

namespace ImproveCaptionButtonFA
{
    public partial class MainWindow : CoreWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
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