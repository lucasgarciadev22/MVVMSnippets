using ModernBox.Enums;
using ModernBox.Views;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ModernBox
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class ModernBoxView : Window
    {
        ImageStyles _imageType;
        Exception _exception;
        SystemSound _customSound;
        string _customImageRelativePath;

        internal MessageResults Result { get; set; }

        internal ModernBoxView
            (
            string title, string message, ImageStyles image, ButtonTypes buttonTypes, Exception exception,
            string auxiliaryButtonText = null, string customImageRelativePath = null, SystemSound customSound = null
            )
        {
            InitializeComponent();

            try
            {
                Owner = Application.Current.MainWindow;
            }
            catch (Exception) { }

            _exception = exception;
            _customSound = customSound;
            _imageType = image;
            _customImageRelativePath = customImageRelativePath;

            TitleTextBlock.Text = title;
            MessageTextBlock.Text = message;
            SeeMoreDetailsButton.Visibility = exception != null ? Visibility.Visible : Visibility.Hidden;

            SetResultButtonsConfig(buttonTypes, auxiliaryButtonText);
            SetImagesConfig();
        }

        void SetResultButtonsConfig(ButtonTypes buttonTypes, string auxiliary = null)
        {
            PositiveButton.Visibility = Visibility.Hidden;
            NegativeButton.Visibility = Visibility.Hidden;
            AuxiliaryButton.Visibility = Visibility.Hidden;

            string ok = "Ok";
            string cancel = "Cancel";
            string yes = "Yes";
            string no = "No";

            switch (buttonTypes)
            {
                case ButtonTypes.Ok:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = ok;
                    PositiveButton.Margin = new Thickness(0, 0, 50, 0);
                    break;

                case ButtonTypes.CancelOk:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = ok;
                    PositiveButton.Margin = new Thickness(0, 0, 150, 0);

                    NegativeButton.Visibility = Visibility.Visible;
                    NegativeButton.Content = cancel;
                    NegativeButton.Margin = new Thickness(0, 0, 50, 0);
                    break;

                case ButtonTypes.NoYes:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = yes;
                    PositiveButton.Margin = new Thickness(0, 0, 150, 0);

                    NegativeButton.Visibility = Visibility.Visible;
                    NegativeButton.Content = no;
                    NegativeButton.Margin = new Thickness(0, 0, 50, 0);
                    break;

                case ButtonTypes.OkAux:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = ok;
                    PositiveButton.Margin = new Thickness(0, 0, 150, 0);

                    AuxiliaryButton.Visibility = Visibility.Visible;
                    AuxiliaryButton.Content = auxiliary;
                    break;

                case ButtonTypes.CancelOkAux:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = ok;

                    NegativeButton.Visibility = Visibility.Visible;
                    NegativeButton.Content = cancel;

                    AuxiliaryButton.Visibility = Visibility.Visible;
                    AuxiliaryButton.Content = auxiliary;
                    break;

                case ButtonTypes.NoYesAux:
                    PositiveButton.Visibility = Visibility.Visible;
                    PositiveButton.Content = yes;

                    NegativeButton.Visibility = Visibility.Visible;
                    NegativeButton.Content = no;

                    AuxiliaryButton.Visibility = Visibility.Visible;
                    AuxiliaryButton.Content = auxiliary;
                    break;
            }
        }

        void SetImagesConfig()
        {
            switch (_imageType)
            {
                case ImageStyles.None:
                    ImageColunm.Width = new GridLength(30);
                    break;

                case ImageStyles.Success:
                    AlertImage.Source = new BitmapImage(new Uri(@"Images\success.png", UriKind.Relative));
                    break;

                case ImageStyles.Error:
                    AlertImage.Source = new BitmapImage(new Uri(@"Images\error.png", UriKind.Relative));
                    break;

                case ImageStyles.Info:
                    AlertImage.Source = new BitmapImage(new Uri(@"Images\info.png", UriKind.Relative));
                    break;

                case ImageStyles.Question:
                    AlertImage.Source = new BitmapImage(new Uri(@"Images\question.png", UriKind.Relative));
                    break;
                case ImageStyles.Warning:
                    AlertImage.Source = new BitmapImage(new Uri(@"Images\warning.png", UriKind.Relative));
                    break;
                case ImageStyles.Custom:
                    AlertImage.Source = new BitmapImage(new Uri(_customImageRelativePath, UriKind.Relative));
                    break;
            }
        }

        void OnPositiveButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.Positive;
            Close();
        }

        void OnNegativeButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.Negative;
            Close();
        }

        void OnAuxiliaryButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageResults.Auxiliary;
            Close();
        }

        void ShowExceptionDetailsView(object sender, RoutedEventArgs e)
        {
            new ExceptionDetailsView(_exception.StackTrace).Show();
        }

        void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        void OnContentRendered(object sender, EventArgs e)
        {
            switch (_imageType)
            {
                case ImageStyles.Success:
                    SystemSounds.Asterisk.Play();
                    break;

                case ImageStyles.Error:
                    SystemSounds.Hand.Play();
                    break;

                case ImageStyles.Question:
                    SystemSounds.Exclamation.Play();
                    break;
                case ImageStyles.None:
                    break;
                case ImageStyles.Warning:
                    break;
                case ImageStyles.Info:
                    break;
                case ImageStyles.Custom:

                    break;
            }
        }
    }
}
