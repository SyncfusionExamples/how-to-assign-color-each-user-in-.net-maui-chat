# how-to-assign-color-each-user-in-.net-maui-chat

## Sample

```xaml

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:AuthorColorConverter x:Key="authorColorConverter"/>

            <Style TargetType="syncfusion:OutgoingMessageAuthorView">
                <Setter Property="ControlTemplate">
                    <Setter.Value>
                        <ControlTemplate x:DataType="syncfusion:TextMessage">
                            <Label Text="{Binding Author.Name}" TextColor="{TemplateBinding BindingContext, Converter= {StaticResource authorColorConverter},ConverterParameter={x:Reference viewModel}}" BindingContext="{TemplateBinding BindingContext}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>

            <Style TargetType="syncfusion:IncomingMessageAuthorView">
                <Setter Property="ControlTemplate">
                    <Setter.Value>
                        <ControlTemplate x:DataType="syncfusion:TextMessage">
                            <Label Text="{Binding Author.Name}" TextColor="{TemplateBinding BindingContext, Converter= {StaticResource authorColorConverter},ConverterParameter={x:Reference viewModel}}" BindingContext="{TemplateBinding BindingContext}"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ResourceDictionary>
    </ContentPage.Resources>
    
Convrter:

    public class AuthorColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter is ChatViewModel chatViewModel && value is IMessage message)
            {
                return chatViewModel.AuthorColors.TryGetValue(message.Author, out Color? color)
                    ? color ?? Colors.Black
                    : chatViewModel.AddColorForAuthor(message.Author);
            }

            return Colors.Black;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Colors.Black;
        }
    }

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.

