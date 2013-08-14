using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Progression;
using Microsoft.VisualStudio.GraphModel;
using System.Reflection;



namespace Company.VSPackageTitleName
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
            "My Tool Window");*/

            int openWindowCount = 0;
            EnvDTE80.DTE2 dte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.11.0");
            int openDocumentCount = 0;
            //EnvDTE.DTE dte = (EnvDTE.DTE)Activator.CreateInstance(t);
            string openDocumentNames = "";
            string openWindowNames = "";
            
            
            foreach (EnvDTE.Document doc in dte.Documents)
            {
                string temp = doc.Name;
                openDocumentNames += "," + doc.Name;
                openDocumentCount++;
            }
            MessageBox.Show("There is currently: " + openDocumentCount.ToString() + " Documents" + "They are : " + openDocumentNames);
            bool entered=false;
            foreach (EnvDTE80.Window2 window in dte.Windows)
            {
                 openWindowNames+=","+ window.Caption;
                // MessageBox.Show(window.Caption+ " , " +Microsoft.VisualBasic.Information.TypeName(window.Object));
                 openWindowCount++;
                
                 if (window.Caption.Equals("CodeMap1.dgml")&&!entered)
                 {
                     entered = true;
                     MessageBox.Show("It is code Map");
                     MessageBox.Show(window.Kind);
                     MessageBox.Show(Microsoft.VisualBasic.Information.TypeName(window.Object));
                     GraphControlAutomationObject graphAutomation =(GraphControlAutomationObject) window.Object;
                     Graph graph = graphAutomation.Graph;
                     GraphNodeCollection nodes = graph.Nodes;   
                     MessageBox.Show(nodes.Count.ToString());
                     
                     foreach (GraphNode node in nodes)
                     {
                         MessageBox.Show(node.Label);

                         node.PropertyChanged += node_PropertyChanged; 
                         GraphGroupStyle style = GraphGroupStyle.Expanded;
                         MessageBox.Show(node.GetGroupStyle().ToString());
                         MessageBox.Show("Group style is supoosed to be set to Expanded");
                         node.SetGroupStyle(style);
                         //graphAutomation.Content.SetInvalidateVisual();
                         //this.InvalidateVisual();
                         MessageBox.Show(node.GetGroupStyle().ToString());
                         
                         
                         GraphObject tempNode = (GraphObject)node;
                        
                         System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<Microsoft.VisualStudio.GraphModel.GraphProperty, object>> properties = tempNode.Properties;
                         foreach (System.Collections.Generic.KeyValuePair<Microsoft.VisualStudio.GraphModel.GraphProperty, object> property in properties)
                         {
                             string temp = "Key: " + property.Key.ToString() + " Value :" + property.Value;

                             if (property.Key.ToString() == "Group")
                             {
                                 FieldInfo valueField = property.GetType().GetField("value", BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance);
                                 string nameOfField = valueField.Name;
                                 string groupState = property.Key + ", " + property.Value;

                                 MessageBox.Show("With Reflection " + valueField.GetValue(property).ToString());
                                 // valueField.SetValue(property, "Expanded");

                             }

                         }
                         

                             /*
                             node.CopyProperties
                             IEnumerable<GraphProperty> properties = node.PropertyKeys;
                             foreach (GraphProperty property in properties)
                             {
                                 property.ToString();
                                 property.

                             }
                              */
                         //}
                     }
                    
                     //object obj = (Microsoft.VisualBasic.GraphControl)window.Object;
                 }
                
            }
            //MessageBox.Show("There is " + openWindowCount.ToString() + " Active Windows and they are: " +
            //openWindowNames);

        }

        void node_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            MessageBox.Show(e.PropertyName);
            MessageBox.Show("hey");
           
        }
    }
}