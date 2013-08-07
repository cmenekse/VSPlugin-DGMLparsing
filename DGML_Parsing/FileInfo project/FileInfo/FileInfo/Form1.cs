using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FileInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            typeSelectionBox.Items.Add("Assembly");
            typeSelectionBox.Items.Add("Class");
            typeSelectionBox.Items.Add("Namespace");
        }

        public string rawTextFile;

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Windows 7\Documents\Visual Studio 2012\Projects\Parser\Parser\bin\Debug";
            dialog.ShowDialog();
            string filePath = dialog.FileName;
            textBox1.Text = filePath;
        }


        public bool importFile(string filePath)
        {
            //Check Whether File exists
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
                rawTextFile = File.ReadAllText(filePath);
                return true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
        }

        private void Press_Click(object sender, EventArgs e)
        {

            SortedSet<string> set = new SortedSet<string>();
            int Count = 0;
            if (importFile(textBox1.Text) == true)
            {

                rawTextFile = removeWhiteSpaceMethod(rawTextFile);
                XDocument dgmlDoc = XDocument.Parse(rawTextFile);
                XElement root = StripNamespaces(dgmlDoc.Root);
                XElement Aliases = root.Element("IdentifierAliases");
                string newTextFile = "";
                IEnumerable<XElement> singleAliases = Aliases.Descendants("Alias");
                IEnumerable<XElement> nodesInTheFile = root.Element("Nodes").Descendants("Node");
                Boolean[] aliasMatchedOrNot;
                aliasMatchedOrNot = new Boolean[3370];
                string[] aliasIdStr;
                aliasIdStr = new string[3370];
                string[] labels;
                labels = new string[3370];
                int[] mx;
                mx = new int[3370];
                int count = 0;

                foreach (XElement node in nodesInTheFile)
                {
                    count++;
                    bool found = false;
                    string labelToSearch = node.Attribute("Label").Value;
                    foreach (XElement alias in singleAliases)
                    {
                        if (alias.Attribute("Id") != null)
                        {
                            if (alias.Attribute("Id").Value.Contains(labelToSearch))
                            {
                                found = true;
                            }
                        }
                    }
                    if (found == false)
                    {
                        
                        richTextBox1.AppendText(Environment.NewLine + node.Attribute("Id").Value);
                        textBox1.Text = count.ToString();
                    }
                }
            }
        }

        public static string removeWhiteSpaceMethod(string str)
        {
            System.Console.WriteLine("it is the remove white space1  is running ");
            DateTime Before = DateTime.Now;
            string asAscii = Encoding.ASCII.GetString(
            Encoding.Convert(
                Encoding.UTF8,
                Encoding.GetEncoding(
                    Encoding.ASCII.EncodingName,
                    new EncoderReplacementFallback(string.Empty),
                    new DecoderExceptionFallback()
                    ),
                Encoding.UTF8.GetBytes(str)
            )
        );
            DateTime After = DateTime.Now;
            TimeSpan difference = After - Before;
            System.Console.WriteLine(difference.Milliseconds + "  miliseconds passed");
            //System.Console.WriteLine("it is done ");
            return asAscii;
        }



        private static XElement StripNamespaces(XElement rootElement)
        {
            foreach (var element in rootElement.DescendantsAndSelf())
            {
                // update element name if a namespace is available
                if (element.Name.Namespace != XNamespace.None)
                {
                    element.Name = XNamespace.None.GetName(element.Name.LocalName);
                }

                // check if the element contains attributes with defined namespaces (ignore xml and empty namespaces)
                bool hasDefinedNamespaces = element.Attributes().Any(attribute => attribute.IsNamespaceDeclaration ||
                        (attribute.Name.Namespace != XNamespace.None && attribute.Name.Namespace != XNamespace.Xml));

                if (hasDefinedNamespaces)
                {
                    // ignore attributes with a namespace declaration
                    // strip namespace from attributes with defined namespaces, ignore xml / empty namespaces
                    // xml namespace is ignored to retain the space preserve attribute
                    var attributes = element.Attributes()
                                            .Where(attribute => !attribute.IsNamespaceDeclaration)
                                            .Select(attribute =>
                                                (attribute.Name.Namespace != XNamespace.None && attribute.Name.Namespace != XNamespace.Xml) ?
                                                    new XAttribute(XNamespace.None.GetName(attribute.Name.LocalName), attribute.Value) :
                                                    attribute
                                            );

                    // replace with attributes result
                    element.ReplaceAttributes(attributes);
                }
            }
            return rootElement;
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (importFile(textBox1.Text) == true)
            {

                int count = 0;
                XDocument dgmlDoc = XDocument.Parse(rawTextFile);
                XElement root = StripNamespaces(dgmlDoc.Root);
                XElement nodes = root.Element("Nodes");
                IEnumerable<XElement> singleNodes = nodes.Descendants("Node");
                foreach (XElement singleNode in singleNodes)
                {
                    if (singleNode.Attribute("Category").Value == "CodeSchema_" + typeSelectionBox.SelectedItem.ToString())
                    {
                        count++;
                        richTextBox1.Text += Environment.NewLine + singleNode.Attribute("Id").Value + " )" + singleNode.Attribute("Label").Value;
                    }
                }
                textBox1.Text = count.ToString();
            }

        }
    }
}

