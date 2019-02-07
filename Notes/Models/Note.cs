using System;

namespace Notes.Models
{
    public class Note
    {
        // Auto-implemented properties for trivial get and set
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}


// this class defines a Note model that will store data about each note in the application.  


// ABOUT MVC: 
// In the MVC pattern, the model represents the data, and does nothing else.
// The model does NOT depend on the controller or the view.  
// The view displays the model data, and sends user actions (e.g. button clicks) to the controller.
