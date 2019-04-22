using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace WpfApp32.Models
{
    class PropertyDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate BooleanDataTemplate { get; set; }
        public DataTemplate EnumDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DependencyProperty dpi = item as DependencyProperty;
            if(dpi.PropertyType==typeof(bool))
            {
                return BooleanDataTemplate;
            }

            if(dpi.PropertyType.IsEnum)
            {
                return EnumDataTemplate;
            }

            return DefaultDataTemplate;
        }
    }
}
