using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Parser
{
    public partial class Form1 : Form
    {
        List<string> Tokens = null;
        List<string> TokensType = new List<string> { };
        private TreeView treeView;
        public Form1()
        {
            InitializeComponent();
            FeedBack.Text = "Please Choose the Token File Location\n";
            Draw_tree.Enabled = false;
            treeView = new TreeView();
            treeView.Dock = DockStyle.Fill;
            Controls.Add(treeView);
            redraw.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TokensLoc.Filter = "Text files (*.txt)|*.txt";
            TokensLoc.ShowDialog();
            Fileloc.Text = TokensLoc.FileName;
            FeedBack.Text = "";
            FeedBack.Text += "Token File Has Been Added Waiting To Process ...\n";
            read_tokens(Fileloc.Text);
            redraw.Enabled = true;
            button1.Enabled = false;
        }
        private void see_check()
        {
            if (tokenscheck.Checked)
            {
                tokenscheck.ForeColor = Color.Green;
                Draw_tree.Enabled = true;
            }
            else
            {
                tokenscheck.ForeColor = Color.Red;
                Draw_tree.Enabled = false;
            }
        }
        private void read_tokens(string file)
        {
            Tokens = new List<string> { };
            List<string> Tokens_list = new List<string> { };
            int lb = 0, rb = 0, lbb = 0, rbb = 0;
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 2)
                        {
                            string tokenType = parts[0].Trim();
                            string tokenValue = parts[1].Trim();
                            Tokens_list.Add(tokenType);
                            switch (tokenType)
                            {
                                case "FOR":
                                    FeedBack.Text += ("For token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "LEFTBRACKET":
                                    FeedBack.Text += ("Left Bracket token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "Terminal":
                                    FeedBack.Text += ("Terminal token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "WHILE":
                                    FeedBack.Text += ("WHILE token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "ID":
                                    FeedBack.Text += ("ID token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "EQUAL":
                                    FeedBack.Text += ("Equal token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "Digit":
                                    FeedBack.Text += ("Digit token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "SEMICOLONE":
                                    FeedBack.Text += ("Semicolon token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "LESS":
                                    FeedBack.Text += ("Less Than token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "MORE":
                                    FeedBack.Text += ("More Than token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "PLUS":
                                    FeedBack.Text += ("Plus token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "MINUS":
                                    FeedBack.Text += ("Minus token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "RIGHTBRACKET":
                                    FeedBack.Text += ("Right Bracket token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "LEFTBRACES":
                                    FeedBack.Text += ("Left Braces token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "RIGHTBRACES":
                                    FeedBack.Text += ("Right Braces token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                case "IF":
                                    FeedBack.Text += ("If token found with value: " + tokenValue + "\n");
                                    Tokens.Add(tokenValue);
                                    get_token_type(tokenType);
                                    tokenscheck.CheckState = CheckState.Checked;
                                    break;
                                default:
                                    FeedBack.Text += ("Invalid token type: " + tokenType + "\n");
                                    tokenscheck.CheckState = CheckState.Unchecked;
                                    break;
                            }

                        }
                        else
                        {
                            FeedBack.Text += ("Invalid line format: \n" + line);
                            tokenscheck.CheckState = CheckState.Unchecked;
                        }
                    }
                    
                    for(int i =0;i<Tokens_list.Count;i++)
                    {
                        if(Tokens_list[i].Contains("LEFTBRACKET"))
                        {
                            lb++;
                        }
                        if(Tokens_list[i].Contains("RIGHTBRACKET"))
                        {
                            rb++;
                        }
                        if (Tokens_list[i].Contains("LEFTBRACES"))
                        {
                            lbb++;
                        }
                        if (Tokens_list[i].Contains("RIGHTBRACES"))
                        {
                            rbb++;
                        }
                    }

                    if (lb < 2 || rb < 2 || lbb < 2|| rbb < 2)
                    {
                        if (lb < 2)
                        {
                            FeedBack.Text += ("Missing LEFTBRACKET: \n");
                            tokenscheck.CheckState = CheckState.Unchecked;
                        }
                        if (rb < 2)
                        {
                            FeedBack.Text += ("Missing RIGHTBRACKET: \n");
                            tokenscheck.CheckState = CheckState.Unchecked;
                        }
                        if (lbb < 2)
                        {
                            FeedBack.Text += ("Missing LEFTBRACES: \n");
                            tokenscheck.CheckState = CheckState.Unchecked;
                        }
                        if (rbb < 2)
                        {
                            FeedBack.Text += ("Missing RIGHTBRACES: \n");
                            tokenscheck.CheckState = CheckState.Unchecked;
                        }

                    }
                    else
                    {
                        FeedBack.Text += ("All Tokens are Read You Can Draw Tree Now ... \n");
                        see_check();
                    }
                }
            }
            catch (Exception ex)
            {
                FeedBack.Text += ("Error reading file: \n" + ex.Message);
                tokenscheck.CheckState = CheckState.Unchecked;
            }
        }
        private void get_token_type(string type)
        {
            TokensType.Add(type);
        }
        private void Draw_tree_Click(object sender, EventArgs e)
        {
            Draw_tree.Enabled = false;
            redraw.Enabled = true;
            FeedBack.Text += ("Drawing Tree.\n"); // Debugging statement

            ParseTree parseTree = new ParseTree(TokensType);
            parseTree.BuildTree(Tokens);

            FeedBack.Text += ("Tokens count: " + Tokens.Count + "\n"); // Debugging statement

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            parseTree.set_loc(saveFileDialog1.FileName.ToString());

            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(parseTree.ToTreeNode(parseTree.root));
            if(parseTree.check_tree())
            {
                FeedBack.Text += "Tree Successfuly Drawn\n";
            }else
            {
                
                FeedBack.Text += "Tree Not Completly Drawn Dueto " + parseTree.getreaseon() + "\n";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            redraw.Enabled = false;
            button1.Enabled = true;
            treeView1.Nodes.Clear();
            tokenscheck.CheckState = CheckState.Unchecked;
            FeedBack.Text = "Please Choose the Token File Location\n";
            Fileloc.Text = "";
            Tokens = null;
            see_check();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }
    }
}
    