#include <iostream>
#include <string>
#include <cctype>
#include <vector>
#include <fstream>

using namespace std;

// Token types
enum class TokenType {
    IF,
    DO,
    WHILE,
    EQUAL,
    PLUS,
    MINUS,
    MULTIPLY,
    DIVIDE,
    ELSE,
    FOR,
    Terminal,
    ID,
    Digit,
    FLOAT,
    DOUBLE,
    STRING,
    SYMBOL,
    LESS,
    MORE,
    LEFTBRACKET,
    RIGHTBRACKET,
    LEFTBRACES,
    RIGHTBRACES,
    SEMICOLONE,
    NoneTerminal
};

// Token structure
struct Token {
    TokenType type;
    string value;
};
class scanner{
private:
// Function to check if a string is a keyword
bool isKeyword(const string& str) {
    return (str == "if" || str == "else" || str == "while" || str == "for" || str == "int" || str == "float" || str == "string" || str == "double" || str == "null" || str == "do");
}
bool isID(const string& str) {
    // Check if the string is empty
    if (str.empty())
        return false;

    // Check if the string length is 1
    if (str.length() != 1)
        return false;

    char c = str[0];
    // Check if the character is an alphabet
    return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
}

// Function to scan input code and generate tokens
vector<Token> scan(const string& input) {
    vector<Token> tokens;
    string currentToken = "";

    for (char c : input) {
        if (isspace(c)) {
            if (!currentToken.empty()) {
                Token token;
                if (isdigit(currentToken[0])) {
                    if (currentToken.find('.') != string::npos) {
                        token.type = TokenType::FLOAT;
                    } else {
                        token.type = TokenType::Digit;
                    }
                } else if (isKeyword(currentToken)) {
                    token.type = getTokenType(currentToken);
                } else {
                    if(isID(currentToken)) {
                        token.type = TokenType::ID;
                    } else {
                        token.type = TokenType::NoneTerminal;
                    }
                }
                token.value = currentToken;
                tokens.push_back(token);
                currentToken = "";
            }
        } else if (isalpha(c) || c == '_') {
            currentToken += c;
        } else if (isdigit(c) || c == '.') {
            currentToken += c;
        } else {
            if (!currentToken.empty()) {
                Token token;
                if (isdigit(currentToken[0])) {
                    if (currentToken.find('.') != string::npos) {
                        token.type = TokenType::FLOAT;
                    } else {
                        token.type = TokenType::Digit;
                    }
                } else if (isKeyword(currentToken)) {
                    token.type = getTokenType(currentToken);
                } else {
                    if(isID(currentToken)) {
                        token.type = TokenType::ID;
                    } else {
                        token.type = TokenType::NoneTerminal;
                    }
                }
                token.value = currentToken;
                tokens.push_back(token);
                currentToken = "";
            }
            currentToken = c;
            Token token;
            if (c == '+') {
                token.type = TokenType::PLUS;
                token.value = "+";
                tokens.push_back(token);
            } else if (c == '-') {
                token.type = TokenType::MINUS;
                token.value = "-";
                tokens.push_back(token);
            } else if (c == '*') {
                token.type = TokenType::MULTIPLY;
                token.value = "*";
                tokens.push_back(token);
            } else if (c == '/') {
                token.type = TokenType::DIVIDE;
                token.value = "/";
                tokens.push_back(token);
            } else if (c == '=') {
                token.type = TokenType::EQUAL;
                token.value = "=";
                tokens.push_back(token);
            } else if (c == '(') {
                token.type = TokenType::LEFTBRACKET;
                token.value = "(";
                tokens.push_back(token);
            } else if (c == ')') {
                token.type = TokenType::RIGHTBRACKET;
                token.value = ")";
                tokens.push_back(token);
            } else if (c == '{') {
                token.type = TokenType::LEFTBRACES;
                token.value = "{";
                tokens.push_back(token);
            } else if (c == '}') {
                token.type = TokenType::RIGHTBRACES;
                token.value = "}";
                tokens.push_back(token);
            } else if (c == ';') {
                token.type = TokenType::SEMICOLONE;
                token.value = ";";
                tokens.push_back(token);
            }
            else if (c == '<') {
                token.type = TokenType::LESS;
                token.value = "<";
                tokens.push_back(token);
            }
            else if (c == '>') {
                token.type = TokenType::MORE;
                token.value = ">";
                tokens.push_back(token);
            }
            currentToken = "";
            
        }
    }

    // Last token
    if (!currentToken.empty()) {
        Token token;
        if (isdigit(currentToken[0])) {
            if (currentToken.find('.') != string::npos) {
                token.type = TokenType::FLOAT;
            } else {
                token.type = TokenType::Digit;
            }
        } else if (isKeyword(currentToken)) {
            token.type = getTokenType(currentToken);
        } else {
            if(isID(currentToken)) {
                token.type = TokenType::ID;
            } else {
                token.type = TokenType::NoneTerminal;
            }
        }
        token.value = currentToken;
        tokens.push_back(token);
    }

    return tokens;
}
TokenType getTokenType(const string& str) {
    if (str == "if") return TokenType::IF;
    else if (str == "for") return TokenType::FOR;
    else if (str == "else") return TokenType::ELSE;
    else if (str == "do") return TokenType::DO;
    else if (str == "while") return TokenType::WHILE;
    else if(str == "int" || str == "float" || str == "string" || str == "double" || str == "null" )return TokenType::Terminal;
    // Add more cases as needed
    else return TokenType::NoneTerminal;
}

public:
void printing(const string& inputFile, const string& outputFile) {
    // Open input file
    ifstream inFile(inputFile);
    if (!inFile) {
        cerr << "Error: Unable to open input file. Please Make sure Source File.txt Exists\n" << endl;
        return;
    }
    cout<<"Reading Source File ...\n";
    // Open output file
    ofstream outFile(outputFile+"_no_details.txt");
    ofstream outFiletokens(outputFile);
    if (!outFile) {
        cerr << "Error: Unable to open output file Creating new One...\n" << endl;
        outFile<<"";
        cout<<"File Created ... \n";
    }

    // Read input line by line
    string line;
    
    while (getline(inFile, line)) {
        // Tokenize each line
        vector<Token> tokens = scan(line);

        // Write tokens to output file
        for (const auto& token : tokens) {
            //outFile <<token.value << "  -->  ";
            // Write token type
            switch (token.type) {
                case TokenType::IF:
                   outFiletokens << "IF";
                    break; 
                    case TokenType::LESS:
                   outFiletokens << "LESS";
                    break;
                    case TokenType::MORE:
                   outFiletokens << "MORE";
                    break;
                case TokenType::DO:
                   outFiletokens << "DO";
                    break; 
                case TokenType::WHILE:
                   outFiletokens << "WHILE";
                    break; 
                case TokenType::PLUS:
                   outFiletokens << "PLUS";
                    break; 
                case TokenType::MINUS:
                   outFiletokens << "MINUS";
                    break; 
                case TokenType::EQUAL:
                   outFiletokens << "EQUAL";
                    break;
                case TokenType::DIVIDE:
                   outFiletokens << "DIVIDE";
                    break; 
                case TokenType::MULTIPLY:
                   outFiletokens << "MULTIPLY";
                    break;
                 case TokenType::SEMICOLONE:
                   outFiletokens << "SEMICOLONE";
                    break;
                 case TokenType::LEFTBRACKET:
                   outFiletokens << "LEFTBRACKET";
                    break; 
                    case TokenType::RIGHTBRACKET:
                   outFiletokens << "RIGHTBRACKET";
                    break; 
                    case TokenType::LEFTBRACES:
                   outFiletokens << "LEFTBRACES";
                    break; 
                    case TokenType::RIGHTBRACES:
                   outFiletokens << "RIGHTBRACES";
                    break; 
                case TokenType::FOR:
                   outFiletokens << "FOR";
                    break; 
                case TokenType::ELSE:
                   outFiletokens << "ELSE";
                    break; 
                case TokenType::Terminal:
                    outFiletokens << "Terminal";
                    break;
                case TokenType::ID:
                    outFiletokens << "ID";
                    break;
                case TokenType::Digit:
                    outFiletokens << "Digit";
                    break;
                case TokenType::FLOAT:
                    outFiletokens << "Float";
                    break;
                case TokenType::SYMBOL:
                    outFiletokens << "SYMBOL";
                    break;
                case TokenType::NoneTerminal:
                    outFiletokens << "NoneTerminal";
                    break;
            }
             outFile <<token.value << endl;
             outFiletokens << ": " << token.value << endl;
            // Write token value
        }
    }
    cout<<"Tokens Has Been Updated !\n";
    // Close files
    inFile.close();
    outFile.close();
    outFiletokens.close();
}
};