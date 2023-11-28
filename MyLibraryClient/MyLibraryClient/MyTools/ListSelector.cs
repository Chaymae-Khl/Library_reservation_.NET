using StudentsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyLibraryClient.MyTools
{
    public class ListSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (item is Students)
            {
                return element.FindResource("StudentDataTemplate") as DataTemplate;
            }
            else
                return element.FindResource("BookDataTemplate") as DataTemplate;
        }


    }
}
