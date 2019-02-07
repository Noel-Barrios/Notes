using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Notes.Models;
using System.IO;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }



        //When the save button is clicked, the OnSaveButtonClicked event handler is executed,
        // which either saves the content of the Editor to a new file with a randomly generated filename,
        // or to an existing file if a note is being updated.  
        // In both cases, the file is stored in the local application data folder for the application.  
        // Thne the method navigates back to the the previous page.
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // this code stores a Note instance, which represents a single note, in the BindingContext of the page.
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                // Path.Combine will combine two strings into a path.
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                // WriteAllText creates a new file, writes the specified string (note.Text) to the file, and then closes the file.  
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // WriteAllText overwrites the target file with the specified string (note.Text)
                File.WriteAllText(note.Filename, note.Text);
            }

            // Asynchronously removes the top Page from the navigation stack.
            await Navigation.PopAsync();
        }


        // When the delete button is pressed the OnSaveButtonClicked event handler is executed, which deletes the file,
        // provided that it exists, and navigates back to the previous page.
        async void OnDeleteButtonClicked (object sender, EventArgs e)
        {
            // this code stores a Note instance, which represents a single note, in the BindingContext
            var note = (Note)BindingContext;

            if (File.Exists(note.Filename)) 
            {
                File.Delete(note.Filename);
            }

            await Navigation.PopAsync();

        }


    }
}



