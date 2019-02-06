using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        // Path.Combine method combines strings into a path.  Comes from System.IO
        // Environment.GetFolderPath gets the path to the system special folder that is identified by the specified enumeration.
        // Environment.SpecialFolder.LocalApplicationData is the directory that serves as a common repository for application-specific data that is used by the current, non-roaming user.
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                // ReadAllText opens a text file, reads all the text in the file into a string, and then closes the file.
                // The value of the string that is returned by ReadAllText is assigned the editor.
                editor.Text = File.ReadAllText(_fileName);
            }
        } // end constructor

        // object sender is a parameter called Sender that contains a reference to the control/object that raised the event.
        // EventArgs e is a parameter called e that contains the event data.
        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // WriteAllText () creates a new file (only if it doesn't already exist), and it adds the text that's inside the editor.
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }
    }
}



// This code defines a field, which references a file named notes.txt that will store note data in the local application data folder for the application.
// When the page constructor is executed the file is read, if it exists, and displayed in the Editor. 
// When the save button is pressed the OnSaveButtonClciked event handler is executed, which saves the content of the Editor to the file.
// When the Delete Button is pressed the OnDeleteButtonClicked event handler is executed, which deletes the file, provided that it exists, and removes any text from the editor.