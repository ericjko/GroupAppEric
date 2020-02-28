using GroupApp.Models;
using MapKit;

namespace GroupApp.iOS
{
    public class CustomMKAnnotationView : MKAnnotationView
    {
        
        public CustomPin Pin { get; set; }

        public CustomMKAnnotationView(IMKAnnotation annotation, string id)
            : base(annotation, id)
        {
        }
    }
}
