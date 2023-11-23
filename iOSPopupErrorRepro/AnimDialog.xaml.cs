using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using SkiaSharp.Extended.UI.Controls;

namespace iOSPopupErrorRepro
{
    public partial class AnimDialog : Popup
    {
        public Task Initialization { get; private set; }

        public AnimDialog()
        {
            InitializeComponent();

            Initialization = InitializePlayingAsync();

            this.BindingContext = this;
            ResultWhenUserTapsOutsideOfPopup = false;
        }

        public async Task InitializePlayingAsync()
        {
            // this is needed for windows and IOS
            // IOS for animation
            // Windows for sound when opening more than 1 time
            await Task.Delay(200);

            AnimIcon.IsAnimationEnabled = true;
            player.Play();
        }

        public static readonly BindableProperty AudioFileProperty = BindableProperty.Create(nameof(AudioFile), typeof(MediaSource), typeof(MediaSource));
        public MediaSource AudioFile
        {
            get => (MediaSource)this.GetValue(AudioFileProperty);
            set
            {
                this.SetValue(AudioFileProperty, value);
            }
        }

        public static readonly BindableProperty TitleProp = BindableProperty.Create(nameof(Title), typeof(string), typeof(string));
        public string Title
        {
            get => (string)this.GetValue(TitleProp);
            set => this.SetValue(TitleProp, value);
        }

        public static readonly BindableProperty IconAnimationProperty = BindableProperty.Create(nameof(IconAnimation), typeof(SKFileLottieImageSource), typeof(SKFileLottieImageSource));
        public string IconAnimation
        {
            get => (string)this.GetValue(IconAnimationProperty);
            set
            {
                this.SetValue(IconAnimationProperty, value);
                var source = new SKFileLottieImageSource
                {
                    File = value
                };
                AnimIcon.Source = source;
            }
        }

        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(AnimDialog), default(string));

        public string Message
        {
            get => (string)this.GetValue(MessageProperty);
            set => this.SetValue(MessageProperty, value);
        }

        public static readonly BindableProperty OkButtonProperty = BindableProperty.Create(nameof(OkButton), typeof(string), typeof(AnimDialog), default(string), BindingMode.OneWay, null, (bindable, oldValue, newValue) => ((AnimDialog)bindable).UpdateButtons());

        public string OkButton
        {
            get => (string)this.GetValue(OkButtonProperty);
            set => this.SetValue(OkButtonProperty, value);
        }

        public static readonly BindableProperty CancelButtonProperty = BindableProperty.Create(nameof(CancelButton), typeof(string), typeof(AnimDialog), default(string), BindingMode.OneWay, null, (bindable, oldValue, newValue) => ((AnimDialog)bindable).UpdateButtons());

        public string CancelButton
        {
            get => (string)this.GetValue(CancelButtonProperty);
            set => this.SetValue(CancelButtonProperty, value);
        }

        private async void BtnOk_Clicked(object sender, EventArgs e)
        {
            await this.CloseAsync(true);
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await this.CloseAsync(false);
        }

        private void UpdateButtons()
        {
            this.ColumnLeft.Width = string.IsNullOrEmpty(OkButton) ? new GridLength(0) : GridLength.Star;
            this.ColumnRight.Width = string.IsNullOrEmpty(CancelButton) ? new GridLength(0) : GridLength.Star;
        }
    }
}