/*HashSet<string> hash = new HashSet<string>();
            
          int count = 0;
          if (importFile(textBox1.Text) == true)
          {
              string pattern=@".*?Category:(.*)";
              string[] lines = rawTextFile.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
               
              foreach (string line in lines)
              {
                  Match match=Regex.Match(line,pattern);
                  string str = match.Groups[1].ToString()+Environment.NewLine;
                  if (!hash.Contains(str))
                  {
                      hash.Add(str);
                      richTextBox1.AppendText(str);
                      count++;
                  }
                    
                    
                    
                    
              }
              textBox2.Text = count.ToString();
          }*/
/*
  foreach (XElement node in nodesInTheFile)
  {

      if (node.Attribute("Uri") == null)
      {
          string nodeLabel = node.Attribute("Label").Value;

          foreach (XElement alias in singleAliases)
          {
                            
              if (alias.Attribute("Id") != null)
              {

                  if (print == true)
                  {
                      aliasIdStr[Convert.ToInt32(alias.Attribute("n").Value)] = alias.Attribute("Id").Value;
                                    
                  }
                                
                  string id = alias.Attribute("Id").Value;
                  if(id.Contains (nodeLabel))
                  {
                      aliasIds[Convert.ToInt32(alias.Attribute("n").Value)]=true;
                      if (nodeLabel.Length > mx[Convert.ToInt32(alias.Attribute("n").Value)]&&nodeLabel!="Parameters")
                      {
                          contains[Convert.ToInt32(alias.Attribute("n").Value)] = nodeLabel;
                          mx[Convert.ToInt32(alias.Attribute("n").Value)] = nodeLabel.Length;
                      }
                  }
                               
              }
          }



                        

      }

      print = false;

  }
  */



/*
foreach (XElement singleAlias in singleAliases)
{
    string searchedValue = "@" + singleAlias.Attribute("n").Value;

    IEnumerable<XElement> nodes =
    from node in nodesInTheFile
    where node.Attribute("Id").Value == searchedValue
    select node;

    int b = 9;
    if (nodes.Count() == 0)
    {
        count++;
                        
        if (singleAlias.Attribute("Id") != null)
        {
            string id=singleAlias.Attribute("Id").Value;
            if ((id.Contains("ParentType") || id.Contains("ArrayRank") || id.Contains("ParameterIdentifier") ||
    id.Contains("ParamKind") || id.Contains("GenericArguments") || id.Contains("GenericParameterCount")&&!id.Contains('@')))
            {
                richTextBox1.AppendText(Environment.NewLine + singleAlias.Attribute("n").Value + ")" + singleAlias.Attribute("Id").Value);
                //rawTextFile=rawTextFile.Replace("@" + singleAlias.Attribute("n").Value+ " ", "HEY!");
                //rawTextFile = rawTextFile.Replace("@" + singleAlias.Attribute("n").Value +")", "HEY!");
            }
            else
            {
                               
            }
                            
                            
        }
                        
    }
    else
    {
        set.Add(searchedValue);
                        
    }
}
*/