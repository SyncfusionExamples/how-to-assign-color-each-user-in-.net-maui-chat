using Syncfusion.Maui.Chat;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChat
{
    public class AuthorColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is ChatViewModel chatViewModel && value is IMessage message)
            {
                if (chatViewModel.AuthorColors.TryGetValue(message.Author, out Color? color))
                {
                    return color ?? Colors.White;
                }
                else
                {
                    return chatViewModel.AddColorForAuthor(message.Author);
                }
            }
            else
            {
                return Colors.White;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Colors.White;
        }
    }
}
