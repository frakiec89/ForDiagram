using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Xceed.Wpf.Toolkit;

namespace ForDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<MyPropery> properies = new List<MyPropery>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MyPropery propery =  new MyPropery();
            stak_main.Children.Add( GetElement (propery));
        }

        private UIElement GetElement(MyPropery propery)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stak_main.Margin =  new Thickness(5);

            Label label = new Label();
            label.Content = "Введите название ";
            label.HorizontalAlignment = HorizontalAlignment.Center; 
            label.VerticalAlignment = VerticalAlignment.Center; 
            label.Margin = new Thickness(5);
            stackPanel.Children.Add( label );

            TextBox textBox = new TextBox();
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.MinWidth = 150;
            textBox.Margin = new Thickness(5);
            textBox.Name = "tbName";
            textBox.Text = "Столбец" + (stak_main.Children.Count +1);

            stackPanel.Children.Add(textBox);


            Label label2 = new Label();
            label2.Content = "Введите значение ";
            label2.HorizontalAlignment = HorizontalAlignment.Center;
            label2.VerticalAlignment = VerticalAlignment.Center;
            label2.Margin = new Thickness(5);
            stackPanel.Children.Add(label2);

            TextBox textBox2 = new TextBox();
            textBox2.HorizontalAlignment = HorizontalAlignment.Center;
            textBox2.VerticalAlignment = VerticalAlignment.Center;
            textBox2.MinWidth = 50;
            textBox2.Margin = new Thickness(5);
            textBox2.Name = "tbValue";
            textBox2.Text = "0";
            stackPanel.Children.Add(textBox2);


            Label label3 = new Label();
            label3.HorizontalAlignment = HorizontalAlignment.Center;
            label3.VerticalAlignment = VerticalAlignment.Center;
            label3.Margin = new Thickness(5);
            label3.Content = "Укажите цвет";

            stackPanel.Children.Add(label3);

            ColorPicker color = new ColorPicker();
            color.MinWidth = 50;
            color.Margin = new Thickness(5);

            stackPanel.Children.Add(color);
            return stackPanel;
        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            properies.Clear();

            int x = 1;
            lbResault.Items.Clear();
         
            foreach (var stack in stak_main.Children)
            {
                MyPropery myPropery = new MyPropery();
              
                myPropery.Id = x;

                StackPanel stackPanel = stack as StackPanel;

                foreach (var  element  in stackPanel.Children)
                {
                    TextBox textBox =  element as TextBox;

                    if(textBox != null && textBox.Name == "tbName")
                    {
                        myPropery.Name = textBox.Text;
                    }

                    if (textBox != null && textBox.Name == "tbValue")
                    {
                        try
                        {
                            myPropery.Value = Convert.ToDouble(textBox.Text);
                        }
                        catch 
                        {
                            myPropery.Value= 0;
                        }
                      
                    }

                    ColorPicker colorPicker = element as ColorPicker;
                    if(colorPicker != null)
                    {
                        try
                        {
                            myPropery.Color = colorPicker.SelectedColor.Value.ToString();
                        }
                        catch
                        {
                            myPropery.Color = "Без цвета";
                        }
                      
                    }
                }
                properies.Add(myPropery);
                x++;
            }
            
           
            foreach (var item in properies)
            {
                lbResault.Items.Add(item);
            }
        }
    }
}