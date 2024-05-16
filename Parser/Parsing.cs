using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Parser
{
    public class ParseTreeNode
    {
        public string Value { get; }
        public List<ParseTreeNode> Children { get; }

        public ParseTreeNode(string value)
        {
            Value = value;
            Children = new List<ParseTreeNode>();
        }

        public void AddChild(ParseTreeNode child)
        {
            Children.Add(child);
        }
    }
    public class ParseTree
    {
        public ParseTreeNode root;
        public List<string> tokentype = new List<string> { };

        public ParseTree(List<string> tokentypes)
        {
            tokentype = tokentypes;
            root = new ParseTreeNode("Stmt");
        }
        int index = 0;
        bool drawn = false;
        bool ifdrawn = false;
        bool fordrawn = false;
        bool whiledrawn = false;
        public string getreaseon()
        {
            if (!ifdrawn && fordrawn && whiledrawn)
            {
                return "Missing Operation In If Statment";
            }
            else if (ifdrawn && !fordrawn && whiledrawn)
            {
                return "Missing Operation In For Statment";
            }
            else if(ifdrawn && fordrawn && !whiledrawn)
            {
                return "Missing Operation In While";
            }
            else if (!ifdrawn && !fordrawn && whiledrawn)
            {
                return "Missing Operation In For Statment And If Statment";
            }else
            {
                return "Missing Operation In For Statment , If Statment and While Statment";
            }
        }
        public bool check_tree()
        {
            return drawn;
        }
        public void BuildTree(List<string> tokenList)
        {
            //Setting CFG
            List<string> isdigit = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Stack<ParseTreeNode> stack = new Stack<ParseTreeNode>();
            ParseTreeNode currentExpression = null;
            ParseTreeNode stmt = new ParseTreeNode("stmt");
            ParseTreeNode if_stmt = new ParseTreeNode("if_stmt");
            ParseTreeNode ifcondtion = new ParseTreeNode("cond");
            ParseTreeNode ifoperation = new ParseTreeNode("op");
            ParseTreeNode ifexp = new ParseTreeNode("exp");
            ParseTreeNode ifstmts = new ParseTreeNode("stmts");
            ParseTreeNode ifterm = new ParseTreeNode("term");
            ParseTreeNode iffactor = new ParseTreeNode("factor");
            ParseTreeNode stmtsElse = new ParseTreeNode("stmts");
            ParseTreeNode for_stmt = new ParseTreeNode("for_stmt");
            ParseTreeNode terminal = new ParseTreeNode("terminal");
            ParseTreeNode forcondtion = new ParseTreeNode("cond");
            ParseTreeNode foroperation = new ParseTreeNode("op");
            ParseTreeNode forstmts = new ParseTreeNode("stmts");
            ParseTreeNode forterm = new ParseTreeNode("term");
            ParseTreeNode forfactor = new ParseTreeNode("factor");
            ParseTreeNode forid = new ParseTreeNode("id");
            ParseTreeNode fora_stmt = new ParseTreeNode("a_stmt");
            ParseTreeNode while_stmt = new ParseTreeNode("while_stmt");

            for (int i = 0; i < tokenList.Count; i++)
            {
                if (i + 1 < tokenList.Count && tokenList[i + 1] == "else")
                {
                    i++;
                    if_stmt.AddChild(new ParseTreeNode("else"));
                    if_stmt.AddChild(new ParseTreeNode("{"));
                    if_stmt.AddChild(stmtsElse);
                    if_stmt.AddChild(new ParseTreeNode("}"));
                }

                switch (tokentype[i])
                {
                    case "IF":
                        index = i;

                        stack.Push(if_stmt);

                        root.AddChild(if_stmt);

                        index++;
                        if_stmt.AddChild(new ParseTreeNode("if"));

                        index++;
                        if_stmt.AddChild(new ParseTreeNode("("));

                        if_stmt.AddChild(ifcondtion);

                        ParseTreeNode idss = new ParseTreeNode("id");
                        ifcondtion.AddChild(idss);
                        idss.AddChild(new ParseTreeNode(tokenList[index]));

                        index++;
                        if (tokentype[index] == "MORE")// index = 25
                        {
                            ParseTreeNode ops = new ParseTreeNode("op");
                            ifcondtion.AddChild(ops);
                            ops.AddChild(new ParseTreeNode(">"));
                        }
                        else if (tokentype[index] == "LESS")
                        {
                            ParseTreeNode ops = new ParseTreeNode("op");
                            ifcondtion.AddChild(ops);
                            ops.AddChild(new ParseTreeNode("<"));
                        }
                        else if (tokentype[index] == "EQUAL")
                        {
                            ParseTreeNode ops = new ParseTreeNode("op");
                            ifcondtion.AddChild(ops);
                            ops.AddChild(new ParseTreeNode("="));
                        }
                        else
                        {
                            ParseTreeNode ops = new ParseTreeNode("op");
                            ifcondtion.AddChild(ops);
                            ops.AddChild(new ParseTreeNode("Missing Op"));
                            MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            drawn = false;
                            break;
                        }
                        ifcondtion.AddChild(ifexp);
                        ifexp.AddChild(ifterm);
                        ifterm.AddChild(iffactor);

                        index++;
                        if (tokentype[index] == "ID")//index = 26
                        {
                            ParseTreeNode ids = new ParseTreeNode("id");
                            iffactor.AddChild(ids);
                            ids.AddChild(new ParseTreeNode(tokenList[index]));
                        }
                        else
                        {
                            ParseTreeNode digits = new ParseTreeNode("digit");
                            iffactor.AddChild(digits);
                            digits.AddChild(new ParseTreeNode(tokenList[index]));
                        }

                        index++;
                        if_stmt.AddChild(new ParseTreeNode(")"));

                        index++;
                        if_stmt.AddChild(new ParseTreeNode("{"));

                        index++;
                        if_stmt.AddChild(ifstmts);
                        ParseTreeNode sexps = new ParseTreeNode("exp");
                        ParseTreeNode sterm = new ParseTreeNode("term");
                        ParseTreeNode sfact = new ParseTreeNode("factor");
                        ParseTreeNode sids = new ParseTreeNode("id");

                        ifstmts.AddChild(sexps);
                        sexps.AddChild(sterm);
                        sterm.AddChild(sfact);
                        sfact.AddChild(sids);
                        sids.AddChild(new ParseTreeNode(tokenList[index]));
                        index++;
                        if (tokentype[index] == "PLUS")// index = 30
                        {
                            ParseTreeNode if_new_ops = new ParseTreeNode("op");
                            ifstmts.AddChild(if_new_ops);
                            if_new_ops.AddChild(new ParseTreeNode("+"));
                            index++;
                        }
                        else if (tokentype[index] == "MINUS")
                        {
                            ParseTreeNode if_new_ops = new ParseTreeNode("op");
                            ifstmts.AddChild(if_new_ops);
                            if_new_ops.AddChild(new ParseTreeNode("-"));
                            index++;
                        }
                        else if (tokentype[index] == "MULTIPLY")
                        {
                            ParseTreeNode if_new_ops = new ParseTreeNode("op");
                            ifstmts.AddChild(if_new_ops);
                            if_new_ops.AddChild(new ParseTreeNode("*"));
                            index++;
                        }
                        else if (tokentype[index] == "DIVIDE")
                        {
                            ParseTreeNode if_new_ops = new ParseTreeNode("op");
                            ifstmts.AddChild(if_new_ops);
                            if_new_ops.AddChild(new ParseTreeNode("/"));
                            index++;
                        }
                        else if (tokentype[index] == "EQUAL")
                        {
                            ifstmts.AddChild(new ParseTreeNode("="));
                            index++;
                        }
                        else if (tokentype[index] == "ID")
                        {
                            ParseTreeNode if_new_exp_new = new ParseTreeNode("exp");
                            ifstmts.AddChild(if_new_exp_new);
                            ParseTreeNode if_new_term_new = new ParseTreeNode("term");
                            if_new_exp_new.AddChild(if_new_term_new);
                            ParseTreeNode if_new_factor_new = new ParseTreeNode("factor");
                            if_new_term_new.AddChild(if_new_factor_new);
                            ParseTreeNode if_new_id_new = new ParseTreeNode("id");
                            if_new_factor_new.AddChild(if_new_id_new);
                            if_new_id_new.AddChild(new ParseTreeNode(tokenList[index]));
                            index++;
                        }
                        else if (tokentype[index] == "SEMICOLONE")
                        {
                            ifstmts.AddChild(new ParseTreeNode(";"));
                            index++;
                        }
                        
                        else
                        {

                                ParseTreeNode if_new_ops = new ParseTreeNode("op");
                                ifstmts.AddChild(if_new_ops);
                                if_new_ops.AddChild(new ParseTreeNode("Missing Op"));
                            MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ifdrawn = false;
                                drawn = false;
                                break;

                        }
                        if (tokentype[index] == "PLUS")// index = 30
                        {
                            ifstmts.AddChild(ifoperation);
                            ifoperation.AddChild(new ParseTreeNode("+"));
                            index++;
                        }
                        else if (tokentype[index] == "MINUS")
                        {
                            ifstmts.AddChild(ifoperation);
                            ifoperation.AddChild(new ParseTreeNode("-"));
                            index++;
                        }
                        else if (tokentype[index] == "MULTIPLY")
                        {
                            ifstmts.AddChild(ifoperation);
                            ifoperation.AddChild(new ParseTreeNode("*"));
                            index++;
                        }
                        else if (tokentype[index] == "DIVIDE")
                        {
                            ifstmts.AddChild(ifoperation);
                            ifoperation.AddChild(new ParseTreeNode("/"));
                            index++;
                        }
                        else
                        {

                            if (tokenList[index] == isdigit.Any().ToString() && tokentype[index] == "Digit")
                            {
                                ParseTreeNode new_exp_if = new ParseTreeNode("exp");
                                ParseTreeNode new_term_if = new ParseTreeNode("term");
                                ParseTreeNode new_fact_if = new ParseTreeNode("factor");
                                ParseTreeNode new_digit_if = new ParseTreeNode("digit");
                                ifstmts.AddChild(new_exp_if);
                                new_exp_if.AddChild(new_term_if);
                                new_term_if.AddChild(new_fact_if);
                                new_fact_if.AddChild(new_digit_if);
                                new_digit_if.AddChild(new ParseTreeNode(tokenList[index]));
                                index++;
                            }
                            else if(tokenList[index] != isdigit.Any().ToString() && tokentype[index] == "ID")
                            {
                                ParseTreeNode new_exp_if = new ParseTreeNode("exp");
                                ParseTreeNode new_term_if = new ParseTreeNode("term");
                                ParseTreeNode new_fact_if = new ParseTreeNode("factor");
                                ParseTreeNode new_id_if = new ParseTreeNode("id");
                                ifstmts.AddChild(new_exp_if);
                                new_exp_if.AddChild(new_term_if);
                                new_term_if.AddChild(new_fact_if);
                                new_fact_if.AddChild(new_id_if);
                                new_id_if.AddChild(new ParseTreeNode(tokenList[index]));
                                index++;
                            }
                            if (tokentype[index] == "PLUS")// index = 30
                            {
                                ifstmts.AddChild(new ParseTreeNode("+"));
                                index++;
                            }
                            else if (tokentype[index] == "MINUS")
                            {
                                ifstmts.AddChild(new ParseTreeNode("-"));
                                index++;
                            }
                            else if (tokentype[index] == "MULTIPLY")
                            {
                                ifstmts.AddChild(new ParseTreeNode("*"));
                                index++;
                            }
                            else if (tokentype[index] == "DIVIDE")
                            {
                                ifstmts.AddChild(new ParseTreeNode("/"));
                                index++;
                            }
                            else
                            {
                                ifstmts.AddChild(ifoperation);
                                ifoperation.AddChild(new ParseTreeNode("Missing Op"));
                                MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ifdrawn = false;
                                drawn = false;
                                break;
                            }
                        }
                        if (tokentype[index] == "Digit")
                        {
                            ParseTreeNode new_exp_if = new ParseTreeNode("exp");
                            ParseTreeNode new_term_if = new ParseTreeNode("term");
                            ParseTreeNode new_fact_if = new ParseTreeNode("factor");
                            ParseTreeNode new_digit_if = new ParseTreeNode("digit");
                            ifstmts.AddChild(new_exp_if);
                            new_exp_if.AddChild(new_term_if);
                            new_term_if.AddChild(new_fact_if);
                            new_fact_if.AddChild(new_digit_if);
                            new_digit_if.AddChild(new ParseTreeNode(tokenList[index]));
                            index++;
                        }
                        else if (tokentype[index] == "ID")
                        {
                            ParseTreeNode new_exp_if = new ParseTreeNode("exp");
                            ParseTreeNode new_term_if = new ParseTreeNode("term");
                            ParseTreeNode new_fact_if = new ParseTreeNode("factor");
                            ParseTreeNode new_id_if = new ParseTreeNode("id");
                            ifstmts.AddChild(new_exp_if);
                            new_exp_if.AddChild(new_term_if);
                            new_term_if.AddChild(new_fact_if);
                            new_fact_if.AddChild(new_id_if);
                            new_id_if.AddChild(new ParseTreeNode(tokenList[index]));
                            index++;

                        }
                        if (tokentype[index] == "SEMICOLONE")
                        {
                            ifstmts.AddChild(new ParseTreeNode(";"));
                        }
                        if_stmt.AddChild(new ParseTreeNode("}"));
                        ifdrawn = true;
                        //end of if statement
                        break;

                    case "FOR":

                        root.AddChild(for_stmt);

                        stack.Push(for_stmt);

                        index = i;
                        for_stmt.AddChild(new ParseTreeNode("for"));

                        index++;
                        for_stmt.AddChild(new ParseTreeNode("("));

                        index++;
                        for_stmt.AddChild(terminal);
                        terminal.AddChild(new ParseTreeNode(tokenList[index]));
                        for_stmt.AddChild(fora_stmt);

                        index++;
                        ParseTreeNode fids = new ParseTreeNode("id");
                        fora_stmt.AddChild(fids);
                        fids.AddChild(new ParseTreeNode(tokenList[index]));

                        fora_stmt.AddChild(new ParseTreeNode("="));
                        ParseTreeNode frexp = new ParseTreeNode("exp");
                        fora_stmt.AddChild(frexp);
                        frexp.AddChild(forterm);
                        forterm.AddChild(forfactor);

                        index++;
                        index++;
                        if (tokentype[index] == "ID")//index = 5
                        {
                            ParseTreeNode fidss = new ParseTreeNode("id");
                            forfactor.AddChild(fidss);
                            fidss.AddChild(new ParseTreeNode(tokenList[index]));
                        }
                        else
                        {
                            ParseTreeNode fdigits = new ParseTreeNode("digit");
                            forfactor.AddChild(fdigits);
                            fdigits.AddChild(new ParseTreeNode(tokenList[index]));
                        }

                        fora_stmt.AddChild(new ParseTreeNode(";"));

                        index++; //index = 6
                        for_stmt.AddChild(forcondtion);
                        ParseTreeNode for_newid = new ParseTreeNode("id");
                        forcondtion.AddChild(for_newid);

                        index++;
                        for_newid.AddChild(new ParseTreeNode(tokenList[index]));

                        index++;
                        forcondtion.AddChild(foroperation);
                        if (tokentype[index] == "MORE")// index = 8
                        {
                            foroperation.AddChild(new ParseTreeNode(">"));
                        }
                        else if (tokentype[index] == "LESS")
                        {

                            foroperation.AddChild(new ParseTreeNode("<"));
                        }
                        else if (tokentype[index] == "EQUAL")
                        {
                            foroperation.AddChild(new ParseTreeNode("="));
                        }
                        else
                        {
                            foroperation.AddChild(new ParseTreeNode("Missing op"));
                            MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fordrawn = false;
                            drawn = false;
                            break;
                        }

                        ParseTreeNode for_newex = new ParseTreeNode("exp");
                        forcondtion.AddChild(for_newex);

                        ParseTreeNode for_newterm = new ParseTreeNode("term");
                        for_newex.AddChild(for_newterm);

                        ParseTreeNode for_newfact = new ParseTreeNode("factor");
                        for_newterm.AddChild(for_newfact);

                        index++;
                        if (tokentype[index] == "ID")//index = 9
                        {
                            ParseTreeNode for_newdig = new ParseTreeNode("id");
                            for_newfact.AddChild(for_newdig);
                            for_newdig.AddChild(new ParseTreeNode(tokenList[index]));
                        }
                        else
                        {
                            ParseTreeNode for_newdig = new ParseTreeNode("digit");
                            for_newfact.AddChild(for_newdig);
                            for_newdig.AddChild(new ParseTreeNode(tokenList[index]));
                        }

                        index++; //index = 10
                        for_stmt.AddChild(new ParseTreeNode(";"));

                        index++; //index = 11
                        for_stmt.AddChild(forid);
                        forid.AddChild(new ParseTreeNode(tokenList[index]));

                        ParseTreeNode for_newop = new ParseTreeNode("op");
                        for_stmt.AddChild(for_newop);
                        index++;

                        for_newop.AddChild(new ParseTreeNode(tokenList[index]));

                        index++;
                        for_stmt.AddChild(for_newop);

                        index++;
                        for_stmt.AddChild(new ParseTreeNode(")"));

                        index++;
                        for_stmt.AddChild(new ParseTreeNode("{"));

                        index++;
                        for_stmt.AddChild(forstmts);

                        ParseTreeNode for_newastmt = new ParseTreeNode("a_stmt");
                        forstmts.AddChild(for_newastmt);

                        ParseTreeNode for_newid_as = new ParseTreeNode("id");
                        for_newastmt.AddChild(for_newid_as);
                        for_newid_as.AddChild(new ParseTreeNode(tokenList[index]));

                        index++;
                        for_newastmt.AddChild(new ParseTreeNode("="));

                        index++;
                        ParseTreeNode for_new_exp_astmt = new ParseTreeNode("exp");
                        for_newastmt.AddChild(for_new_exp_astmt);

                        ParseTreeNode for_new_term_astmt = new ParseTreeNode("term");
                        for_new_exp_astmt.AddChild(for_new_term_astmt);

                        ParseTreeNode for_new_factor_astmt = new ParseTreeNode("factor");
                        for_new_term_astmt.AddChild(for_new_factor_astmt);

                        if (tokentype[index] == "Digit")//index = 9
                        {
                            ParseTreeNode for_newdig = new ParseTreeNode("digit");
                            for_new_factor_astmt.AddChild(for_newdig);
                            for_newdig.AddChild(new ParseTreeNode(tokenList[index]));
                        }
                        else
                        {
                            ParseTreeNode for_newdig = new ParseTreeNode("id");
                            for_new_factor_astmt.AddChild(for_newdig);
                            for_newdig.AddChild(new ParseTreeNode(tokenList[index]));
                        }
                        index++;
                        if(tokentype[index] == "SEMICOLONE")
                        {
                            forstmts.AddChild(new ParseTreeNode(";"));
                        }
                        for_stmt.AddChild(new ParseTreeNode("}"));
                        fordrawn = true;
                        //end of for statement
                        break;
                    case "WHILE": //while(x == 5){x = x - 1;}
                        int new_index = i;
                        index = i;//36
                        index++;

                        root.AddChild(while_stmt);

                        stack.Push(while_stmt);

                        if (tokentype[index] != "LEFTBRACKET")
                        {
                            while_stmt.AddChild(new ParseTreeNode("Missing Left Bracket"));
                            whiledrawn = false;
                            drawn = false;
                            getreaseon();
                            break;
                        }else
                        {
                            while_stmt.AddChild(new ParseTreeNode("("));
                            index++;//38
                            if (tokentype[index] == "ID")
                            {
                                ParseTreeNode while_id = new ParseTreeNode("id");
                                ParseTreeNode while_cond = new ParseTreeNode("cond");
                                while_stmt.AddChild(while_cond);
                                
                                while_cond.AddChild(while_id);
                                while_id.AddChild(new ParseTreeNode(tokenList[index]));


                                if (tokentype[new_index + 3] == "EQUAL" && tokentype[new_index + 4] == "EQUAL")
                                {
                                    ParseTreeNode while_op1 = new ParseTreeNode("op");
                                    while_cond.AddChild(while_op1);
                                    while_op1.AddChild(new ParseTreeNode(tokenList[index + 2]));
                                    ParseTreeNode while_op2 = new ParseTreeNode("op");
                                    while_cond.AddChild(while_op2);
                                    while_op2.AddChild(new ParseTreeNode(tokenList[index + 2]));
                                    index++;
                                }
                                else
                                {
                                    ParseTreeNode while_op1 = new ParseTreeNode("op");
                                    while_cond.AddChild(while_op1);
                                    while_op1.AddChild(new ParseTreeNode(tokenList[new_index + 3]));
                                    index++;
                                }
                                ParseTreeNode while_exp = new ParseTreeNode("exp");
                                while_cond.AddChild(while_exp);
                                index++;//40
                                if (tokentype[index] == "ID")
                                {
                                    ParseTreeNode while_term = new ParseTreeNode("term");
                                    while_exp.AddChild(while_term);
                                    ParseTreeNode while_fact = new ParseTreeNode("factor");
                                    while_term.AddChild(while_fact);
                                    ParseTreeNode while_id1 = new ParseTreeNode("id");
                                    while_fact.AddChild(while_id1);
                                    while_id1.AddChild(new ParseTreeNode(tokenList[index]));
                                    index++;
                                }
                                else
                                {
                                    ParseTreeNode while_term = new ParseTreeNode("term");
                                    while_exp.AddChild(while_term);
                                    ParseTreeNode while_fact = new ParseTreeNode("factor");
                                    while_term.AddChild(while_fact);
                                    ParseTreeNode while_digit = new ParseTreeNode("digit");
                                    while_fact.AddChild(while_digit);
                                    while_digit.AddChild(new ParseTreeNode(tokenList[index]));
                                    index++;
                                }
                                if (tokentype[index] != "RIGHTBRACKET")
                                {
                                    while_stmt.AddChild(new ParseTreeNode("Missing Right Bracket"));
                                    MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    drawn = false;
                                    getreaseon();
                                    break;
                                }
                                else
                                {
                                    while_stmt.AddChild(new ParseTreeNode(")"));
                                    index++; //42
                                }
                            }
                            if (tokentype[index] != "LEFTBRACES")
                            {
                                while_stmt.AddChild(new ParseTreeNode("Missing Left Braces"));
                                MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                drawn = false;
                                getreaseon();
                                break;
                            }
                            else
                            {
                                while_stmt.AddChild(new ParseTreeNode("{"));
                                index++;//43
                                ParseTreeNode while_stmts = new ParseTreeNode("stmts");
                                while_stmt.AddChild(while_stmts);
                                if(tokentype[index] == "ID" && tokentype[index + 1] == "PLUS")
                                {
                                    ParseTreeNode while_ids1 = new ParseTreeNode("id");
                                    while_ids1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_ids1);

                                    index++; //44

                                    ParseTreeNode while_operation1 = new ParseTreeNode("op");
                                    while_operation1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_operation1);

                                    index++;//45
                                    if (tokentype[index] == "PLUS")
                                    {

                                        ParseTreeNode while_operation2 = new ParseTreeNode("op");
                                        while_operation2.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation2);
                                        index++;
                                    }
                                    else if (tokentype[index] == "EQUAL")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }
                                    else
                                    {
                                        while_stmts.AddChild(new ParseTreeNode("Missing Operation"));
                                        MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        whiledrawn = false;
                                        drawn = false;
                                        getreaseon();
                                        break;
                                    }
                                }
                                else if(tokentype[index] == "ID" && tokentype[index + 1] == "EQUAL")
                                {
                                    ParseTreeNode while_ids1 = new ParseTreeNode("id");
                                    while_ids1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_ids1);

                                    index++; //44

                                    ParseTreeNode while_operation1 = new ParseTreeNode("op");
                                    while_operation1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_operation1);

                                    index++;//45
                                    if (tokentype[index] == "EQUAL")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }
                                    else
                                    {
                                        while_stmts.AddChild(new ParseTreeNode("Missing Operation"));
                                        MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        drawn = false;
                                        getreaseon();
                                        break;
                                    }
                                }
                                else if(tokentype[index] == "ID" && tokentype[index + 1] == "MINUS")
                                {
                                    ParseTreeNode while_ids1 = new ParseTreeNode("id");
                                    while_ids1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_ids1);

                                    index++; //44

                                    ParseTreeNode while_operation1 = new ParseTreeNode("op");
                                    while_operation1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_operation1);

                                    index++;//45
                                    if (tokentype[index] == "MINUS")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }else if (tokentype[index] == "EQUAL")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }
                                    else
                                    {
                                        while_stmts.AddChild(new ParseTreeNode("Missing Operation"));
                                        MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        drawn = false;
                                        break;
                                    }
                                }
                                else if (tokentype[index] == "ID" && tokentype[index + 1] == "DIVIDE")
                                {
                                    ParseTreeNode while_ids1 = new ParseTreeNode("id");
                                    while_ids1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_ids1);

                                    index++; //44

                                    ParseTreeNode while_operation1 = new ParseTreeNode("op");
                                    while_operation1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_operation1);

                                    index++;//45
                                    
                                    if (tokentype[index] == "EQUAL")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }
                                    else
                                    {
                                        while_stmts.AddChild(new ParseTreeNode("Missing Operation"));
                                        MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        drawn = false;
                                        break;
                                    }
                                }
                                else if(tokentype[index] == "ID" && tokentype[index + 1] == "MULTIPLY")
                                {
                                    ParseTreeNode while_ids1 = new ParseTreeNode("id");
                                    while_ids1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_ids1);

                                    index++; //44

                                    ParseTreeNode while_operation1 = new ParseTreeNode("op");
                                    while_operation1.AddChild(new ParseTreeNode(tokenList[index]));
                                    while_stmts.AddChild(while_operation1);

                                    index++;//45
                                    if (tokentype[index] == "EQUAL")
                                    {
                                        ParseTreeNode while_operation3 = new ParseTreeNode("op");
                                        while_operation3.AddChild(new ParseTreeNode(tokenList[index]));
                                        while_stmts.AddChild(while_operation3);
                                        index++;
                                    }
                                    else
                                    {
                                        while_stmts.AddChild(new ParseTreeNode("Missing Operation"));
                                        MessageBox.Show("Could Not Draw Tree Dueto: " + getreaseon(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        drawn = false;
                                        break;
                                    }
                                }
                                if(tokentype[index] == "ID" || tokentype[index] == "Digit")
                                {
                                   if(tokentype[index] == "ID")
                                    {
                                        ParseTreeNode while_exp12 = new ParseTreeNode("exp");
                                        ParseTreeNode while_term21 = new ParseTreeNode("term");
                                        ParseTreeNode while_fact12 = new ParseTreeNode("factor");
                                        ParseTreeNode while_id123 = new ParseTreeNode("id");
                                        while_stmts.AddChild(while_exp12);
                                        while_exp12.AddChild(while_term21);
                                        while_term21.AddChild(while_fact12);
                                        while_fact12.AddChild(while_id123);
                                        while_id123.AddChild(new ParseTreeNode(tokenList[index]));
                                    }
                                    else
                                    {
                                        ParseTreeNode while_exp12 = new ParseTreeNode("exp");
                                        ParseTreeNode while_term21 = new ParseTreeNode("term");
                                        ParseTreeNode while_fact12 = new ParseTreeNode("factor");
                                        ParseTreeNode while_digit123 = new ParseTreeNode("digit");
                                        while_stmts.AddChild(while_exp12);
                                        while_exp12.AddChild(while_term21);
                                        while_term21.AddChild(while_fact12);
                                        while_fact12.AddChild(while_digit123);
                                        while_digit123.AddChild(new ParseTreeNode(tokenList[index]));
                                    }
                                    index++;
                                }
                                else if (tokentype[index] == "SEMICOLONE")
                                {
                                    while_stmts.AddChild(new ParseTreeNode(";"));
                                    index++;
                                }
                               
                               if (tokentype[index] == "RIGHTBRACES")
                               {

                                        while_stmt.AddChild(new ParseTreeNode("}"));
                                        fordrawn = true;
                               }

                                else
                                {
                                    while_stmt.AddChild(new ParseTreeNode("Missing Right Braces"));
                                    drawn = false;
                                    whiledrawn = false;
                                    MessageBox.Show("Could Not Draw Tree Dueto: "+getreaseon(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                    break;
                                }

                            }
                        }

                        break;
                    default:
                        break;
                };
            }
            drawn = true;
        }
        public TreeNode ToTreeNode(ParseTreeNode node)
        {
            TreeNode treeNode = new TreeNode(node.Value);
            foreach (var child in node.Children)
            {
                treeNode.Nodes.Add(ToTreeNode(child));
            }
            create_target_file(treeNode);
            return treeNode;
        }
        public void create_target_file(TreeNode rootNode)
        {
            string targetpath = "D://Compiler Project//Target.txt";
            try
            {
                using (FileStream target = new FileStream(targetpath, FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(target))
                {
                    WriteTreeNodeToFile(rootNode, writer, 0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred while creating Target.txt: " + e.Message);
            }
        }
        private void WriteTreeNodeToFile(TreeNode node, StreamWriter writer, int level)
        {
            writer.Write(new string('\t', level));

            writer.WriteLine(node.Text);

            foreach (TreeNode childNode in node.Nodes)
            {
                WriteTreeNodeToFile(childNode, writer, level + 1);
            }
        }
    }
}

