#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <cctype>
#include <cstdlib>
#include "Scanner/GetTokens.Cpp";

using namespace std;
string ofile , ifile;
string new_Srcfile_loc , new_Tokenfile_loc;
bool location_is_changed_src = false;
bool location_is_changed_token = false;
using namespace std;

void change_loc_src(const string& loc) {
    ifile = loc;
    location_is_changed_src = true;
}

void change_loc_token(const string& loc) {
    ofile = loc;
    location_is_changed_token = true;
}

void menu() {
    int choice;
    cout << "Welcome To Scanner Application\n";
    cout << "1- Get Tokens\n";
    cout << "2- Where To Source File And Token Are Located ? \n";
    cout << "3- Locate Source File \n";
    cout << "4- Exit\n";
    cout << "User Input: ";
    cin >> choice;

    switch (choice) {
        case 1: {
            scanner sc;
            if (location_is_changed_src) {
                if (location_is_changed_token) {
                    cout<<"Tokens Will Be Created At ["<<ofile<<"] \n";
                    cout<<"Source Must Be Created At ["<<ifile<<"] \n";
                    sc.printing(ifile, ofile);
                } else {
                    ofile = "D://Compiler Project//Tokens.txt";
                    cout<<"Tokens Will Be Created At ["<<ofile<<"] \n";
                    cout<<"Source Must Be Created At ["<<ifile<<"] \n";
                    sc.printing(ifile, ofile);
                }
            } else {
                ifile = "D://Compiler Project//ParseTree//launcher//Source File.txt";
                if (location_is_changed_token) {
                    cout<<"Tokens Will Be Created At ["<<ofile<<"] \n";
                    cout<<"Source Must Be Created At ["<<ifile<<"] \n";
                    sc.printing(ifile, ofile);
                } else {
                    ofile = "D://Compiler Project//ParseTree//Tokens.txt";
                    cout<<"Tokens Will Be Created At ["<<ofile<<"] \n";
                    cout<<"Source Must Be Created At ["<<ifile<<"] \n";
                    sc.printing(ifile, ofile);
                }
            }
            cout << "\nThe Program Has Finished Creating Tokens File Successfully Located in application file You will need to Open Parse Tree Application to Draw The Parse Tree ... Need Any Thing Else? y/n\n";
            cout << "User Input: ";
            char x;
            cin >> x;
            switch (x) {
                case 'y':
                    menu();
                    break;
                case 'n':
                    return;
            };
            break;
        }
        case 2:
            if(location_is_changed_src)
            {
                cout << "Source File is in ["<<new_Srcfile_loc<<"] \n";
            }else
            {
                cout << "Source File is in [D://Compiler Project//launcher//Source File.txt] \n";
            }
            if(location_is_changed_token)
            {
                cout << "Token File will be stored in ["<<new_Tokenfile_loc<<"] \n";
            }else
            {
                cout << "Source File is in [D://Compiler Project//Tokens.txt] \n";
            }
            menu();
            break;
            
        case 3: {
            char xy;
            cin.ignore(); // Clear any leftover newline characters from the input buffer
            cout << "Enter The Source File Location[Keep In Mind That The Location Should Follow This Format 'E://your location//file_name.txt']: \n";
            cout << "User Input: ";
            getline(cin, new_Srcfile_loc);
            cout << "The Entered Location Is: [" << new_Srcfile_loc << "] Is it Correct y/n ?\n";
            cout << "User Input: ";
            cin >> xy;
            if (xy == 'y') {
                cout << "You New Location Is Stored ... Returning to Menu ...\n";
                change_loc_src(new_Srcfile_loc);
                menu();
            } else {
                cout << "Nothing Changed Returning to Menu ... \n";
                menu();
            }
            break;
        }
        case 4:
            return;
        default:
            cout << "Invalid Input Try Again\n";
            menu();
            break;
    }
}

int main() {
    menu();
    return 0;
}


