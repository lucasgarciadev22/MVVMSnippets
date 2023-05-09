using ModernBox.Enums;
using System;

namespace ModernBox
{
    public class ModernBox
    {
        /// <summary>
        /// Without image, with <see cref="ButtonTypes.Ok"/> button available
        /// </summary>
        /// <param name="title"><see cref="ModernBox"/> Title</param>
        /// <param name="message"><see cref="ModernBox"/> Content</param>
        public static void Show(string title, string message)
        {
            ModernBoxView messageBox = new ModernBoxView(title, message, ImageStyles.None, ButtonTypes.Ok, null);
            messageBox.ShowDialog();
        }

        /// <summary>
        /// With Image by choice, with <see cref="ButtonTypes.Ok"/> button available
        /// </summary>
        /// <param name="title"><see cref="ModernBox"/> Title</param>
        /// <param name="message"><see cref="ModernBox"/> Content</param>
        /// <param name="image">Image to show next to content</param>
        public static void Show(string title, string message, ImageStyles image)
        {
            ModernBoxView messageBox = new ModernBoxView(title, message, image, ButtonTypes.Ok, null);
            messageBox.ShowDialog();
        }

        /// <summary>
        /// With the <see cref="Exception.Message"/> in the content, and an Exception Details View with the <see cref="Exception.StackTrace"/> by pressing on "..." button, only with <see cref="ButtonTypes.Ok"/> button available
        /// </summary>
        /// <param name="title"><see cref="ModernBox"/> Title</param>
        /// <param name="exception"><see cref="Exception"/> to show the <see cref="Exception.Message"/> in the content and <see cref="Exception.StackTrace"/> in the exception details view</param>
        public static void Show(string title, Exception exception)
        {
            ModernBoxView messageBox = new ModernBoxView(title, exception.Message, ImageStyles.Error, ButtonTypes.Ok, exception);
            messageBox.ShowDialog();
        }

        /// <summary>
        /// With the <paramref name="preExceptionMessage"/> and the <see cref="Exception.Message"/> in the content, and an Exception Details View with the <see cref="Exception.StackTrace"/> by pressing on "..." button, only with <see cref="ButtonTypes.Ok"/> button available
        /// </summary>
        /// <param name="title"><see cref="PrettyMessageBox"/> Title</param>
        /// <param name="preExceptionMessage">Message to show in the content before the <see cref="Exception.Message"/></param>
        /// <param name="exception"><see cref="Exception"/> to show the <see cref="Exception.Message"/> in the content and <see cref="Exception.StackTrace"/> in the exception details view</param>
        public static void Show(string title, string preExceptionMessage, Exception exception)
        {
            string message = string.IsNullOrEmpty(preExceptionMessage) ? exception.Message : $"{preExceptionMessage}\n{exception.Message}";

            ModernBoxView messageBox = new ModernBoxView(title, message, ImageStyles.Error, ButtonTypes.Ok, exception);
            messageBox.ShowDialog();
        }

        /// <summary>
        /// Without <see cref="ImageStyles"/>, and <see cref="ButtonTypes"/> by user choice
        /// </summary>
        /// <param name="title"><see cref="ModernBox"/> Title</param>
        /// <param name="message"><see cref="ModernBox"/> Content</param>
        /// <param name="buttonOptions">Button configuration to show under the content</param>
        /// <param name="auxiliaryButtonContent">Text to show in the auxiliary button, if chosen in the <paramref name="buttonOptions"/></param>
        /// <returns>Returns <see cref="MessageResults.Positive"/> if user click in "Ok" or "Yes", <see cref="MessageResults.Negative"/> if user click in "Cancel" or "No", and <see cref="MessageResults.Auxiliary"/> if user click in the Auxiliary Button</returns>
        public static MessageResults Show(string title, string message, ButtonTypes buttonOptions, string auxiliaryButtonContent = "")
        {
            ModernBoxView messageBox = new ModernBoxView(title, message, ImageStyles.None, buttonOptions, null, auxiliaryButtonContent);
            messageBox.ShowDialog();

            return messageBox.Result;
        }

        /// <summary>
        /// <see cref="ImageStyles"/> and <see cref="ButtonTypes"/> by user choice
        /// </summary>
        /// <param name="title"><see cref="ModernBoxView"/> Title</param>
        /// <param name="message"><see cref="ModernBoxView"/> Content</param>
        /// <param name="image">Image to show next to content</param>
        /// <param name="buttonOptions">Button configuration to show under the content</param>
        /// <param name="auxiliaryButtonContent">Text to show in the auxiliary button, if chosen in the <paramref name="buttonOptions"/></param>
        /// <returns>Returns <see cref="MessageBoxResults.Positive"/> if user click in "Ok" or "Yes", <see cref="MessageBoxResults.Negative"/> if user click in "Cancel" or "No", and <see cref="MessageResults.Auxiliary"/> if user click in the Auxiliary Button</returns>
        public static MessageResults Show(string title, string message, ImageStyles image, ButtonTypes buttonOptions, string auxiliaryButtonContent = "")
        {
            ModernBoxView messageBox = new ModernBoxView(title, message, image, buttonOptions, null, auxiliaryButtonContent);
            messageBox.ShowDialog();

            return messageBox.Result;
        }
    }
}
